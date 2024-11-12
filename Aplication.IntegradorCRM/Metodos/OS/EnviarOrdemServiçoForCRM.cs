using Aplication.IntegradorCRM.Servicos;
using DataBase.IntegradorCRM.Data;
using Metodos.IntegradorCRM.Metodos;
using Modelos.IntegradorCRM.Models;
using Modelos.IntegradorCRM.Models.EF;
using Modelos.IntegradorCRMRM.Models;

namespace Aplication.IntegradorCRM.Metodos.OS
{
    internal class EnviarOrdemServiçoForCRM
    {

        public static async Task<OportunidadeResponse> EnviarOportunidade(ModeloOportunidadeRequest request, string token, RelacaoOrdemServicoModels tableRelacaoOS, DAL<RelacaoOrdemServicoModels> dalRelacaoOS)
        {
            using (HttpClient client = OS_Services.ConfigurarHttpClient(token))
            {
                string url = "https://api.leadfinder.com.br/integracao/v2/inserirOportunidade";
                HttpContent content = OS_Services.CriarConteudoJson(request);

                try
                {
                    MetodosGerais.RegistrarLog("OS", "Criando Oportunidade no CRM....");
                    HttpResponseMessage response = await client.PostAsync(url, content);
                    string responseBody = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        return await OS_Services.ProcessarRespostaSucesso(responseBody, tableRelacaoOS, dalRelacaoOS);
                    }
                    else
                    {
                        OS_Services.RegistrarErroResposta(response, responseBody);
                    }
                }
                catch (Exception ex)
                {
                    MetodosGerais.RegistrarErroExcecao("OS", "Exceção durante a chamada da API:", ex);
                    throw;
                }

                return null;
            }
        }

        public static async Task<OportunidadeResponse> AtualizarAcao(AtualizarAcaoRequest request, string token, RelacaoOrdemServicoModels TableRelacaoOS, DAL<RelacaoOrdemServicoModels> dalRelacaoOS)
        {
            using (HttpClient client = OS_Services.ConfigurarHttpClient(token))
            {
                string url = "https://api.leadfinder.com.br/integracao/movimentarOportunidade";
                HttpContent content = OS_Services.CriarConteudoJson(request);

                try
                {
                    HttpResponseMessage response = await client.PostAsync(url, content);
                    string responseBody = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        return await OS_Services.ProcessarRespostaAtualizacao(responseBody, TableRelacaoOS, dalRelacaoOS);
                    }
                    else
                    {
                        OS_Services.RegistrarErroResposta(response, responseBody);
                    }
                }
                catch (Exception ex)
                {
                    MetodosGerais.RegistrarErroExcecao("OS", "Exceção durante a chamada da API:", ex);
                    throw;
                }

                return null;
            }
        }
    }
}
