using DataBase.IntegradorCRM.Data;
using Integrador_Com_CRM.Metodos.Boleto;
using Metodos.IntegradorCRM.Metodos;
using Modelos.IntegradorCRM.Models.EF;
using Modelos.IntegradorCRM.Models;
using Modelos.IntegradorCRMRM.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using Modelos.IntegradorCRM.Models.Enuns;

namespace Aplication.IntegradorCRM.Servicos
{
    internal class Boleto_Services
    {
        public string Message;
        public bool Status;
        private readonly CobrancaServicos CobrancasNaSegunda;
        public Boleto_Services()
        {
           
        }

        #region Metodos Gerais
        public async Task AtualizarAcaoNoCRM(int diasAtraso, string codigoJornada, DadosAPIModels DadosAPI, DAL<RelacaoBoletoCRMModel> dalBoleto, RelacaoBoletoCRMModel BoletoRelacao, bool foiQuitado, bool naTableRelacao)
        {
            try
            {
                BoletoAcoesCRMModel BoletoAcaoBuscado = FrmboletoAcao.BuscarBoletoAcoes(diasAtraso);
                if (BoletoAcaoBuscado is not null)
                {

                    string codAcao = BoletoAcaoBuscado.Codigo_Acao;
                    string textoFollowup = BoletoAcaoBuscado.Mensagem_Atualizacao;

                    AtualizarAcaoRequest AtualizarAcao = new AtualizarAcaoRequest
                    {
                        codigoOportunidade = BoletoRelacao.Cod_Oportunidade,
                        codigoAcao = codAcao,
                        codigoJornada = codigoJornada,
                        textoFollowup = textoFollowup
                    };

                    /*
                        Verifica se o boleto já esta na tabela relação,caso já esteja, significa que não precisa fazer
                        uma consuta no banco para descobrir o Id, visto que a instancia que veio no parametro já tem o Id

                    */
                    if (foiQuitado)
                    {
                        BoletoRelacao.Quitado = 1;
                    }
                    if (naTableRelacao == true)
                    {
                        BoletoRelacao.Situacao = 2;
                        await EnviarBoletoParaCRM.AtualizarAcao(AtualizarAcao, DadosAPI.Token, dalBoleto, BoletoRelacao, foiQuitado);
                    }
                    else
                    {
                        RelacaoBoletoCRMModel BoletoInTableRElacao = dalBoleto.BuscarPor(x => x.Id_DocumentoReceber == BoletoRelacao.Id_DocumentoReceber);
                        BoletoInTableRElacao.Situacao = BoletoRelacao.Situacao;
                        BoletoInTableRElacao.DiasEmAtraso = BoletoRelacao.DiasEmAtraso;
                        await EnviarBoletoParaCRM.AtualizarAcao(AtualizarAcao, DadosAPI.Token, dalBoleto, BoletoInTableRElacao, foiQuitado);
                    }



                    MetodosGerais.RegistrarLog("BOLETO", $"Boleto {BoletoRelacao.Id_DocumentoReceber} atualizado para a etapa '{textoFollowup}'. CodOp: {BoletoRelacao.Cod_Oportunidade}");
                }
                else
                {
                    MetodosGerais.RegistrarLog("BOLETO", $"[ERROR]: Ao consultar Dados da Ação para o boleto: {BoletoRelacao.Id_DocumentoReceber}!");
                    Message = $"[ERROR]: Ao consultar Dados da Ação para o boleto: {BoletoRelacao.Id_DocumentoReceber}!";
                    Status = false;
                }
            }
            catch (Exception ex)
            {
                MetodosGerais.RegistrarLog("BOLETO", $"[ERROR]: {ex.Message}.Para o boleto: {BoletoRelacao.Id_DocumentoReceber}");
                Message = $"[ERROR]: {ex.Message}";
                Status = false;
            }
        }

