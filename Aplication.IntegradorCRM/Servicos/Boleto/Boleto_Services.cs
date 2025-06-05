using DataBase.IntegradorCRM.Data;
using Metodos.IntegradorCRM.Metodos;
using Modelos.IntegradorCRM.Models.EF;
using Modelos.IntegradorCRM.Models;
using Modelos.IntegradorCRMRM.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using Modelos.IntegradorCRM.Models.Enuns;
using Aplication.IntegradorCRM.Servicos.OS;
using System.Net;

namespace Aplication.IntegradorCRM.Servicos.Boleto
{
    internal class Boleto_Services
    {
        public string Message;
        public bool Status;
        private static readonly HttpClient _httpClient;

        // Bloco estático para configurar o HttpClient uma única vez
        static Boleto_Services()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var handler = new HttpClientHandler();
            // REMOVER isso em produção se quiser validar SSL corretamente
            handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
            _httpClient = new HttpClient(handler);
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }


        #region Metodos Gerais
        private static ModeloOportunidadeRequest InstanciarModeloRequest( string mensagem, RetornoBoleto RetornoBoleto)
        {
            return new ModeloOportunidadeRequest()
            {
                number = $"55{RetornoBoleto.Celular}",
                text = MensagemComVariaveisBoleto.SubstituirVariaveis(mensagem, RetornoBoleto)
            };
        }


        public async static Task VerificarQuitacao(Situacao_Boleto situacao, RelacaoBoletoModel BoletoRelacao,  DadosAPIModels DadosAPI, bool InTBRelacao, RetornoBoleto retorno, ConfigEmail configEmail)
        {
            // Verifica se o boleto já esta pago, caso esteja muda o boleto para fase Pago/Aguardando Liberação
            if (situacao == Situacao_Boleto.Quitado)
            {
               

                // Atualize para a etapa pago no CRM, e atualiza no banco
                BoletoRelacao.Quitado = 1;
                try
                {
                    await QuitacaoBoleto.Quitar( BoletoRelacao, retorno, InTBRelacao, DadosAPI, configEmail);
                }
                catch (Exception ex)
                {
                    //MetodosGerais.RegistrarLog("", "");
                    throw new Exception(ex.Message);
                }
            }
        }

        public static async Task<ModeloOportunidadeRequest> InstanciarAcaoRequestSitucaoBoleto(RetornoBoleto retornoBoleto, Situacao_Boleto SitBoleto)
        {
            using DAL<AcaoSituacao_Boleto> dalSitBoleto = new DAL<AcaoSituacao_Boleto>(new IntegradorDBContext());
            AcaoSituacao_Boleto? AcoesOS = await dalSitBoleto.BuscarPorAsync(x => x.Situacao == SitBoleto);

            return InstanciarModeloRequest(AcoesOS.MensagemAtualizacaoWhats,retornoBoleto);
          
        }

        public static async Task<EmailModel> InstanciarAcaoRequesEmailtSitucaoBoleto(RetornoBoleto retornoBoleto, Situacao_Boleto SitBoleto)
        {
            using DAL<AcaoSituacao_Boleto> dalSitBoleto = new DAL<AcaoSituacao_Boleto>(new IntegradorDBContext());
            AcaoSituacao_Boleto? AcoesOS = await dalSitBoleto.BuscarPorAsync(x => x.Situacao == SitBoleto);
            EmailModel Email = new EmailModel()
            {
                mensagem = AcoesOS.MensagemAtualizacaoEmail,
                mensagemEhHtml = AcoesOS.MensagemEmailEmHTML
            };

            return Email;

        }

        public static async Task<ModeloOportunidadeRequest> InstanciarAcaoRequestBoleto(RetornoBoleto retornoBoleto, int DiasEmAtraso)
        {
            using DAL<BoletoAcoesModel> dalSitBoleto = new DAL<BoletoAcoesModel>(new IntegradorDBContext());
            BoletoAcoesModel? AcaoBoleto = await dalSitBoleto.BuscarPorAsync(x => x.Dias_Cobrancas == DiasEmAtraso);

            return InstanciarModeloRequest(AcaoBoleto.MensagemAtualizacaoWhats, retornoBoleto);
           
        }

