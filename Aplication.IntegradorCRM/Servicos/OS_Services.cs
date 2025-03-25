
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
      
        
        public static async Task EnviarMensagemCriacao(DadosAPIModels DadosAPI, string Celular, RelacaoOrdemServicoModels tableRelacaoOS, DAL<RelacaoOrdemServicoModels> dalRelacaoOS)
        {
            ModeloOportunidadeRequest oportunidade = await InstanciarAcaoRequestSitucaoOS(Situacao_OS.Criacao, Celular);

            await OrdemServicoRequests.EnviarMensagemViaAPI(oportunidade, DadosAPI, tableRelacaoOS, dalRelacaoOS);
        }
       

        public static async Task<ModeloOportunidadeRequest> InstanciarAcaoRequestSitucaoOS(Situacao_OS SitOS, string CelularCliente)
        {
          
            using DAL<AcaoSituacao_OS_CRM> dalAcaoOS = new DAL<AcaoSituacao_OS_CRM>(new IntegradorDBContext());
            AcaoSituacao_OS_CRM? AcaoSitOS = await dalAcaoOS.BuscarPorAsync(x => x.Situacao.Equals(((int)SitOS)));

            if (AcaoSitOS is not null)
            {

                return new ModeloOportunidadeRequest()
                {
                    Numero = CelularCliente,
                    Mensagem = AcaoSitOS.Mensagem
                };
            }
            return null;

        }


        public static async Task<ModeloOportunidadeRequest> InstanciarAcaoRequest(int idCategoria, string CelularCliente)
        {
            using DAL<OSAcoesCRMModel> dalAcaoOS = new DAL<OSAcoesCRMModel>(new IntegradorDBContext());
            OSAcoesCRMModel? AcoesOS = await dalAcaoOS.BuscarPorAsync(x => x.IdCategoria == idCategoria);

            if (AcoesOS is null)
            {
                return null;
            }

            return new ModeloOportunidadeRequest()
            {
                Numero = CelularCliente,
                Mensagem = AcoesOS.Mensagem_Atualizacao
            };
        }

        public async static Task VerificarOSEntrada(int idCategoria, List<OSAcoesCRMModel> OSAcoes, DadosAPIModels DadosAPI, RelacaoOrdemServicoModels RelOSModel, DAL<RelacaoOrdemServicoModels> dalRelOSModel) 
        {
            if (!(idCategoria is 1))
            {
                OSAcoesCRMModel? OSModel = OSAcoes.FirstOrDefault(a => a.IdCategoria == idCategoria);

                if (OSModel is null)
                {
                    MetodosGerais.RegistrarLog("OS", $"Error: Ação do CRM correspondende para categoria {idCategoria} não cadastrada!");
                    return;
                }

                // Instancia a ser enviado para atualizar a etapa da oportunidade no CRM
                ModeloOportunidadeRequest AtualizarAcao = await InstanciarAcaoRequest(idCategoria, OSModel.Mensagem_Atualizacao);
                  
                // Atualize a categoria na tabela de relação se necessário
                RelacaoOrdemServicoModels TableRelacao = await dalRelOSModel.BuscarPorAsync(x => x.Id_OrdemServico == RelOSModel.Id_OrdemServico);

                await OrdemServicoRequests.AtualizarAcao(AtualizarAcao, DadosAPI, TableRelacao);
               

            }
        }


        public async static Task<ModeloOportunidadeRequest?> BuscarAcaoSituacao(Situacao_OS situacaoOS, string Id_OS, string Numero)
        {
            DAL<AcaoSituacao_OS_CRM> AcaoSituacaoOS = new DAL<AcaoSituacao_OS_CRM>(new IntegradorDBContext());
            ModeloOportunidadeRequest? oSAcoesCRMModel = null;

            try
            {
                AcaoSituacao_OS_CRM? acaoBuscada = await AcaoSituacaoOS.BuscarPorAsync(x => x.Situacao.Equals(situacaoOS));

                if (acaoBuscada == null)
                {
                    MetodosGerais.RegistrarLog("OS", $"[ERROR] Nenhuma Ação de Situação encontrada para a situação {situacaoOS}. OS: {Id_OS}");
                    return null; // Retorna null caso a ação não seja encontrada
                }

                oSAcoesCRMModel = new ModeloOportunidadeRequest
                {
                    Numero = "55" + Numero,
                    Mensagem = acaoBuscada.Mensagem
                };
            }
            catch (Exception ex)
            {
                MetodosGerais.RegistrarLog("OS", $"Erro ao buscar ação de situação para a OS {Id_OS}: {ex.Message}");
            }

            return oSAcoesCRMModel;
        }

        public async static Task<ModeloOportunidadeRequest?> InstanciarOSAcoes(int Situacao, RetornoOrdemServico RetornoOS, List<OSAcoesCRMModel> osAcoesCRM)
        {
            // Verifica se a Situacao é 1, caso seja, signica que esta cancelado a OS, e busca pelo ação -1
            ModeloOportunidadeRequest? OSModel;

            if ((Situacao_OS)Situacao is Situacao_OS.Cancelada)
            {
                return OSModel = await BuscarAcaoSituacao(Situacao_OS.Cancelada, RetornoOS.Id_Ordem_Servico, RetornoOS.Telefone);
            }
            else
            {
                return OSModel = await InstanciarAcaoRequest(Convert.ToInt32(RetornoOS.Id_CategoriaOS), RetornoOS.Telefone);
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

      

        internal static async Task ProcessarRespostaSucesso( RelacaoOrdemServicoModels tableRelacaoOS, DAL<RelacaoOrdemServicoModels> dalRelacaoOS)
        {
            //OportunidadeResponse resposta = JsonConvert.DeserializeObject<OportunidadeResponse>(responseBody);

            MetodosGerais.RegistrarLog("OS", "Resposta OK - Oportunidade criada no CRM:");
            

            // Atualizar TableRelacaoOS e salvar no banco
            tableRelacaoOS.Data_Criacao = DateTime.Now;

            // Adicionar a nova entrada ao banco
            await dalRelacaoOS.AdicionarAsync(tableRelacaoOS);
          
        }

        internal static void RegistrarErroResposta(HttpResponseMessage response, string mensagem)
        {
            MetodosGerais.RegistrarLog("OS", "Erro na resposta da API:");
            MetodosGerais.RegistrarLog("OS", $"Status Code: {response.StatusCode}");
            MetodosGerais.RegistrarLog("OS", mensagem);
        }

        internal static async Task ProcessarRespostaAtualizacao(string responseBody, RelacaoOrdemServicoModels tableRelacaoOS, DAL<RelacaoOrdemServicoModels> dalRelacaoOS)
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

                if(tableRelacaoOS.Situacao is not 1)
                {
                    MetodosGerais.RegistrarLog("OS", $"Categoria atualizada para {tableRelacaoOS.Id_CategoriaOS} na tabela de relação para a OS {tableRelacaoOS.Id_OrdemServico}.");
                }
            }
            else
            {
                MetodosGerais.RegistrarLog("OS", $"Erro na resposta: resposta desserializada é nula. OS: {tableRelacaoOS.Id_CategoriaOS}");
            }

        }

        #endregion
    }
}