        public async Task AtualizarAcaoParaPagoNoCRM(AcaoSituacao_Boleto_CRM AcoesSituacao_Quitado_Boleto, string codigoJornada, DadosAPIModels DadosAPI, DAL<RelacaoBoletoCRMModel> dalBoleto, RelacaoBoletoCRMModel BoletoRelacao, bool naTableRelacao)
        {
            try
            {
                if (AcoesSituacao_Quitado_Boleto is not null)
                {

                    string codAcao = AcoesSituacao_Quitado_Boleto.CodAcaoCRM;
                    string textoFollowup = AcoesSituacao_Quitado_Boleto.Mensagem_Acao;

                    AtualizarAcaoRequest AtualizarAcao = new AtualizarAcaoRequest
                    {
                        codigoOportunidade = BoletoRelacao.Cod_Oportunidade,
                        codigoAcao = codAcao,
                        codigoJornada = codigoJornada,
                        textoFollowup = textoFollowup
                    };

                    /*
                        Verifica se o boleto já esta na tabela relação,caso já esteja, significa que não precisa fazer
                        uma consuta no banco para descobrir o Id, visto que a instancia que veio no parametro já tem o Id
                    */
                    
                    BoletoRelacao.Quitado = 1;
                    
                    if (naTableRelacao == true)
                    {
                        BoletoRelacao.Situacao = 2;
                        await EnviarBoletoParaCRM.AtualizarAcao(AtualizarAcao, DadosAPI.Token, dalBoleto, BoletoRelacao, foiQuitado);
                    }
                    else
                    {
                        RelacaoBoletoCRMModel BoletoInTableRElacao = dalBoleto.BuscarPor(x => x.Id_DocumentoReceber == BoletoRelacao.Id_DocumentoReceber);
                        BoletoInTableRElacao.Situacao = BoletoRelacao.Situacao;
                        BoletoInTableRElacao.DiasEmAtraso = BoletoRelacao.DiasEmAtraso;
                        await EnviarBoletoParaCRM.AtualizarAcao(AtualizarAcao, DadosAPI.Token, dalBoleto, BoletoInTableRElacao, foiQuitado);
                    }



                    MetodosGerais.RegistrarLog("BOLETO", $"Boleto {BoletoRelacao.Id_DocumentoReceber} atualizado para a etapa '{textoFollowup}'. CodOp: {BoletoRelacao.Cod_Oportunidade}");
                }
                else
                {
                    MetodosGerais.RegistrarLog("BOLETO", $"[ERROR]: Ao consultar Dados da Ação para o boleto: {BoletoRelacao.Id_DocumentoReceber}!");
                    Message = $"[ERROR]: Ao consultar Dados da Ação para o boleto: {BoletoRelacao.Id_DocumentoReceber}!";
                    Status = false;
                }
            }
            catch (Exception ex)
            {
                MetodosGerais.RegistrarLog("BOLETO", $"[ERROR]: {ex.Message}.Para o boleto: {BoletoRelacao.Id_DocumentoReceber}");
                Message = $"[ERROR]: {ex.Message}";
                Status = false;
            }
        }

