﻿using Aplication.IntegradorCRM.Servicos.Boleto;
using DataBase.IntegradorCRM.Data;
using Metodos.IntegradorCRM.Metodos;
using Modelos.IntegradorCRM.Models.EF;
using Modelos.IntegradorCRMRM.Models;

namespace Aplication.IntegradorCRM.Metodos.Boleto
{
    internal class EnviarMensagemBoleto
    {


        public static async Task<bool> EnviarMensagemCriacao(ModeloOportunidadeRequest request, DadosAPIModels DadosAPI, DAL<RelacaoBoletoModel> dalTableRelacaoBoleto, RelacaoBoletoModel boletoInTabRel, bool EnviarPDF)
        {
            // Validar entrada
            if (request == null || string.IsNullOrEmpty(DadosAPI.Token) || boletoInTabRel == null)
                throw new ArgumentException($"Parâmetros inválidos para CriarOportunidade. Request: {request} | token: {DadosAPI.Token} | boletoInTabRel: {boletoInTabRel}");

            // Fazer a requisição para criar a oportunidade na API
            bool retornoCriaca = false;
            try
            {
                retornoCriaca = await Boleto_Services.EnviarMensagemCriacao(request, DadosAPI);
            }
            catch (Exception ex)
            {
                return false;
            }

            if (retornoCriaca != false)
            {
                // Atualizar a tabela de relação com o código da oportunidade e a data de criação
                await Boleto_Services.AdicionarBoletoNoBanco(dalTableRelacaoBoleto, boletoInTabRel);
                // Verifica se esta marcado para enviar o PDF do boleto ao criar a oportunidade no CRM
                await VerificarEnvioPDF(EnviarPDF, boletoInTabRel, DadosAPI.Token, DadosAPI.Instancia);
                return true;
                
            }

            MetodosGerais.RegistrarLog("BOLETO", "Erro: A resposta da API foi nula ou inválida.");
            return false;
        }

        public static async Task EnviarMensagem(ModeloOportunidadeRequest request, DadosAPIModels DadosAPI, DAL<RelacaoBoletoModel> dalTableRelacaoBoleto, RelacaoBoletoModel BoletoRElacao, bool foiQuitado, bool EnviarPDF, string CodigoAPI_EnvioPDF)
        {
            // Validar dados de entrada
            if (request == null || string.IsNullOrEmpty(DadosAPI.Token) || BoletoRElacao == null)
                throw new ArgumentException($"Parâmetros inválidos para CriarOportunidade. Request: {request} | token: {DadosAPI.Token} | boletoInTabRel: {BoletoRElacao}");

            bool apiResponse = await Boleto_Services.EnviarMensagem(request, DadosAPI, BoletoRElacao.Id_DocumentoReceber.ToString());


            if (apiResponse != false)
            {
                await Boleto_Services.AtualizarBoletoNoBanco(BoletoRElacao);
              
                await VerificarEnvioPDF(EnviarPDF, BoletoRElacao, DadosAPI.Token, DadosAPI.Instancia);
                MetodosGerais.RegistrarLog("BOLETO", $"Situação atualizada para {BoletoRElacao.Situacao} para o documento {BoletoRElacao.Id_DocumentoReceber}");

                return;
            }

            MetodosGerais.RegistrarLog("BOLETO", $"Erro: API retornou uma resposta nula ou inválida. | DR: {BoletoRElacao.Id_DocumentoReceber}");

        }

        private static async Task VerificarEnvioPDF(bool EnviarPDF,RelacaoBoletoModel BoletoRElacao,string token, string InstanciaEnvoluctionAPI)
        {
            if (EnviarPDF)
            {
                await Task.Delay(1000);
                string destinatarios = $"+55{BoletoRElacao.Celular_Entidade}";
                await EnviarPDFBoleto.ProcessarEnvioPDFBoleto(BoletoRElacao.Id_DocumentoReceber, token, destinatarios, BoletoRElacao.Data_Vencimento.ToString("dd-MM-yyyy"), InstanciaEnvoluctionAPI);

            }
        }

    }
}