        internal async static Task VerificarBoletosCriados(RelacaoBoletoModel BoletoRelacao, int diasAtraso, int situacao, int situacaTBRelacao,  DadosAPIModels DadosAPI, List<BoletoAcoesModel> AcoesBoletoList, RetornoBoleto retornoBoleto, Configuracao_Geral ConfigGeral, ConfigEmail configEmail)
        {
            using (var dalBoletoUsing = new DAL<RelacaoBoletoModel>(new IntegradorDBContext()))
            {
                // Verifica a situação do boleto (3 = cancelado/estornado, 2 = quitado)
                switch ((Situacao_Boleto)situacao)
                {
                    // Verifica se esta cancelado
                    case Situacao_Boleto.Cancelada_Ou_Estornado:
                        if ((Situacao_Boleto)situacaTBRelacao != Situacao_Boleto.Cancelada_Ou_Estornado)
                        {
                            await CancelarBoleto( BoletoRelacao, DadosAPI, retornoBoleto, ConfigGeral.ChBox_BoletoEnviarMensCancelamento, configEmail);
                        }
                        else
                        {
                            MetodosGerais.RegistrarLog("BOLETO", $"Boleto já existe na tabela relação. Já está ajustado como Cancelado/Estornado.");
                        }
                        break;
                    // Verifica se esta quitado
                    case Situacao_Boleto.Quitado:
                        if (BoletoRelacao.Quitado == 0)
                        {
                            await QuitarBoleto( BoletoRelacao, DadosAPI, retornoBoleto, configEmail);
                        }
                        else
                        {
                            MetodosGerais.RegistrarLog("BOLETO", $"Boleto já existe na tabela relação. Está quitado!");
                        }
                        break;

                    // Caso não seja quitado nem cancelado, faz a cobrança
                    default:
                        await RealizarCobrancas(AcoesBoletoList, diasAtraso, BoletoRelacao.DiasEmAtraso, BoletoRelacao, DadosAPI, retornoBoleto, ConfigGeral.ChBox_BoletoMensFimdeSemana, configEmail);
                        break;
                }
            }
        }

        private async static Task RealizarCobrancas(List<BoletoAcoesModel> AcoesBoletoList, int diasAtraso, int DiasAtrasoRelBoleto, RelacaoBoletoModel boletoRelacao, DadosAPIModels DadosAPI, RetornoBoleto retornoBoleto, bool PermitirEnvioFinsDeSemana, ConfigEmail configEmail)
        {
            await VerificacaoDeCobranca.RealizarCobranca(AcoesBoletoList, diasAtraso, DiasAtrasoRelBoleto, boletoRelacao, retornoBoleto, DadosAPI, PermitirEnvioFinsDeSemana, configEmail);
        }
        private async static Task QuitarBoleto( RelacaoBoletoModel BoletoRelacao,DadosAPIModels DadosAPI, RetornoBoleto retorno, ConfigEmail configEmail)
        {
            await QuitacaoBoleto.Quitar( BoletoRelacao, retorno, true, DadosAPI, configEmail);
        }

        private async static Task CancelarBoleto( RelacaoBoletoModel BoletoRelacao , DadosAPIModels DadosAPI, RetornoBoleto retorno, bool EnviarMensagemCancelamento, ConfigEmail configEmail)
        {
            await CancelamentoBoleto.Cancelar( BoletoRelacao, DadosAPI, retorno, EnviarMensagemCancelamento, configEmail);
        }
        #endregion

        #region Metodo API

