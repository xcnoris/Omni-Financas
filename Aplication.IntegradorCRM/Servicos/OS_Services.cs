
using Aplication.IntegradorCRM.Metodos.OS;
using DataBase.IntegradorCRM.Data;
using Metodos.IntegradorCRM.Metodos;
using Modelos.IntegradorCRM.Models;
using Modelos.IntegradorCRM.Models.EF;
using Modelos.IntegradorCRM.Models.Enuns;
using Modelos.IntegradorCRMRM.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace Aplication.IntegradorCRM.Servicos
{
    internal class OS_Services
    {
        #region Metodos Gerais
        internal static ModeloOportunidadeRequest InstanciarModelOportunidadeReq(DadosAPIModels DadosAPI, RetornoOrdemServico RetornoOS)
        {
            return new ModeloOportunidadeRequest
            {

                //codigoApi = "4B29E80B1A",
                codigoApi = DadosAPI.Cod_API_OrdemServico,
                codigoOportunidade = "",
                origemOportunidade = "Lojamix - Consumo API",
                lead = new Lead
                {
                    nomeLead = $"{RetornoOS.Id_Ordem_Servico} - {RetornoOS.Nome_Cliente}",
                    telefoneLead = RetornoOS.Telefone,
                    emailLead = RetornoOS.Email_Cliente,
                    cnpjLead = "",
                    origemLead = "Serviço de consumo de API",
                    contatos = new List<Contato>
                    {
                        new Contato
                        {
                            nomeContato = RetornoOS.Nome_Cliente,
                            telefoneContato = RetornoOS.Telefone,
                            emailContato = RetornoOS.Email_Cliente
                        }
                    },
                },
                followups = new List<Followup>
                {
                    new Followup { textoFollowup = "Essa oportunidade foi criada a partir da API de integração da LeadFinder" }
                }
            };
        }
        
        public static AtualizarAcaoRequest InstanciarAcaoRequest(OSAcoesCRMModel OSModel, string cod_oportunidade,string codigoJornada)
        {
            return new AtualizarAcaoRequest
            {
                codigoOportunidade = cod_oportunidade,
                codigoAcao = OSModel.Codigo_Acao,
                codigoJornada = codigoJornada,
                textoFollowup = OSModel.Mensagem_Atualizacao
            };
        }

        public async static Task VerificarOSEntrada(int idCategoria, OportunidadeResponse OptnResponse, List<OSAcoesCRMModel> OSAcoes, DadosAPIModels DadosAPI, RelacaoOrdemServicoModels RelOSModel, DAL<RelacaoOrdemServicoModels> dalRelOSModel) 
        {
            if (!(idCategoria is 1))
            {
                string cod_oportunidade = OptnResponse.CodigoOportunidade;
                OSAcoesCRMModel? OSModel = OSAcoes.FirstOrDefault(a => a.Id == idCategoria);

                if (OSModel is null)
                {
                    MetodosGerais.RegistrarLog("OS", $"Error: Ação do CRM correspondende para categoria {idCategoria} não cadastrada!");
                    return;
                }
                
                // Instancia a ser enviado para atualizar a etapa da oportunidade no CRM
                AtualizarAcaoRequest AtualizarAcao = InstanciarAcaoRequest(OSModel, cod_oportunidade, DadosAPI.Cod_Jornada_OrdemServico);
                  
                RelOSModel.Cod_Oportunidade = cod_oportunidade;
                // Atualize a categoria na tabela de relação se necessário
                RelacaoOrdemServicoModels TableRelacao = await dalRelOSModel.BuscarPorAsync(x => x.Id_OrdemServico == RelOSModel.Id_OrdemServico);

                await EnviarOrdemServiçoForCRM.AtualizarAcao(AtualizarAcao, DadosAPI.Token, TableRelacao);
               

            }
        }

        public async static Task<OSAcoesCRMModel?> BuscarAcaoSituacao(Situacao_OS situacaoOS, string Id_OS)
        {
            DAL<AcaoSituacao_OS_CRM> AcaoSituacaoOS = new DAL<AcaoSituacao_OS_CRM>(new IntegradorDBContext());
            OSAcoesCRMModel? oSAcoesCRMModel = null;

            try
            {
                AcaoSituacao_OS_CRM? acaoBuscada = await AcaoSituacaoOS.BuscarPorAsync(x => x.Situacao.Equals(situacaoOS));

                if (acaoBuscada == null)
                {
                    MetodosGerais.RegistrarLog("OS", $"Nenhuma Ação de Situação encontrada para a situação {situacaoOS}. OS: {Id_OS}");
                    return null; // Retorna null caso a ação não seja encontrada
                }

                oSAcoesCRMModel = new OSAcoesCRMModel
                {
                    Codigo_Acao = acaoBuscada.CodAcaoCRM,
                    Mensagem_Atualizacao = acaoBuscada.Mensagem_Acao
                };
            }
            catch (Exception ex)
            {
                MetodosGerais.RegistrarLog("OS", $"Erro ao buscar ação de situação para a OS {Id_OS}: {ex.Message}");
            }

            return oSAcoesCRMModel;
        }

        public async static Task<OSAcoesCRMModel?> InstanciarOSAcoes(int Situacao, string Id_OS, string IdCategoria, List<OSAcoesCRMModel> osAcoesCRM)
        {
            // Verifica se a Situacao é 1, caso seja, signica que esta cancelado a OS, e busca pelo ação -1
            OSAcoesCRMModel? OSModel;

            if (Situacao is 1)
            {
                return OSModel = await BuscarAcaoSituacao(Situacao_OS.Cancelada, Id_OS);
            }
            else
            {
                return OSModel = osAcoesCRM.FirstOrDefault(x => x.IdCategoria == Convert.ToInt32(IdCategoria));
            }
        }

        #endregion

        #region Metodos API
        internal static HttpClient ConfigurarHttpClient(string token)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", token);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }

        internal static HttpContent CriarConteudoJson(object data)
        {
            string json = JsonConvert.SerializeObject(data);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }

        internal static async Task<OportunidadeResponse> ProcessarRespostaSucesso(string responseBody, RelacaoOrdemServicoModels tableRelacaoOS, DAL<RelacaoOrdemServicoModels> dalRelacaoOS)
        {
            OportunidadeResponse resposta = JsonConvert.DeserializeObject<OportunidadeResponse>(responseBody);

            if (resposta != null)
            {
                MetodosGerais.RegistrarLog("OS", "Resposta OK - Oportunidade criada no CRM:");
                MetodosGerais.RegistrarLog("OS", responseBody);

                // Atualizar TableRelacaoOS e salvar no banco
                tableRelacaoOS.Cod_Oportunidade = resposta.CodigoOportunidade;
                tableRelacaoOS.Data_Criacao = DateTime.Now;

                // Adicionar a nova entrada ao banco
                await dalRelacaoOS.AdicionarAsync(tableRelacaoOS);
            }
            else
            {
                MetodosGerais.RegistrarLog("OS", "Erro na resposta: resposta desserializada é nula.");
            }

            return resposta;
        }

        internal static void RegistrarErroResposta(HttpResponseMessage response, string mensagem)
        {
            MetodosGerais.RegistrarLog("OS", "Erro na resposta da API:");
            MetodosGerais.RegistrarLog("OS", $"Status Code: {response.StatusCode}");
            MetodosGerais.RegistrarLog("OS", mensagem);
        }

        internal static async Task<OportunidadeResponse> ProcessarRespostaAtualizacao(string responseBody, RelacaoOrdemServicoModels tableRelacaoOS, DAL<RelacaoOrdemServicoModels> dalRelacaoOS)
        {
            OportunidadeResponse resposta = JsonConvert.DeserializeObject<OportunidadeResponse>(responseBody);

            if (resposta != null)
            {
                MetodosGerais.RegistrarLog("OS", "Resposta OK - Oportunidade Atualizada no CRM:");
                MetodosGerais.RegistrarLog("OS", responseBody);

                // Atualizar Data_Alteracao e salvar no banco
                tableRelacaoOS.Data_Alteracao = DateTime.Now;

                // Atualizar a entrada no banco
                await dalRelacaoOS.AtualizarAsync(tableRelacaoOS);

                MetodosGerais.RegistrarLog("OS", $"Categoria atualizada para {tableRelacaoOS.Id_CategoriaOS} na tabela de relação para a OS {tableRelacaoOS.Id_OrdemServico}.");
            }
            else
            {
                MetodosGerais.RegistrarLog("OS", $"Erro na resposta: resposta desserializada é nula. OS: {tableRelacaoOS.Id_CategoriaOS}");
            }

            return resposta;
        }

        #endregion
    }
}
