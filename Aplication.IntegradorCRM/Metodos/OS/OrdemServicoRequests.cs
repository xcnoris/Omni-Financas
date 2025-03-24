using Aplication.IntegradorCRM.Servicos;
using DataBase.IntegradorCRM.Data;
using Metodos.IntegradorCRM.Metodos;
using Modelos.IntegradorCRM.Models;
using Modelos.IntegradorCRM.Models.EF;
using Modelos.IntegradorCRMRM.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Aplication.IntegradorCRM.Metodos.OS
{
    internal class OrdemServicoRequests
    {

        public static async Task EnviarMensagemViaAPI(ModeloOportunidadeRequest request, DadosAPIModels DadosAPI, RelacaoOrdemServicoModels tableRelacaoOS, DAL<RelacaoOrdemServicoModels> dalRelacaoOS)
        {
            using (HttpClient client = OS_Services.ConfigurarHttpClient(DadosAPI.Token))
            {
                // Configurar o cabeçalho de autenticação
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", DadosAPI.Token);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                // Definir URL do endpoint da Evolution API
                string url = $"https://api.evolution.com/message/sendText/{DadosAPI.Instancia}";

                HttpContent content = OS_Services.CriarConteudoJson(request);

               

                try
                {
                    MetodosGerais.RegistrarLog("OS", "Criando Oportunidade no CRM....");
                    HttpResponseMessage response = await client.PostAsync(url, content);

                    //string responseBody = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        await OS_Services.ProcessarRespostaSucesso( tableRelacaoOS, dalRelacaoOS);
                    }
                    else
                    {
                        OS_Services.RegistrarErroResposta(response, $"Id OS: {tableRelacaoOS.Id_OrdemServico}");
                    }
                }
                catch (Exception ex)
                {
                    MetodosGerais.RegistrarErroExcecao("OS", "Exceção durante a chamada da API:", ex);
                    throw;
                }

            }
        }

        public static async Task AtualizarAcao(ModeloOportunidadeRequest request, DadosAPIModels DadosAPI, RelacaoOrdemServicoModels TableRelacaoOS)
        {

            using (HttpClient client = OS_Services.ConfigurarHttpClient(DadosAPI.Token))
            {
                // Configurar o cabeçalho de autenticação
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", DadosAPI.Token);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                // Definir URL do endpoint da Evolution API
                string url = $"https://api.evolution.com/message/sendText/{DadosAPI.Instancia}";

                HttpContent content = OS_Services.CriarConteudoJson(request);

                using var dalRelacaoOS = new DAL<RelacaoOrdemServicoModels>(new IntegradorDBContext());


                try
                {
                    HttpResponseMessage response = await client.PostAsync(url, content);
                    string responseBody = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        await OS_Services.ProcessarRespostaAtualizacao(responseBody, TableRelacaoOS, dalRelacaoOS);
                    }
                    else
                    {
                        OS_Services.RegistrarErroResposta(response, $"Id OS: {TableRelacaoOS.Id_OrdemServico} - {responseBody}");
                    }
                }
                catch (Exception ex)
                {
                    MetodosGerais.RegistrarErroExcecao("OS", "Exceção durante a chamada da API:", ex);
                    throw;
                }

            }
        }
    }
}
