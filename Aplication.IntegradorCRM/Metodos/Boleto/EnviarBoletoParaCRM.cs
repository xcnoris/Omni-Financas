using Aplication.IntegradorCRM.Servicos.Boleto;
using DataBase.IntegradorCRM.Data;
using Metodos.IntegradorCRM.Metodos;
using Modelos.IntegradorCRM.Models;
using Modelos.IntegradorCRM.Models.EF;
using Modelos.IntegradorCRMRM.Models;

namespace Aplication.IntegradorCRM.Metodos.Boleto
{
    internal class EnviarBoletoParaCRM
    {


        public static async Task<OportunidadeResponse> CriarOportunidade(ModeloOportunidadeRequest request, string token, DAL<RelacaoBoletoCRMModel> dalTableRelacaoBoleto, RelacaoBoletoCRMModel boletoInTabRel, bool EnviarPDF, string CodigoAPI_EnvioPDF)
        {
            // Validar entrada
            if (request == null || string.IsNullOrEmpty(token) || boletoInTabRel == null)
                throw new ArgumentException($"Parâmetros inválidos para CriarOportunidade. Request: {request} | token: {token} | boletoInTabRel: {boletoInTabRel}");

            // Fazer a requisição para criar a oportunidade na API
            OportunidadeResponse apiResponse = null;
            try
            {
                apiResponse = await Boleto_Services.EnviarRequisicaoCriarOportunidade(request, token);
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }

            if (apiResponse != null)
            {
                // Atualizar a tabela de relação com o código da oportunidade e a data de criação
                await Boleto_Services.AdicionarBoletoNoBanco(dalTableRelacaoBoleto, boletoInTabRel, apiResponse.CodigoOportunidade);

                // Verifica se esta marcado para enviar o PDF do boleto ao criar a oportunidade no CRM
                await VerificarEnvioPDF(EnviarPDF, boletoInTabRel, token, CodigoAPI_EnvioPDF);
                return apiResponse;
            }

            MetodosGerais.RegistrarLog("BOLETO", "Erro: A resposta da API foi nula ou inválida.");
            return null;
        }

        public static async Task<OportunidadeResponse> AtualizarAcao(AtualizarAcaoRequest request, string token, DAL<RelacaoBoletoCRMModel> dalTableRelacaoBoleto, RelacaoBoletoCRMModel BoletoRElacao, bool foiQuitado, bool EnviarPDF, string CodigoAPI_EnvioPDF)
        {
            // Validar dados de entrada
            if (request == null || string.IsNullOrEmpty(token) || BoletoRElacao == null)
                throw new ArgumentException("Parâmetros inválidos para AtualizarAcao.");

            var apiResponse = await Boleto_Services.AtualizarOportunidadeNaApi(request, token, BoletoRElacao.Id_DocumentoReceber.ToString());

            
            if (apiResponse != null)
            {
                await Boleto_Services.AtualizarBoletoNoBanco(BoletoRElacao);
                if (foiQuitado)
                    await Boleto_Services.ProcessarBoletoQuitado(BoletoRElacao);

                await VerificarEnvioPDF(EnviarPDF, BoletoRElacao, token, CodigoAPI_EnvioPDF);

                return apiResponse;
            }

            MetodosGerais.RegistrarLog("BOLETO", $"Erro: API retornou uma resposta nula ou inválida. | DR: {BoletoRElacao.Id_DocumentoReceber}");
            return null;
        }

        private static async Task VerificarEnvioPDF(bool EnviarPDF,RelacaoBoletoCRMModel BoletoRElacao,string token, string CodigoAPI_EnvioPDF)
        {
            if (EnviarPDF)
            {
                await Task.Delay(30000);
                string[] destinatarios = { $"+55{BoletoRElacao.Celular_Entidade}" };
                await EnviarPDFBoleto.ProcessarEnvioPDFBoleto(BoletoRElacao.Id_DocumentoReceber, token, destinatarios, BoletoRElacao.Data_Vencimento.ToString("dd/MM/yyyy"), CodigoAPI_EnvioPDF);

            }
        }

    }
}
