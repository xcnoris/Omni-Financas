
using System;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using Aplication.IntegradorCRM.Servicos.Boleto;
using Azure.Core;
using Metodos.IntegradorCRM.Metodos;
using Newtonsoft.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Aplication.IntegradorCRM.Metodos.Boleto
{
    internal class EnviarPDFBoleto
    {
        public static async Task<bool> ProcessarEnvioPDFBoleto(int idDocumentoReceber, string Token, string destinatario,string dataVencimentoBoleto, string InstanciaEnvoluctionAPI)
        {
            string linkBoleto = await GerarLinkDoPDFReposOnline(idDocumentoReceber, Token, dataVencimentoBoleto);

            if (string.IsNullOrEmpty(linkBoleto))
                return false;
            return await EnviarPDFBoletoNoWhatsapp(linkBoleto, destinatario, Token, idDocumentoReceber, dataVencimentoBoleto, InstanciaEnvoluctionAPI);

        }
        public static async Task<string> GerarLinkDoPDFReposOnline(int idDocumentoReceber, string Token, string dataVencimentoBoleto)
        {
            // Validar dados de entrada
            if (idDocumentoReceber <= 0)
            {
                MetodosGerais.RegistrarLog("BOLETO_PDF", $"Parâmetros inválidos para Envio do PDF do Boleto. DR: {idDocumentoReceber}");
                throw new ArgumentException("Parâmetros inválidos para Envio do PDF do Boleto.");
            }

            // Criar o serviço para manipulação do PDF
            BoletoPDF_Services boletoPDFService = new BoletoPDF_Services();

            // Consultar o caminho do boleto
            string caminhoBoleto = boletoPDFService.ConsultarCaminhoBoleto(idDocumentoReceber);

            if (string.IsNullOrEmpty(caminhoBoleto))
            {
                MetodosGerais.RegistrarLog("BOLETO_PDF", $"Caminho do boleto não encontrado. DR: {idDocumentoReceber}");
                throw new InvalidOperationException("Caminho do boleto não encontrado.");
            }

            // Converter o boleto para Base64
            string boletoBase64 = boletoPDFService.ConverterPDFParaBase64(caminhoBoleto);

            if (string.IsNullOrEmpty(boletoBase64))
            {
                MetodosGerais.RegistrarLog("BOLETO_PDF", $"Erro ao converter o boleto para Base64. DR: {idDocumentoReceber}");
                throw new InvalidOperationException("Erro ao converter o boleto para Base64.");
            }

            // Construir o corpo da requisição
            var payload = new
            {
                cnpj = "07446072000106",
                username = "admin",
                password ="senha123",
                fileName = $"Boleto_{dataVencimentoBoleto}_{idDocumentoReceber}.pdf",
                base64 = boletoBase64
            };

            string jsonPayload = JsonConvert.SerializeObject(payload);

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Configurar o endpoint da API
                    string url = "http://212.85.17.216:5007/api/BoletoPDF/upload";

                  

                    // Enviar a requisição POST
                    HttpContent content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(url, content);
                    string jsonContent = await content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                    {
                        // Ler a resposta da API
                        string responseContent = await response.Content.ReadAsStringAsync();

                        var jsonDoc = JsonDocument.Parse(responseContent);
                        string urlRetornada = jsonDoc.RootElement.GetProperty("url").GetString();

                        MetodosGerais.RegistrarLog("BOLETO_PDF", $"Caminho DR {idDocumentoReceber}: {responseContent.Trim()} ");
                        return urlRetornada.Trim(); // Retorna o link do PDF
                    
                    }
                    else
                    {
                        // Registrar erro caso a resposta não seja bem-sucedida
                        MetodosGerais.RegistrarLog("BOLETO_PDF", $"Erro: API retornou código de status {response.StatusCode}.  DR {idDocumentoReceber}. - json {jsonContent}");
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    // Tratar e registrar erros
                    MetodosGerais.RegistrarLog("BOLETO_PDF", $"Erro ao enviar PDF do boleto: {ex.Message}.  DR {idDocumentoReceber}. ");
                    throw;
                }
            }
        }

        public static async Task<bool> EnviarPDFBoletoNoWhatsapp( string linkBoleto,  string destinatario, string Token, int idDocumentoReceber,string dataVencimentoBoleto, string Instancia)
        {
            // Validar entrada
            if (string.IsNullOrEmpty(linkBoleto) || destinatario == null || destinatario.Length == 0 || Instancia is null)
                throw new ArgumentException("Parâmetros inválidos para o envio da mensagem.");

            // Construir o corpo da requisição
            var payload = new
            {
                number = destinatario,
                mediatype = "document",
                mimetype = "image/png",
                caption = "Segue o seu boleto!",
                media = linkBoleto,
                fileName = $"BOLETO_{dataVencimentoBoleto}.pdf"
            };

            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;


            using (HttpClient httpClient = new HttpClient())
            {
                try
                {   // Configurar o cabeçalho de autenticação
                    httpClient.DefaultRequestHeaders.Add("apikey", Token);
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // Definir URL do endpoint da Evolution API
                    string url = $"https://n8n-evolution-api.usbaxy.easypanel.host/message/sendMedia/{Instancia}";
                    HttpContent content = MetodosGerais.CriarConteudoJson(payload);
                    string jsonContent = await content.ReadAsStringAsync();

                    HttpResponseMessage response = await httpClient.PostAsync(url, content);


                    if (response.IsSuccessStatusCode)
                    {
                        // Log de sucesso
                        MetodosGerais.RegistrarLog("BOLETO_PDF", $"Boleto em PDF enviado com Sucesso por whatsapp!. DR: {idDocumentoReceber}");
                        return true;
                    }
                    else
                    {
                        // Log de erro
                        MetodosGerais.RegistrarLog("BOLETO_PDF", $"Erro ao enviar Boleto em PDF do documento a receber: {idDocumentoReceber}. Codigo Error: {response.StatusCode} - Json: {jsonContent}");
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    // Tratar erros e registrar log
                    MetodosGerais.RegistrarLog("BOLETO_PDF", $"Erro ao enviar mensagem: {ex.Message}");
                    throw;
                }
            }
        }
    }

    // Classe para deserializar a resposta da API
    public class ApiResponse
    {
        [JsonProperty("link")]
        public string Link { get; set; }
    }
}
