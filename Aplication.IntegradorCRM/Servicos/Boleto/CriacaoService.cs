using Aplication.IntegradorCRM.DTO;
using Aplication.IntegradorCRM.Metodos.Boleto;
using DataBase.IntegradorCRM.Data;
using Metodos.IntegradorCRM.Metodos;
using Modelos.IntegradorCRM.Models;
using Modelos.IntegradorCRM.Models.EF;
using Modelos.IntegradorCRM.Models.Enuns;
using Modelos.IntegradorCRMRM.Models;

namespace Aplication.IntegradorCRM.Servicos.Boleto
{
    internal class CriacaoService
    {
        internal async static Task<bool> RealizarProcessoCriacaoBoleto(DadosAPIModels DadosAPI, RetornoBoleto boleto, bool EnviarPDFaoCriarOPT, bool enviarPDFPorEmailAoCriarOPT, ConfigEmail configEmail)
        {
            using DAL<RelacaoBoletoModel> _dalRelacaoBOletos = new DAL<RelacaoBoletoModel>(new IntegradorDBContext());
            RelacaoBoletoModel RelacaoBoleto = RelacaoBoletoModel.InstanciaDados(boleto);

            MensagensEnvios ModeloMensEnvio = await Boleto_Services.InstanciarAcaoRequestBoletoSitucao(boleto, Situacao_Boleto.AbertoOuABertura);

            // Tenta enviar a mensagem de criacão de boleto, caso nao der certo a criacão, gera um log
            if (await EnviarMensagemCriacao(ModeloMensEnvio, DadosAPI, _dalRelacaoBOletos, RelacaoBoleto, EnviarPDFaoCriarOPT, enviarPDFPorEmailAoCriarOPT, configEmail) is false)
            {
                MetodosGerais.RegistrarLog("ERRO", $"Falha ao envar Mensagem criacao do boleto. Boleto: {RelacaoBoleto.Id_DocumentoReceber}. Request: {ModeloMensEnvio}");
                return false;
            }
            // Verifica se o boleto já esta pago, caso esteja muda o boleto para fase Pago/Aguardando Liberação
            Boleto_Services.VerificarQuitacao((Situacao_Boleto)RelacaoBoleto.Situacao, RelacaoBoleto, DadosAPI, false, boleto, configEmail);
            return true;
        }

        private async static Task<bool> EnviarMensagemCriacao(MensagensEnvios Requests, DadosAPIModels DadosAPI, DAL<RelacaoBoletoModel> dalRelBoletos, RelacaoBoletoModel RelacaoBoleto, bool enviarPDFaoCriarOPT, bool enviarPDFPorEmailAoCriarOPT,  ConfigEmail configEmail)
        {
            using DAL<AcaoSituacao_Boleto> dalAcaoSitBoleto = new DAL<AcaoSituacao_Boleto>(new IntegradorDBContext());
            AcaoSituacao_Boleto? AcaoSitBoleto = await dalAcaoSitBoleto.BuscarPorAsync(x => x.Situacao == Situacao_Boleto.AbertoOuABertura);

            bool response = await EnviarMensagemBoleto.EnviarMensagemCriacao(Requests, DadosAPI, dalRelBoletos, RelacaoBoleto, AcaoSitBoleto.EnviarPDFPorWhats, configEmail, AcaoSitBoleto.EnviarPDFPorEmail);
            return response;
        }
    } 
}
