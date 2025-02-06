using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Aplication.IntegradorCRM.Servicos.Boleto;
using Metodos.IntegradorCRM.Metodos;
using Modelos.IntegradorCRM.Models.EF;
using Newtonsoft.Json;

namespace Aplication.IntegradorCRM.Metodos.Boleto
{
    internal class EnviarPDFBoleto
    {
        public static async Task<bool> ProcessarEnvioPDFBoleto(int idDocumentoReceber, string Token, string[] destinatarios)
        {
            string linkBoleto = await GerarLinkDoPDFReposOnline(idDocumentoReceber, Token);
            if (string.IsNullOrEmpty(linkBoleto))
                return false;
            return await EnviarPDFBoletoNoWhatsapp(linkBoleto, destinatarios, Token, idDocumentoReceber);

        }
        public static async Task<string> GerarLinkDoPDFReposOnline(int idDocumentoReceber, string Token)
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
                nome = "Boleto",
                nomeArquivo = "Boleto.pdf",
                tipoArquivo = "application/pdf",
                base64Arquivo = boletoBase64
            };

            string jsonPayload = JsonConvert.SerializeObject(payload);

            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    // Configurar o endpoint da API
                    string url = "https://api.leadfinder.com.br/integracao/inserirAnexo";

                    // Configurar o cabeçalho da requisição
                    httpClient.DefaultRequestHeaders.Add("Authorization", Token);

                    // Enviar a requisição POST
                    HttpContent content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await httpClient.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        // Ler a resposta da API
                        string responseContent = await response.Content.ReadAsStringAsync();

                        // Deserializar a resposta para capturar o link
                        var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(responseContent);

                        if (apiResponse != null && !string.IsNullOrEmpty(apiResponse.Link))
                        {
                            MetodosGerais.RegistrarLog("BOLETO_PDF", $"Caminho DR {idDocumentoReceber}: {apiResponse.Link.Trim()} ");
                            return apiResponse.Link.Trim(); // Retorna o link do PDF
                        }
                        else
                        {
                            MetodosGerais.RegistrarLog("BOLETO_PDF", $"Resposta da API não contém um link válido. DR {idDocumentoReceber}.");
                            throw new InvalidOperationException("Resposta da API não contém um link válido.");
                        }
                    }
                    else
                    {
                        // Registrar erro caso a resposta não seja bem-sucedida
                        MetodosGerais.RegistrarLog("BOLETO_PDF", $"Erro: API retornou código de status {response.StatusCode}.  DR {idDocumentoReceber}.");
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    // Tratar e registrar erros
                    MetodosGerais.RegistrarLog("BOLETO", $"Erro ao enviar PDF do boleto: {ex.Message}.  DR {idDocumentoReceber}.");
                    throw;
                }
            }
        }

        public static async Task<bool> EnviarPDFBoletoNoWhatsapp( string linkBoleto,  string[] destinatarios, string Token, int idDocumentoReceber)
        {
            // Validar entrada
            if (string.IsNullOrEmpty(linkBoleto) || destinatarios == null || destinatarios.Length == 0)
                throw new ArgumentException("Parâmetros inválidos para o envio da mensagem.");

            // Construir o corpo da requisição
            var payload = new
            {
                mensagem = "",
                arquivo = linkBoleto,
                nomeArquivo = "BOLETO.pdf",
                destinatarios = destinatarios
            };

            string jsonPayload = JsonConvert.SerializeObject(payload);

            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    // Configurar o endpoint da API
                    string url = "https://api.leadfinder.com.br/integracao/enviarMensagem/C55D6BB1A4/ARQUIVO";

                    // Configurar o cabeçalho da requisição
                    httpClient.DefaultRequestHeaders.Add("Authorization", Token);

                    // Enviar a requisição POST
                    HttpContent content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await httpClient.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        // Log de sucesso
                        MetodosGerais.RegistrarLog("BOLETO", $"Boleto em PDF enviado com Sucesso!. DR: {idDocumentoReceber}");
                        return true;
                    }
                    else
                    {
                        // Log de erro
                        MetodosGerais.RegistrarLog("BOLETO", $"Erro ao enviar Boleto em PDF do documento a receber: {idDocumentoReceber}. Codigo Error: {response.StatusCode}");
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    // Tratar erros e registrar log
                    MetodosGerais.RegistrarLog("BOLETO", $"Erro ao enviar mensagem: {ex.Message}");
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