        public async Task VerificarQuitacao(int situacao, RelacaoBoletoCRMModel BoletoRelacao, List<AcaoSituacao_Boleto_CRM> AcoesSituacaoBoleto, string codigoJornada, DadosAPIModels DadosAPI)
        {
            // Verifica se o boleto já esta pago, caso esteja muda o boleto para fase Pago/Aguardando Liberação
            if ((Situacao_Boleto)situacao == Situacao_Boleto.Quitado)
            {
                BoletoRelacao.Quitado = 1;
                // Atualize para a etapa pago no CRM, e atualiza no banco
                // Passa -1 no primeiro parametro para informar que esta quitado
                AcaoSituacao_Boleto_CRM? AcaoSituacaoQuitadoBoleto = AcoesSituacaoBoleto.FirstOrDefault(x => x.Situacao.Equals(Situacao_Boleto.Quitado));
                if (AcaoSituacaoQuitadoBoleto is not null)
                {
                    try
                    {
                        using (var dalBoletoUsing = new DAL<RelacaoBoletoCRMModel>(new IntegradorDBContext()))
                            await AtualizarAcaoParaPagoNoCRM(AcaoSituacaoQuitadoBoleto, codigoJornada, DadosAPI, dalBoletoUsing, BoletoRelacao, false);
                    }
                    catch (Exception ex) 
                    {
                        MetodosGerais.RegistrarErroExcecao("Error-BOLETO", $"Erro ao tentar atualziar boleto para etapa pago no CRM. Boleto: {BoletoRelacao.Id_DocumentoReceber}", ex);
                    }
                }
                else
                {
                    MetodosGerais.RegistrarLog("Error-BOLETO", $"[Error]: Nenhuma Ação encontrado para a situação Quitado!");
                }
            }
        }

        internal async void VerificarAtrasoEBoleto(RelacaoBoletoCRMModel boleto, int diasAtraso, string codigoJornada, DadosAPIModels DadosAPI, DAL<RelacaoBoletoCRMModel> dalBoleto, int DiasAtrasoRelBoleto)
        {
            //Busca as configurações de dias de cobranças no DGV no Frm_GeralUC
            BoletoAcoesCRMModel boletoAcaoBuscado = new BoletoAcoesCRMModel();// = FrmboletoAcao.BuscarBoletoAcoes(diasAtraso);

            if (boletoAcaoBuscado is not null)
            {
                // Verifica se o dia de atraso está na lista e não é igual ao registrado
                if (DiasAtrasoRelBoleto != diasAtraso)
                {
                    boleto.DiasEmAtraso = diasAtraso;

                    // Verifica se hoje é final de semana, caso seja, não faz a cobrança dos boleto.
                    if (DateTime.Today.DayOfWeek == DayOfWeek.Saturday || DateTime.Today.DayOfWeek == DayOfWeek.Sunday)
                    {
                        // Cria um registro na tabela Cobrancas_Na_Segunda_CRM. Toda Segunda os registro que estao nessa tabela são
                        // Lidos e enviado a mensagem de cobraça. No final e removido o registro
                        // Sim.Faça isso
                        //CobrancaServicos CobrancasSegunda = new CobrancaServicos(codigoJornada, boleto, FrmboletoAcao);
                        //await CobrancasSegunda.SalvarDadosEmTableEspera();
                    }
                    else
                    {
                        // Verifica se o dia de hoje é segunda-feira
                        var eSegunda = DateTime.Now.DayOfWeek == DayOfWeek.Monday;

                        //Verifica se o dia em atraso [e 6 e se é segunda, caso seja significa que ele tentou cobrar do dia 5 no fim de semana
                        // Então deve ser cobrado primeiro os do 5 dias e depois do dia 6
                        if (diasAtraso == 6 && eSegunda)
                        {
                            //await CobrancasNaSegunda.CobrarAtraso5Dias(codigoJornada, DadosAPI, dalBoleto, boleto);
                            AtualizarAcaoNoCRM(diasAtraso, codigoJornada, DadosAPI, dalBoleto, boleto, false, true);
                        }
                        else
                        {
                            AtualizarAcaoNoCRM(diasAtraso, codigoJornada, DadosAPI, dalBoleto, boleto, false, true);

                        }
                    }
                }
            }
            else
            {
                // Se o dia de atraso não é um dos significativos, registrar no log
                MetodosGerais.RegistrarLog("BOLETO", $"Boleto não está em atraso significativo.");
            }
        }

        #endregion

        #region Metodo API

