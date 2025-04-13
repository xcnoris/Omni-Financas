using System.Net.Http.Headers;
using Aplication.IntegradorCRM.Servicos.OS;
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
        // Metodo responsavel apenas para enviar Mensagem para o cliente
        public static async Task<bool> EnviarMensagemViaAPI(ModeloOportunidadeRequest request, DadosAPIModels DadosAPI)
        {
            using (HttpClient client = OS_Services.ConfigurarHttpClient(DadosAPI.Token))
            {
                //// Correto: adiciona a chave apikey no header
                //client.DefaultRequestHeaders.Add("apikey", DadosAPI.Token);
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                // Definir URL do endpoint da Evolution API
                string url = $"https://n8n-evolution-api.usbaxy.easypanel.host/message/sendText/{DadosAPI.Instancia}";

                try
                {
                    // Executando metodo Http Post
                    HttpContent content = MetodosGerais.CriarConteudoJson(request);
                    HttpResponseMessage response = await client.PostAsync(url, content);
                    
                    string responseBody = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }
                    else
                    {
                        OS_Services.RegistrarErroResposta(response, request.number);
                        return false;
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
