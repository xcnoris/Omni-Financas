using Aplication.IntegradorCRM.DTO;
using Aplication.IntegradorCRM.Servicos.Boleto;
using DataBase.IntegradorCRM.Data;
using Metodos.IntegradorCRM.Metodos;
using Microsoft.IdentityModel.Tokens;
using Modelos.IntegradorCRM.Models;
using Modelos.IntegradorCRM.Models.EF;
using Modelos.IntegradorCRMRM.Models;

namespace Aplication.IntegradorCRM.Metodos.Boleto
{
    internal class EnviarMensagemBoleto
    {


        public static async Task<bool> EnviarMensagemCriacao(MensagensEnvios requests, DadosAPIModels DadosAPI, DAL<RelacaoBoletoModel> dalTableRelacaoBoleto, RelacaoBoletoModel boletoInTabRel, bool EnviarPDFBoletoPorWhats, ConfigEmail configEmail, bool EnviarPDFBoletoPorEmail)
        {
            // Validar entrada
            if (requests == null || string.IsNullOrEmpty(DadosAPI.Token) || boletoInTabRel == null)
                throw new ArgumentException($"Parâmetros inválidos para CriarOportunidade. Request: {requests} | token: {DadosAPI.Token} | boletoInTabRel: {boletoInTabRel}");

            // Fazer a requisição para criar a oportunidade na API
            bool retornoCriaca = false;
            if (!(string.IsNullOrWhiteSpace(requests.ModeloWhatsapp.text)) && !(string.IsNullOrWhiteSpace(requests.ModeloWhatsapp.number)))
            {
                try
                {

                    retornoCriaca = await Boleto_Services.EnviarMensagemCriacao(requests, DadosAPI);
                }
                catch (Exception ex)
                {
                    return false;
                }
            }

            

            if (retornoCriaca != false || string.IsNullOrWhiteSpace(requests.ModeloWhatsapp.text)) 
            {
                // Atualizar a tabela de relação com o código da oportunidade e a data de criação
                // Verifica se esta marcado para enviar o PDF do boleto ao criar a oportunidade no CRM
                DeuCertoEnvioMensagensDTO DeuCertoEnvio =  await VerificarEnvioPDF(EnviarPDFBoletoPorWhats,EnviarPDFBoletoPorEmail, boletoInTabRel, DadosAPI.Token, DadosAPI.Instancia, configEmail, requests.ModeloEmail,  boletoInTabRel, true);

                if (DeuCertoEnvio.DeuCertoEnvioWhats || DeuCertoEnvio.DeuCertoEnvioPorEmail)
                {
                    await Boleto_Services.AdicionarBoletoNoBanco(boletoInTabRel);
                    return true;
                }
            }



            MetodosGerais.RegistrarLog("BOLETO", "Erro: A resposta da API foi nula ou inválida.");
            return false;
        }

        public static async Task EnviarMensagem(MensagensEnvios request, DadosAPIModels DadosAPI, DAL<RelacaoBoletoModel> dalTableRelacaoBoleto, RelacaoBoletoModel BoletoRElacao, bool foiQuitado, bool EnviarPDFBoletoPorWhats, bool EnviarPDFBoletoPorEmail,  string CodigoAPI_EnvioPDF, ConfigEmail configEmail)
        {
            // Validar dados de entrada
            if (request == null || string.IsNullOrEmpty(DadosAPI.Token) || BoletoRElacao == null)
                throw new ArgumentException($"Parâmetros inválidos para CriarOportunidade. Request: {request} | token: {DadosAPI.Token} | boletoInTabRel: {BoletoRElacao}");
            bool apiResponse = false;
            if (!(string.IsNullOrWhiteSpace(request.ModeloWhatsapp.text)) && !(string.IsNullOrWhiteSpace(request.ModeloWhatsapp.number)))
            {
                apiResponse = await Boleto_Services.EnviarMensagem(request.ModeloWhatsapp, DadosAPI, BoletoRElacao.Id_DocumentoReceber.ToString());
            }


            if (apiResponse != false || string.IsNullOrWhiteSpace(request.ModeloWhatsapp.text))
            {
                DeuCertoEnvioMensagensDTO DeuCertoEnvio = await VerificarEnvioPDF(EnviarPDFBoletoPorWhats,EnviarPDFBoletoPorEmail, BoletoRElacao, DadosAPI.Token, DadosAPI.Instancia, configEmail, request.ModeloEmail, BoletoRElacao, false);
                if (DeuCertoEnvio.DeuCertoEnvioWhats || DeuCertoEnvio.DeuCertoEnvioPorEmail)
                {
                    await Boleto_Services.AtualizarBoletoNoBanco(BoletoRElacao);
                    return;
                }
            }

            MetodosGerais.RegistrarLog("BOLETO", $"Erro: API retornou uma resposta nula ou inválida. | DR: {BoletoRElacao.Id_DocumentoReceber}");

        }

        private static async Task<DeuCertoEnvioMensagensDTO> VerificarEnvioPDF(bool EnviarPDFPorWhats, bool EnviarPDFPorEmail,RelacaoBoletoModel BoletoRElacao,string token, string InstanciaEnvoluctionAPI, ConfigEmail ConfigEmail, EmailModel Email, RelacaoBoletoModel boletoInTabRel, bool Criacao)
        {
            await Task.Delay(1000);
            string destinatarios = $"+55{BoletoRElacao.Celular_Entidade}";
            return await EnviarPDFBoleto.ProcessarEnvioPDFBoleto(EnviarPDFPorWhats,EnviarPDFPorEmail, BoletoRElacao.Id_DocumentoReceber, token, destinatarios, BoletoRElacao.Data_Vencimento.ToString("dd-MM-yyyy"), InstanciaEnvoluctionAPI, ConfigEmail, Email, boletoInTabRel, Criacao);
        }

    }
}
