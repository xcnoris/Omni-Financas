using Aplication.IntegradorCRM.Servicos.Boleto;
using DataBase.IntegradorCRM.Data;
using Metodos.IntegradorCRM.Metodos;
using Modelos.IntegradorCRM.Models.EF;
using Modelos.IntegradorCRMRM.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Modelos.IntegradorCRM.Models;

namespace Aplication.IntegradorCRM.Metodos.Envio__Email
{
    public class EnvioEmail
    {
        public static async Task<bool> EnviarEmail(EmailRequest emailRequest, string token)
        {
            // Validar entrada
            if (emailRequest == null || string.IsNullOrWhiteSpace(token))
                throw new ArgumentException("Parâmetros inválidos para enviar e-mail!");

            using (HttpClient client = new HttpClient())
            {
                // Adicionar cabeçalho de autorização e configurar o cliente HTTP
                client.DefaultRequestHeaders.Add("Authorization", token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Serializar o objeto da requisição para JSON
                var json = JsonConvert.SerializeObject(emailRequest);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                try
                {
                    // Fazer o POST na API de envio de e-mail
                    var response = await client.PostAsync("https://api.leadfinder.com.br/apiemail/enviaEmail", content);
                    var responseBody = await response.Content.ReadAsStringAsync();

                    // Verificar o sucesso da resposta
                    if (response.IsSuccessStatusCode)
                    {
                        // Logar sucesso
                        MetodosGerais.RegistrarLog("EMAIL", "E-mail enviado com sucesso: " + responseBody);
                        return true;
                    }
                    else
                    {
                        // Logar erro no envio
                        MetodosGerais.RegistrarLog("EMAIL", $"Erro ao enviar e-mail. Status: {response.StatusCode}, Resposta: {responseBody}");
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    // Capturar e logar exceções
                    MetodosGerais.RegistrarLog("EMAIL", "Erro ao enviar e-mail: " + ex.Message);
                    return false;
                }
            }
        }
    }
}
