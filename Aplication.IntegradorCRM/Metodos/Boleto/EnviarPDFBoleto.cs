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
            string Base64Boleto = await GerarBase64DoPDF(idDocumentoReceber, Token, dataVencimentoBoleto);
            if (string.IsNullOrEmpty(Base64Boleto)) return false;

            return await EnviarPDFBoletoNoWhatsapp(Base64Boleto, destinatario, Token, idDocumentoReceber, dataVencimentoBoleto, InstanciaEnvoluctionAPI);
        }

        public static async Task<string> GerarBase64DoPDF(int idDocumentoReceber, string Token, string dataVencimentoBoleto)
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
            return boletoBase64;
        }

        public static async Task<bool> EnviarPDFBoletoNoWhatsapp(string base64Boleto, string destinatario, string Token, int idDocumentoReceber, string dataVencimentoBoleto, string Instancia)
        {
            if (string.IsNullOrWhiteSpace(base64Boleto) || string.IsNullOrWhiteSpace(destinatario) || string.IsNullOrWhiteSpace(Instancia))
            {
                MetodosGerais.RegistrarLog("BOLETO_PDF", "Parâmetros inválidos para envio de mensagem.");
                return false;
            }

            var payload = new
            {
                number = destinatario,
                mediatype = "document",
                mimetype = "application/pdf",
                caption = "Segue o seu boleto!",
                media = base64Boleto,
                fileName = $"BOLETO_{dataVencimentoBoleto}.pdf"
            };

            try
            {
                _httpClient.DefaultRequestHeaders.Remove("apikey");
                _httpClient.DefaultRequestHeaders.Add("apikey", Token);

                string url = $"https://cdi-omni-evolution-api.azvg4h.easypanel.host/message/sendMedia/{Instancia}";
                HttpContent content = MetodosGerais.CriarConteudoJson(payload);
                string jsonContent = await content.ReadAsStringAsync();

                for (int tentativa = 1; tentativa <= 5; tentativa++)
                {
                    try
                    {
                        HttpResponseMessage response = await _httpClient.PostAsync(url, content);
                        if (response.IsSuccessStatusCode)
                        {
                            MetodosGerais.RegistrarLog("BOLETO_PDF", $"Tentativa {tentativa} - Boleto em PDF enviado com sucesso por WhatsApp! DR: {idDocumentoReceber}");
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