        // Método auxiliar para enviar requisição de criação de oportunidade para a API
        internal static async Task<bool> EnviarMensagemCriacao(ModeloOportunidadeRequest request, DadosAPIModels DadosAPI)
        {
            string url = $"https://cdi-omni-evolution-api.azvg4h.easypanel.host/message/sendText/{DadosAPI.Instancia}";
            HttpContent content = MetodosGerais.CriarConteudoJson(request);
            string jsonContent = await content.ReadAsStringAsync();

            for (int tentativa = 1; tentativa <= 5; tentativa++)
            {
                try
                {
                    _httpClient.DefaultRequestHeaders.Remove("apikey");
                    _httpClient.DefaultRequestHeaders.Add("apikey", DadosAPI.Token);

                    HttpResponseMessage response = await _httpClient.PostAsync(url, content);
                    string responseBody = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        MetodosGerais.RegistrarLog("BOLETO", $"Tentativa {tentativa} - Mensagem Criação enviada com sucesso! Mensagem: {request.text}");
                        return true;
                    }

                    MetodosGerais.RegistrarLog("BOLETO", $"Tentativa {tentativa} - Erro na resposta da API: Status {response.StatusCode} - {responseBody} | Json: {jsonContent}");
                }
                catch (HttpRequestException ex)
                {
                    MetodosGerais.RegistrarLog("BOLETO", $"Tentativa {tentativa} - Erro de rede: {ex.Message} | Inner: {ex.InnerException?.Message} | Json: {jsonContent}");
                }
                catch (Exception ex)
                {
                    MetodosGerais.RegistrarLog("BOLETO", $"Tentativa {tentativa} - Exceção geral: {ex.Message} | Json: {jsonContent}");
                }

                await Task.Delay(1000 * tentativa); // Espera 1s, depois 2s, depois 3s
            }

            return false;
        }

        // Método auxiliar para adicionar o boleto no banco de dados
        internal static async Task AdicionarBoletoNoBanco(DAL<RelacaoBoletoModel> dalTableRelacaoBoleto, RelacaoBoletoModel boletoInTabRel)
        {
            boletoInTabRel.Data_Criacao = DateTime.Now;

            using (var dalBoletoUsing = new DAL<RelacaoBoletoModel>(new IntegradorDBContext()))
            {
                await dalBoletoUsing.AdicionarAsync(boletoInTabRel);
            }
        }

        internal static async Task<bool> EnviarMensagem(ModeloOportunidadeRequest request, DadosAPIModels DadosAPI, string IdDocReceber)
        {
            string url = $"https://cdi-omni-evolution-api.azvg4h.easypanel.host/message/sendText/{DadosAPI.Instancia}";
            HttpContent content = MetodosGerais.CriarConteudoJson(request);
            string jsonContent = await content.ReadAsStringAsync();

            for (int tentativa = 1; tentativa <= 5; tentativa++)
            {
                try
                {
                    _httpClient.DefaultRequestHeaders.Remove("apikey");
                    _httpClient.DefaultRequestHeaders.Add("apikey", DadosAPI.Token);

                    HttpResponseMessage response = await _httpClient.PostAsync(url, content);
                    string responseBody = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        MetodosGerais.RegistrarLog("BOLETO", $"Tentativa {tentativa} - Mensagem enviada com sucesso! | DocReceber: {IdDocReceber}");
                        return true;
                    }

                    MetodosGerais.RegistrarLog("BOLETO", $"Tentativa {tentativa} - Erro na resposta da API: Status {response.StatusCode} - {responseBody} | DocReceber: {IdDocReceber} | Json: {jsonContent}");
                }
                catch (HttpRequestException ex)
                {
                    MetodosGerais.RegistrarLog("BOLETO", $"Tentativa {tentativa} - Erro de rede: {ex.Message} | Inner: {ex.InnerException?.Message} | DocReceber: {IdDocReceber} | Json: {jsonContent}");
                }
                catch (Exception ex)
                {
                    MetodosGerais.RegistrarLog("BOLETO", $"Tentativa {tentativa} - Exceção geral: {ex.Message} | DocReceber: {IdDocReceber} | Json: {jsonContent}");
                }

                await Task.Delay(1000 * tentativa);
            }

            return false;
        }

        // Método auxiliar para atualizar boleto no banco
        internal static async Task AtualizarBoletoNoBanco(RelacaoBoletoModel boletoRelacao)
        {
            boletoRelacao.Data_Atualizacao = DateTime.Now;

            using (var dalBoletoUsing = new DAL<RelacaoBoletoModel>(new IntegradorDBContext()))
            {
                await dalBoletoUsing.AtualizarAsync(boletoRelacao);
                MetodosGerais.RegistrarLog("CrudBoleto", $"DocReceber {boletoRelacao.Id_DocumentoReceber} atualizado no banco de dados!");
            }
        }

     

        #endregion
    }
}
