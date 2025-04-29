using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Aplication.IntegradorCRM.Servicos.Boleto;
using Metodos.IntegradorCRM.Metodos;
using System.Net.Http.Json;

namespace Aplication.IntegradorCRM.Metodos.Boleto
{
    internal class EnviarPDFBoleto
    {
        private static readonly HttpClient _httpClient;

        static EnviarPDFBoleto()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
            _httpClient = new HttpClient(handler);
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static async Task<bool> ProcessarEnvioPDFBoleto(int idDocumentoReceber, string Token, string destinatario, string dataVencimentoBoleto, string InstanciaEnvoluctionAPI)
        {
            string linkBoleto = await GerarLinkDoPDFReposOnline(idDocumentoReceber, Token, dataVencimentoBoleto);
            if (string.IsNullOrEmpty(linkBoleto)) return false;

            return await EnviarPDFBoletoNoWhatsapp(linkBoleto, destinatario, Token, idDocumentoReceber, dataVencimentoBoleto, InstanciaEnvoluctionAPI);
        }

        public static async Task<string> GerarLinkDoPDFReposOnline(int idDocumentoReceber, string Token, string dataVencimentoBoleto)
        {
            if (idDocumentoReceber <= 0)
            {
                MetodosGerais.RegistrarLog("BOLETO_PDF", $"Parâmetros inválidos para Envio do PDF do Boleto. DR: {idDocumentoReceber}");
                return null;
            }

            var boletoPDFService = new BoletoPDF_Services();
            string caminhoBoleto = boletoPDFService.ConsultarCaminhoBoleto(idDocumentoReceber);
            if (string.IsNullOrEmpty(caminhoBoleto))
            {
                MetodosGerais.RegistrarLog("BOLETO_PDF", $"Caminho do boleto não encontrado. DR: {idDocumentoReceber}");
                return null;
            }

            string boletoBase64 = boletoPDFService.ConverterPDFParaBase64(caminhoBoleto);
            if (string.IsNullOrEmpty(boletoBase64))
            {
                MetodosGerais.RegistrarLog("BOLETO_PDF", $"Erro ao converter o boleto para Base64. DR: {idDocumentoReceber}");
                return null;
            }

            var payload = new
            {
                cnpj = "07446072000106",
                username = "admin",
                password = "senha123",
                fileName = $"Boleto_{dataVencimentoBoleto}_{idDocumentoReceber}.pdf",
                base64 = boletoBase64
            };

            string jsonPayload = JsonConvert.SerializeObject(payload);

            try
            {
                var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");
                string url = "http://212.85.17.216:5007/api/BoletoPDF/upload";
              
                

                for (int tentativa = 1; tentativa <= 3; tentativa++)
                {
                    try
                    {
                        HttpResponseMessage response = await _httpClient.PostAsync(url, content);
                        string responseContent = await response.Content.ReadAsStringAsync();
                        if (response.IsSuccessStatusCode)
                        {
                            var jsonDoc = JsonDocument.Parse(responseContent);
                            string urlRetornada = jsonDoc.RootElement.GetProperty("url").GetString();
                            MetodosGerais.RegistrarLog("BOLETO_PDF", $"Caminho DR {idDocumentoReceber}: {responseContent.Trim()} ");
                            return urlRetornada?.Trim();
                        }
                        MetodosGerais.RegistrarLog("BOLETO_PDF", $"Tentativa {tentativa} - Falha ao enviar. Status: {response.StatusCode}. DR: {idDocumentoReceber}. Json: {responseContent}");
                    }
                    catch (HttpRequestException ex)
                    {
                        MetodosGerais.RegistrarLog("BOLETO_PDF", $"Tentativa {tentativa} - Erro HTTP: {ex.Message} | Inner: {ex.InnerException?.Message}");
                    }
                    await Task.Delay(1000 * tentativa);
                }
                return "";
             
            }
            catch (Exception ex)
            {
                MetodosGerais.RegistrarLog("BOLETO_PDF", $"Erro ao enviar PDF do boleto: {ex.Message}. DR {idDocumentoReceber}");
                return null;
            }
        }

        public static async Task<bool> EnviarPDFBoletoNoWhatsapp(string linkBoleto, string destinatario, string Token, int idDocumentoReceber, string dataVencimentoBoleto, string Instancia)
        {
            if (string.IsNullOrWhiteSpace(linkBoleto) || string.IsNullOrWhiteSpace(destinatario) || string.IsNullOrWhiteSpace(Instancia))
            {
                MetodosGerais.RegistrarLog("BOLETO_PDF", "Parâmetros inválidos para envio de mensagem.");
                return false;
            }

            var payload = new
            {
                number = destinatario,
                mediatype = "document",
                mimetype = "image/pdf",
                caption = "Segue o seu boleto!",
                media = linkBoleto,
                fileName = $"BOLETO_{dataVencimentoBoleto}.pdf"
            };

            try
            {
                _httpClient.DefaultRequestHeaders.Remove("apikey");
                _httpClient.DefaultRequestHeaders.Add("apikey", Token);

                string url = $"https://n8n-evolution-api.usbaxy.easypanel.host/message/sendMedia/{Instancia}";
                HttpContent content = MetodosGerais.CriarConteudoJson(payload);
                string jsonContent = await content.ReadAsStringAsync();

                for (int tentativa = 1; tentativa <= 3; tentativa++)
                {
                    try
                    {
                        HttpResponseMessage response = await _httpClient.PostAsync(url, content);
                        if (response.IsSuccessStatusCode)
                        {
                            MetodosGerais.RegistrarLog("BOLETO_PDF", $"Boleto em PDF enviado com sucesso por WhatsApp! DR: {idDocumentoReceber}");
                            return true;
                        }
                        MetodosGerais.RegistrarLog("BOLETO_PDF", $"Tentativa {tentativa} - Falha ao enviar. Status: {response.StatusCode}. DR: {idDocumentoReceber}. Json: {jsonContent}");
                    }
                    catch (HttpRequestException ex)
                    {
                        MetodosGerais.RegistrarLog("BOLETO_PDF", $"Tentativa {tentativa} - Erro HTTP: {ex.Message} | Inner: {ex.InnerException?.Message}");
                    }
                    await Task.Delay(1000 * tentativa);
                }
            }
            catch (Exception ex)
            {
                MetodosGerais.RegistrarLog("BOLETO_PDF", $"Erro ao enviar mensagem: {ex.Message}");
            }

            return false;
        }
    }
}