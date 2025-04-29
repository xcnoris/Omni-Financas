using System.Net;
using System.Net.Http.Headers;
using Aplication.IntegradorCRM.Servicos.OS;
using Metodos.IntegradorCRM.Metodos;
using Modelos.IntegradorCRM.Models.EF;
using Modelos.IntegradorCRMRM.Models;

namespace Aplication.IntegradorCRM.Metodos.OS
{
    internal class OrdemServicoRequests
    {
        private static readonly HttpClient _httpClient;

        static OrdemServicoRequests()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
            _httpClient = new HttpClient(handler);
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        // Metodo responsavel apenas para enviar Mensagem para o cliente
        public static async Task<bool> EnviarMensagemViaAPI(ModeloOportunidadeRequest request, DadosAPIModels DadosAPI)
        {
            string url = $"https://n8n-evolution-api.usbaxy.easypanel.host/message/sendText/{DadosAPI.Instancia}";
            HttpContent content = MetodosGerais.CriarConteudoJson(request);
            string jsonContent = await content.ReadAsStringAsync();

            for (int tentativa = 1; tentativa <= 3; tentativa++)
            {
                try
                {
                    _httpClient.DefaultRequestHeaders.Remove("apikey");
                    _httpClient.DefaultRequestHeaders.Add("apikey", DadosAPI.Token);

                    HttpResponseMessage response = await _httpClient.PostAsync(url, content);
                    string responseBody = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        MetodosGerais.RegistrarLog("OS", $"Tentativa {tentativa} - JSON enviado: {jsonContent}");
                        return true;
                    }
                    else
                    {
                        OS_Services.RegistrarErroResposta(response, request.number);
                        MetodosGerais.RegistrarLog("DEBUG", $"Tentativa {tentativa} - JSON enviado: {jsonContent}");
                    }
                }
                catch (HttpRequestException ex)
                {
                    MetodosGerais.RegistrarLog("OS", $"Tentativa {tentativa} - Erro de rede: {ex.Message} | Inner: {ex.InnerException?.Message}");
                }
                catch (Exception ex)
                {
                    MetodosGerais.RegistrarErroExcecao("OS", $"Tentativa {tentativa} - Exceção durante a chamada da API:", ex);
                }

                await Task.Delay(1000 * tentativa);
            }

            return false;
        }
    }
}
