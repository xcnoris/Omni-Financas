using Integrador_Com_CRM.Data;
using Integrador_Com_CRM.Models;
using Integrador_Com_CRM.Models.EF;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Integrador_Com_CRM.Metodos.Boleto
{
    internal class EnviarBoletoParaCRM
    {
        public static async Task<OportunidadeResponse> CriarOportunidade(OrdemServiçoRequest request, string Token, DAL<RelacaoBoletoCRMModel> dalTableRelacaoBoleto, RelacaoBoletoCRMModel boletoInTabRel)
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
                    MetodosGerais.RegistrarLog("BOLETO", "Criando Oportunidade no CRM....");
                    HttpResponseMessage response = await client.PostAsync(url, content);
                    string responseBody = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        OportunidadeResponse resposta = JsonConvert.DeserializeObject<OportunidadeResponse>(responseBody);
                        if (resposta != null)
                        {
                            /*
                                Caso der certo a criação da oportunidade, atribui
                                o valor retornado da api do codigo da oportunidade 
                            */

                            MetodosGerais.RegistrarLog("BOLETO", "Resposta OK - Oportunidade criada no CRM:");
                            MetodosGerais.RegistrarLog("BOLETO", responseBody);


                            boletoInTabRel.Cod_Oportunidade = resposta.CodigoOportunidade.ToString();

                            dalTableRelacaoBoleto.AdicionarAsync(boletoInTabRel);
                            return resposta;

                        }
                        else
                        {
                            MetodosGerais.RegistrarLog("BOLETO", "Erro na resposta: resposta desserializada é nula.");
                        }
                    }
                    else
                    {
                        MetodosGerais.RegistrarLog("BOLETO", "Erro na resposta da API:");
                        MetodosGerais.RegistrarLog("BOLETO", $"Status Code: {response.StatusCode}");
                        MetodosGerais.RegistrarLog("BOLETO", responseBody);
                    }
                }
                catch (Exception ex)
                {
                    MetodosGerais.RegistrarLog("BOLETO", "Exceção durante a chamada da API:");
                    MetodosGerais.RegistrarLog("BOLETO", ex.Message);
                }

                return null;
            }
        }

        public static async Task<OportunidadeResponse> AtualizarAcao(AtualizarAcaoRequest request, string Token, DAL<RelacaoBoletoCRMModel> dalTableRelacaoBoleto, RelacaoBoletoCRMModel BoletoRElacao, bool foiquitado)
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
                            MetodosGerais.RegistrarLog("BOLETO", "Resposta OK -  Oportunidade Atualizada no CRM: ");
                            MetodosGerais.RegistrarLog("BOLETO", responseBody);

                            if (foiquitado)
                            {

                                dalTableRelacaoBoleto.AtualizarAsync(BoletoRElacao);
                             
                                MetodosGerais.RegistrarLog("BOLETO", $"Situacao atualizada para {BoletoRElacao.Situacao} na tabela de relação para a o documento a receber {BoletoRElacao.Id_DocumentoReceber}.");
                             
                            }
                            return resposta;
                        }
                        else
                        {
                            MetodosGerais.RegistrarLog("BOLETO", "Erro na resposta: resposta desserializada é nula.");
                        }
                    }
                    else
                    {
                        MetodosGerais.RegistrarLog("BOLETO", "Erro na resposta da API:");
                        MetodosGerais.RegistrarLog("BOLETO", $"Status Code: {response.StatusCode}");
                        MetodosGerais.RegistrarLog("BOLETO", responseBody);
                    }
                }
                catch (Exception ex)
                {
                    MetodosGerais.RegistrarLog("BOLETO", "Exceção durante a chamada da API:");
                    MetodosGerais.RegistrarLog("BOLETO", ex.Message);
                }

                return null;
            }
        }
    }
}
