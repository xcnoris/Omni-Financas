using Aplication.IntegradorCRM.Metodos.Boleto;
using DataBase.IntegradorCRM.Data;
using Metodos.IntegradorCRM.Metodos;
using Modelos.IntegradorCRM.Models.EF;
using Modelos.IntegradorCRM.Models.Enuns;
using Modelos.IntegradorCRMRM.Models;

namespace Aplication.IntegradorCRM.Servicos.Boleto
{
    internal class CriacaoService
    {
        internal async static Task<bool> RealizarProcessoCriacaoBoleto(DadosAPIModels DadosAPI, RetornoBoleto boleto, bool EnviarPDFaoCriarOPT)
        {
            using DAL<RelacaoBoletoCRMModel> _dalRelacaoBOletos = new DAL<RelacaoBoletoCRMModel>(new IntegradorDBContext());
            RelacaoBoletoCRMModel RelacaoBoleto = RelacaoBoletoCRMModel.InstanciaDados(boleto);

            ModeloOportunidadeRequest OportunidadRequest = await Boleto_Services.InstanciarAcaoRequestSitucaoBoleto(boleto, Situacao_Boleto.Aberto);

            // Tenta enviar a mensagem de criacão de boleto, caso nao der certo a criacão, gera um log
            if (await EnviarMensagemCriacao(OportunidadRequest, DadosAPI, _dalRelacaoBOletos, RelacaoBoleto, EnviarPDFaoCriarOPT) is false)
            {
                MetodosGerais.RegistrarLog("ERRO", $"Falha ao envar Mensagem criacao do boleto. Boleto: {RelacaoBoleto.Id_DocumentoReceber}. Request: {OportunidadRequest}");
                return false;
            }
            // Verifica se o boleto já esta pago, caso esteja muda o boleto para fase Pago/Aguardando Liberação
            Boleto_Services.VerificarQuitacao((Situacao_Boleto)RelacaoBoleto.Situacao, RelacaoBoleto, DadosAPI, false, boleto);
            return true;
        }

        private async static Task<bool> EnviarMensagemCriacao(ModeloOportunidadeRequest Request, DadosAPIModels DadosAPI, DAL<RelacaoBoletoCRMModel> dalRelBoletos, RelacaoBoletoCRMModel RelacaoBoleto, bool EnviarPDFaoCriarOPT)
        {
            using DAL<AcaoSituacao_Boleto_CRM> dalAcaoSitBoleto = new DAL<AcaoSituacao_Boleto_CRM>(new IntegradorDBContext());
            AcaoSituacao_Boleto_CRM? AcaoSitBoleto = await dalAcaoSitBoleto.BuscarPorAsync(x => x.Situacao == Situacao_Boleto.Aberto);

            bool response = await EnviarMensagemBoleto.EnviarMensagemCriacao(Request, DadosAPI, dalRelBoletos, RelacaoBoleto, EnviarPDFaoCriarOPT);
            return response;
        }
    } 
}
