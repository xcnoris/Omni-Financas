using Integrador_Com_CRM.Data;
using Integrador_Com_CRM.Models;
using Integrador_Com_CRM.Models.EF;

namespace Integrador_Com_CRM.Metodos.Boleto
{
    internal class EnviarBoletoParaCRM
    {


        public static async Task<OportunidadeResponse> CriarOportunidade(ModeloOportunidadeRequest request, string token, DAL<RelacaoBoletoCRMModel> dalTableRelacaoBoleto, RelacaoBoletoCRMModel boletoInTabRel)
        {
            // Validar entrada
            if (request == null || string.IsNullOrEmpty(token) || boletoInTabRel == null)
                throw new ArgumentException("Parâmetros inválidos para CriarOportunidade.");

            // Fazer a requisição para criar a oportunidade na API
            var apiResponse = await MetodosBoletoAPI.EnviarRequisicaoCriarOportunidade(request, token);

            if (apiResponse != null)
            {
                // Atualizar a tabela de relação com o código da oportunidade e a data de criação
                await MetodosBoletoAPI.AdicionarBoletoNoBanco(dalTableRelacaoBoleto, boletoInTabRel, apiResponse.CodigoOportunidade);

                MetodosGerais.RegistrarLog("BOLETO", "Oportunidade criada com sucesso.");
                return apiResponse;
            }

            MetodosGerais.RegistrarLog("BOLETO", "Erro: A resposta da API foi nula ou inválida.");
            return null;
        }

        public static async Task<OportunidadeResponse> AtualizarAcao(AtualizarAcaoRequest request, string token, DAL<RelacaoBoletoCRMModel> dalTableRelacaoBoleto, RelacaoBoletoCRMModel BoletoRElacao, bool foiQuitado)
        {
            // Validar dados de entrada
            if (request == null || string.IsNullOrEmpty(token) || BoletoRElacao == null)
                throw new ArgumentException("Parâmetros inválidos para AtualizarAcao.");

            var apiResponse = await MetodosBoletoAPI.AtualizarOportunidadeNaApi(request, token);

            if (apiResponse != null)
            {
                await MetodosBoletoAPI.AtualizarBoletoNoBanco(BoletoRElacao);
                if (foiQuitado)
                    await MetodosBoletoAPI.ProcessarBoletoQuitado(BoletoRElacao);

                return apiResponse;
            }

            MetodosGerais.RegistrarLog("BOLETO", "Erro: API retornou uma resposta nula ou inválida.");
            return null;
        }


    }
}