        // Método auxiliar para enviar requisição de criação de oportunidade para a API
        internal static async Task<OportunidadeResponse> EnviarRequisicaoCriarOportunidade(ModeloOportunidadeRequest request, string token)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var json = JsonConvert.SerializeObject(request);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                try
                {
                    MetodosGerais.RegistrarLog("BOLETO", "Enviando requisição para criar oportunidade no CRM...");

                    var response = await client.PostAsync("https://api.leadfinder.com.br/integracao/v2/inserirOportunidade", content);
                    var responseBody = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        MetodosGerais.RegistrarLog("BOLETO", "Resposta OK - Oportunidade criada no CRM");
                        return JsonConvert.DeserializeObject<OportunidadeResponse>(responseBody);
                    }

                    MetodosGerais.RegistrarLog("BOLETO", $"Erro na resposta da API: Status {response.StatusCode} - {responseBody}");
                }
                catch (HttpRequestException ex)
                {
                    MetodosGerais.RegistrarLog("BOLETO", $"Erro de rede ao chamar API: {ex.Message}");
                    throw;
                }
                catch (Exception ex)
                {
                    MetodosGerais.RegistrarLog("BOLETO", $"Exceção ao processar resposta da API: {ex.Message}");
                    throw;
                }

                return null;
            }
        }

        // Método auxiliar para adicionar o boleto no banco de dados
        internal static async Task AdicionarBoletoNoBanco(DAL<RelacaoBoletoCRMModel> dalTableRelacaoBoleto, RelacaoBoletoCRMModel boletoInTabRel, string codigoOportunidade)
        {
            boletoInTabRel.Cod_Oportunidade = codigoOportunidade;
            boletoInTabRel.Data_Criacao = DateTime.Now;

            using (var dalBoletoUsing = new DAL<RelacaoBoletoCRMModel>(new IntegradorDBContext()))
            {
                await dalBoletoUsing.AdicionarAsync(boletoInTabRel);
            }
        }

        internal static async Task<OportunidadeResponse> AtualizarOportunidadeNaApi(AtualizarAcaoRequest request, string token)
        {
            // configurar o cabeçalho de autorização 
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var json = JsonConvert.SerializeObject(request);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                try
                {
                    var response = await client.PostAsync("https://api.leadfinder.com.br/integracao/movimentarOportunidade", content);
                    var responseBody = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        MetodosGerais.RegistrarLog("BOLETO", "Resposta OK - Oportunidade Atualizada no CRM");
                        return JsonConvert.DeserializeObject<OportunidadeResponse>(responseBody);
                    }

                    MetodosGerais.RegistrarLog("BOLETO", $"Erro na resposta da API: Status {response.StatusCode} - {responseBody}");
                }
                catch (HttpRequestException ex)
                {
                    MetodosGerais.RegistrarLog("BOLETO", $"Erro de rede ao chamar API: {ex.Message}");
                    throw;
                }
                catch (Exception ex)
                {
                    MetodosGerais.RegistrarLog("BOLETO", $"Exceção ao processar resposta da API: {ex.Message}");
                    throw;
                }

                return null;
            }
        }

        // Método auxiliar para atualizar boleto no banco
        internal static async Task AtualizarBoletoNoBanco(RelacaoBoletoCRMModel boletoRelacao)
        {
            boletoRelacao.Data_Atualizacao = DateTime.Now;

            using (var dalBoletoUsing = new DAL<RelacaoBoletoCRMModel>(new IntegradorDBContext()))
            {
                await dalBoletoUsing.AtualizarAsync(boletoRelacao);
            }
        }

        // Metodo Recebe Boletos que tenham sido quitados, o boleto será excluido da tabela de cobrança de fim de semana caso tenha
        internal static async Task ProcessarBoletoQuitado(RelacaoBoletoCRMModel boletoRelacao)
        {
            var cobrancas = new CobrancasNaSegundaModel();
            //await cobrancas.RemoverRegistro(boletoRelacao.Id, true);
            MetodosGerais.RegistrarLog("BOLETO", $"Situação atualizada para {boletoRelacao.Situacao} para o documento {boletoRelacao.Id_DocumentoReceber}");
        }

        #endregion
    }
}
