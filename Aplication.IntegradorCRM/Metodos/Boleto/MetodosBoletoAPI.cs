using Integrador_Com_CRM.Data;
using Integrador_Com_CRM.Models.EF;
using Integrador_Com_CRM.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Integrador_Com_CRM.Metodos.Boleto
{
    internal class MetodosBoletoAPI
    {
        // Método auxiliar para enviar requisição de criação de oportunidade para a API
        internal static async Task<OportunidadeResponse> EnviarRequisicaoCriarOportunidade(ModeloOportunidadeRequest request, string token)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var json = JsonConvert.SerializeObject(request);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                try
                {
                    MetodosGerais.RegistrarLog("BOLETO", "Enviando requisição para criar oportunidade no CRM...");

                    var response = await client.PostAsync("https://api.leadfinder.com.br/integracao/v2/inserirOportunidade", content);
                    var responseBody = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        MetodosGerais.RegistrarLog("BOLETO", "Resposta OK - Oportunidade criada no CRM");
                        return JsonConvert.DeserializeObject<OportunidadeResponse>(responseBody);
                    }

                    MetodosGerais.RegistrarLog("BOLETO", $"Erro na resposta da API: Status {response.StatusCode} - {responseBody}");
                }
                catch (HttpRequestException ex)
                {
                    MetodosGerais.RegistrarLog("BOLETO", $"Erro de rede ao chamar API: {ex.Message}");
                    throw;
                }
                catch (Exception ex)
                {
                    MetodosGerais.RegistrarLog("BOLETO", $"Exceção ao processar resposta da API: {ex.Message}");
                    throw;
                }

                return null;
            }
        }

        // Método auxiliar para adicionar o boleto no banco de dados
        internal static async Task AdicionarBoletoNoBanco(DAL<RelacaoBoletoCRMModel> dalTableRelacaoBoleto, RelacaoBoletoCRMModel boletoInTabRel, string codigoOportunidade)
        {
            boletoInTabRel.Cod_Oportunidade = codigoOportunidade;
            boletoInTabRel.Data_Criacao = DateTime.Now;

            using (var dalBoletoUsing = new DAL<RelacaoBoletoCRMModel>(new IntegradorDBContext()))
            {
                await dalBoletoUsing.AdicionarAsync(boletoInTabRel);
            }
        }

        internal static async Task<OportunidadeResponse> AtualizarOportunidadeNaApi(AtualizarAcaoRequest request, string token)
        {
            // configurar o cabeçalho de autorização 
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var json = JsonConvert.SerializeObject(request);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                try
                {
                    var response = await client.PostAsync("https://api.leadfinder.com.br/integracao/movimentarOportunidade", content);
                    var responseBody = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        MetodosGerais.RegistrarLog("BOLETO", "Resposta OK - Oportunidade Atualizada no CRM");
                        return JsonConvert.DeserializeObject<OportunidadeResponse>(responseBody);
                    }

                    MetodosGerais.RegistrarLog("BOLETO", $"Erro na resposta da API: Status {response.StatusCode} - {responseBody}");
                }
                catch (HttpRequestException ex)
                {
                    MetodosGerais.RegistrarLog("BOLETO", $"Erro de rede ao chamar API: {ex.Message}");
                    throw;
                }
                catch (Exception ex)
                {
                    MetodosGerais.RegistrarLog("BOLETO", $"Exceção ao processar resposta da API: {ex.Message}");
                    throw;
                }

                return null;
            }
        }

        // Método auxiliar para atualizar boleto no banco
        internal static async Task AtualizarBoletoNoBanco(RelacaoBoletoCRMModel boletoRelacao)
        {
            boletoRelacao.Data_Atualizacao = DateTime.Now;

            using (var dalBoletoUsing = new DAL<RelacaoBoletoCRMModel>(new IntegradorDBContext()))
            {
                await dalBoletoUsing.AtualizarAsync(boletoRelacao);
            }
        }

        // Metodo Recebe Boletos que tenham sido quitados, o boleto será excluido da tabela de cobrança de fim de semana caso tenha
        internal static async Task ProcessarBoletoQuitado(RelacaoBoletoCRMModel boletoRelacao)
        {
            var cobrancas = new CobrancasNaSegundaModel();
            await cobrancas.RemoverRegistro(boletoRelacao.Id, true);
            MetodosGerais.RegistrarLog("BOLETO", $"Situação atualizada para {boletoRelacao.Situacao} para o documento {boletoRelacao.Id_DocumentoReceber}");
        }

    }
}
