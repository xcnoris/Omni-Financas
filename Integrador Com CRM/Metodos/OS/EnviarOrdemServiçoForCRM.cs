using Integrador_Com_CRM.Data;
using Integrador_Com_CRM.Models;
using Integrador_Com_CRM.Models.EF;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace Integrador_Com_CRM.Metodos.OS
{
    internal class EnviarOrdemServiçoForCRM
    {
        public static async Task<OportunidadeResponse> EnviarOportunidade(ModeloOportunidadeRequest request, string Token, RelacaoOrdemServicoModels TableRelacaoOS,DAL<RelacaoOrdemServicoModels> dalRelacaoOS)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = "https://api.leadfinder.com.br/integracao/v2/inserirOportunidade";
                client.DefaultRequestHeaders.Add("Authorization", Token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                string json = JsonConvert.SerializeObject(request);
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

                try
                {
                    MetodosGerais.RegistrarLog("OS", "Criando Oportunidade no CRM....");
                    HttpResponseMessage response = await client.PostAsync(url, content);
                    string responseBody = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        OportunidadeResponse resposta = JsonConvert.DeserializeObject<OportunidadeResponse>(responseBody);
                        if (resposta != null)
                        {

                            MetodosGerais.RegistrarLog("OS", "Resposta OK - Oportunidade criada no CRM:");
                            MetodosGerais.RegistrarLog("OS", responseBody);

                            /*
                                Define o CodOportunidade com valor que retornou no response da chamada da API
                                O codOportunidade usaremos mais tarde para movimentar a Oportunidade no CRM
                            */
                            TableRelacaoOS.Cod_Oportunidade = resposta.CodigoOportunidade;
                            TableRelacaoOS.Data_Criacao = DateTime.Now;
                            using (var dalOSUsing = new DAL<RelacaoOrdemServicoModels>(new IntegradorDBContext()))
                            {
                                await dalOSUsing.AdicionarAsync(TableRelacaoOS);
                            }
                            return resposta;

                        }
                        else
                        {
                            MetodosGerais.RegistrarLog("OS", "Erro na resposta: resposta desserializada é nula.");
                        }
                    }
                    else
                    {
                        MetodosGerais.RegistrarLog("OS", "Erro na resposta da API:");
                        MetodosGerais.RegistrarLog("OS", $"Status Code: {response.StatusCode}");
                        MetodosGerais.RegistrarLog("OS", responseBody);
                    }
                }
                catch (Exception ex)
                {
                    MetodosGerais.RegistrarLog("OS", "Exceção durante a chamada da API:");
                    MetodosGerais.RegistrarLog("OS", ex.Message);
                    throw new Exception(ex.Message);
                }

                return null;
            }
        }

        public static async Task<OportunidadeResponse> AtualizarAcao(AtualizarAcaoRequest request, string Token, RelacaoOrdemServicoModels TableRelacaoOS, DAL<RelacaoOrdemServicoModels> dalRelacaoOS)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = "https://api.leadfinder.com.br/integracao/movimentarOportunidade";
                client.DefaultRequestHeaders.Add("Authorization", Token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                string json = JsonConvert.SerializeObject(request);
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

                try
                {
                    HttpResponseMessage response = await client.PostAsync(url, content);
                    string responseBody = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        OportunidadeResponse resposta = JsonConvert.DeserializeObject<OportunidadeResponse>(responseBody);
                        if (resposta != null)
                        {
                            MetodosGerais.RegistrarLog("OS", "Resposta OK -  Oportunidade Atualizada no CRM: ");
                            MetodosGerais.RegistrarLog("OS", responseBody);

                            
                            TableRelacaoOS.Data_Alteracao = DateTime.Now;

                            using (var dalOSUsing = new DAL<RelacaoOrdemServicoModels>(new IntegradorDBContext()))
                            {
                                await dalOSUsing.AtualizarAsync(TableRelacaoOS);
                            }
                            MetodosGerais.RegistrarLog("OS", $"Categoria atualizada para {TableRelacaoOS.Id_CategoriaOS} na tabela de relação para a OS {TableRelacaoOS.Id_OrdemServico}.");
                           
                            return resposta;
                        }
                        else
                        {
                            MetodosGerais.RegistrarLog("OS", "Erro na resposta: resposta desserializada é nula.");
                        }
                    }
                    else
                    {
                        MetodosGerais.RegistrarLog("OS", "Erro na resposta da API:");
                        MetodosGerais.RegistrarLog("OS", $"Status Code: {response.StatusCode}");
                        MetodosGerais.RegistrarLog("OS", responseBody);
                    }
                }
                catch (Exception ex)
                {
                    MetodosGerais.RegistrarLog("OS", "Exceção durante a chamada da API:");
                    MetodosGerais.RegistrarLog("OS", ex.Message);
                    throw new Exception(ex.Message);
                }

                return null;
            }
        }
    }
}
