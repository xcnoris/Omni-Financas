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

namespace Aplication.IntegradorCRM.Servicos.Boleto
{
    internal class Boleto_Services
    {
        public string Message;
        public bool Status;

        #region Metodos Gerais
        private static ModeloOportunidadeRequest InstanciarModeloRequest( string mensagem, RetornoBoleto RetornoBoleto)
        {
            return new ModeloOportunidadeRequest()
            {
                number = $"55{RetornoBoleto.Celular}",
                text = MensagemComVariaveisBoleto.SubstituirVariaveis(mensagem, RetornoBoleto)
            };
        }


        public async static Task VerificarQuitacao(Situacao_Boleto situacao, RelacaoBoletoCRMModel BoletoRelacao,  DadosAPIModels DadosAPI, bool InTBRelacao, RetornoBoleto retorno)
        {
            // Verifica se o boleto já esta pago, caso esteja muda o boleto para fase Pago/Aguardando Liberação
            if (situacao == Situacao_Boleto.Quitado)
            {
               

                // Atualize para a etapa pago no CRM, e atualiza no banco
                BoletoRelacao.Quitado = 1;
                try
                {
                    await QuitacaoBoleto.Quitar( BoletoRelacao, retorno, InTBRelacao, DadosAPI);
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
            using DAL<AcaoSituacao_Boleto_CRM> dalSitBoleto = new DAL<AcaoSituacao_Boleto_CRM>(new IntegradorDBContext());
            AcaoSituacao_Boleto_CRM? AcoesOS = await dalSitBoleto.BuscarPorAsync(x => x.Situacao == SitBoleto);

            return InstanciarModeloRequest(AcoesOS.Mensagem,retornoBoleto);
          
        }

        public static async Task<ModeloOportunidadeRequest> InstanciarAcaoRequestBoleto(RetornoBoleto retornoBoleto, int DiasEmAtraso)
        {
            using DAL<BoletoAcoesCRMModel> dalSitBoleto = new DAL<BoletoAcoesCRMModel>(new IntegradorDBContext());
            BoletoAcoesCRMModel? AcaoBoleto = await dalSitBoleto.BuscarPorAsync(x => x.Dias_Cobrancas == DiasEmAtraso);

            return InstanciarModeloRequest(AcaoBoleto.Mensagem_Atualizacao, retornoBoleto);
           
        }

        internal async static Task VerificarBoletosCriados(RelacaoBoletoCRMModel BoletoRelacao, int diasAtraso, int situacao, int situacaTBRelacao,  DadosAPIModels DadosAPI, List<BoletoAcoesCRMModel> AcoesBoletoList, RetornoBoleto retornoBoleto, Configuracao_Geral ConfigGeral)
        {
            using (var dalBoletoUsing = new DAL<RelacaoBoletoCRMModel>(new IntegradorDBContext()))
            {
                // Verifica a situação do boleto (3 = cancelado/estornado, 2 = quitado)
                switch ((Situacao_Boleto)situacao)
                {
                    // Verifica se esta cancelado
                    case Situacao_Boleto.Cancelada_Ou_Estornado:
                        if ((Situacao_Boleto)situacaTBRelacao != Situacao_Boleto.Cancelada_Ou_Estornado)
                        {
                            await CancelarBoleto( BoletoRelacao, DadosAPI, retornoBoleto, ConfigGeral.ChBox_BoletoEnviarMensCancelamento);
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
                            await QuitarBoleto( BoletoRelacao, DadosAPI, retornoBoleto);
                        }
                        else
                        {
                            MetodosGerais.RegistrarLog("BOLETO", $"Boleto já existe na tabela relação. Está quitado!");
                        }
                        break;

                    // Caso não seja quitado nem cancelado, faz a cobrança
                    default:
                        await RealizarCobrancas(AcoesBoletoList, diasAtraso, BoletoRelacao.DiasEmAtraso, BoletoRelacao, DadosAPI, retornoBoleto, ConfigGeral.ChBox_BoletoMensFimdeSemana);
                        break;
                }
            }
        }

        private async static Task RealizarCobrancas(List<BoletoAcoesCRMModel> AcoesBoletoList, int diasAtraso, int DiasAtrasoRelBoleto, RelacaoBoletoCRMModel boletoRelacao, DadosAPIModels DadosAPI, RetornoBoleto retornoBoleto, bool PermitirEnvioFinsDeSemana)
        {
            await VerificacaoDeCobranca.RealizarCobranca(AcoesBoletoList, diasAtraso, DiasAtrasoRelBoleto, boletoRelacao, retornoBoleto, DadosAPI, PermitirEnvioFinsDeSemana);
        }
        private async static Task QuitarBoleto( RelacaoBoletoCRMModel BoletoRelacao,DadosAPIModels DadosAPI, RetornoBoleto retorno)
        {
            await QuitacaoBoleto.Quitar( BoletoRelacao, retorno, true, DadosAPI);
        }

        private async static Task CancelarBoleto( RelacaoBoletoCRMModel BoletoRelacao , DadosAPIModels DadosAPI, RetornoBoleto retorno, bool EnviarMensagemCancelamento)
        {
            await CancelamentoBoleto.Cancelar( BoletoRelacao, DadosAPI, retorno, EnviarMensagemCancelamento);
        }
        #endregion

        #region Metodo API

        // Método auxiliar para enviar requisição de criação de oportunidade para a API
        internal static async Task<bool> EnviarMensagemCriacao(ModeloOportunidadeRequest request, DadosAPIModels DadosAPI)
        {
            using (HttpClient client = new HttpClient())
            {
                // Configurar o cabeçalho de autenticação
                client.DefaultRequestHeaders.Add("apikey", DadosAPI.Token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Definir URL do endpoint da Evolution API
                string url = $"https://n8n-evolution-api.usbaxy.easypanel.host/message/sendText/{DadosAPI.Instancia}";

                HttpContent content = MetodosGerais.CriarConteudoJson(request);
               
               

                try
                {
                    HttpResponseMessage response = await client.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        MetodosGerais.RegistrarLog("BOLETO", " Resposta OK - Mensagem Criação Enviada!");
                        return true;
                    }

                    MetodosGerais.RegistrarLog("BOLETO", $"Erro na resposta da API: Status {response.StatusCode} - {response}  | Json: {content}");
                    return false;
                }
                catch (HttpRequestException ex)
                {
                    MetodosGerais.RegistrarLog("BOLETO", $"Erro de rede ao chamar API: {ex.Message}  | Json: {content}");
                    throw;
                }
                catch (Exception ex)
                {
                    MetodosGerais.RegistrarLog("BOLETO", $"Exceção ao processar resposta da API: {ex.Message}  | Json: {content}");
                    throw;
                }
            }
        }

        // Método auxiliar para adicionar o boleto no banco de dados
        internal static async Task AdicionarBoletoNoBanco(DAL<RelacaoBoletoCRMModel> dalTableRelacaoBoleto, RelacaoBoletoCRMModel boletoInTabRel)
        {
            boletoInTabRel.Data_Criacao = DateTime.Now;

            using (var dalBoletoUsing = new DAL<RelacaoBoletoCRMModel>(new IntegradorDBContext()))
            {
                await dalBoletoUsing.AdicionarAsync(boletoInTabRel);
            }
        }

        internal static async Task<bool> EnviarMensagem(ModeloOportunidadeRequest request, DadosAPIModels DadosAPI, string IdDocReceber)
        {
            // configurar o cabeçalho de autorização 
            using (HttpClient client = new HttpClient())
            {
                // Configurar o cabeçalho de autenticação
                client.DefaultRequestHeaders.Add("apikey", DadosAPI.Token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Definir URL do endpoint da Evolution API
                string url = $"https://n8n-evolution-api.usbaxy.easypanel.host/message/sendText/{DadosAPI.Instancia}";

                HttpContent content = MetodosGerais.CriarConteudoJson(request);

                try
                {
                    HttpResponseMessage response = await client.PostAsync(url, content);
                    var responseBody = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        MetodosGerais.RegistrarLog("BOLETO", $"Resposta OK - Mensagem Enviada com Sucesso! | DocReceber: {IdDocReceber}  | Json: {content}");
                        return true;
                    }

                    MetodosGerais.RegistrarLog("BOLETO", $"Erro na resposta da API: Status {response.StatusCode} - {responseBody} | DocReceber: {IdDocReceber}  | Json: {content}");
                    return false;
                }
                catch (HttpRequestException ex)
                {
                    MetodosGerais.RegistrarLog("BOLETO", $"Erro de rede ao chamar API: {ex.Message}  | DocReceber: {IdDocReceber}  | Json: {content}");
                    throw;
                }
                catch (Exception ex)
                {
                    MetodosGerais.RegistrarLog("BOLETO", $"Exceção ao processar resposta da API: {ex.Message}  | DocReceber: {IdDocReceber}  | Json: {content}");
                    throw;
                }

            }
        }

        // Método auxiliar para atualizar boleto no banco
        internal static async Task AtualizarBoletoNoBanco(RelacaoBoletoCRMModel boletoRelacao)
        {
            boletoRelacao.Data_Atualizacao = DateTime.Now;

            using (var dalBoletoUsing = new DAL<RelacaoBoletoCRMModel>(new IntegradorDBContext()))
            {
                await dalBoletoUsing.AtualizarAsync(boletoRelacao);
                MetodosGerais.RegistrarLog("CrudBoleto", $"DocReceber {boletoRelacao.Id_DocumentoReceber} atualizado no banco de dados!");
            }
        }

     

        #endregion
    }
}
