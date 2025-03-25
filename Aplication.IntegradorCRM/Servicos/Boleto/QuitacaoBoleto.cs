using Aplication.IntegradorCRM.Metodos.Boleto;
using DataBase.IntegradorCRM.Data;
using Metodos.IntegradorCRM.Metodos;
using Modelos.IntegradorCRM.Models;
using Modelos.IntegradorCRM.Models.EF;
using Modelos.IntegradorCRM.Models.Enuns;
using Modelos.IntegradorCRMRM.Models;

namespace Aplication.IntegradorCRM.Servicos.Boleto
{
    internal class QuitacaoBoleto
    {
        public async static Task Quitar( RelacaoBoletoCRMModel boletoRelacao,bool boletoJaEmTabela, DadosAPIModels dadosAPI)
        {
            ModeloOportunidadeRequest? RequestQuitacao = await Boleto_Services.InstanciarAcaoRequestSitucaoBoleto(boletoRelacao.Celular_Entidade, Situacao_Boleto.Quitado);

            boletoRelacao.Situacao = 2;
            boletoRelacao.Quitado = 1;

            try
            {

                await AtualizarBoletoNoCRM(boletoRelacao, RequestQuitacao, dadosAPI, boletoJaEmTabela);
                MetodosGerais.RegistrarLog("BOLETO", $"Boleto {boletoRelacao.Id_DocumentoReceber} já existe na tabela relação. Foi atualizado para etapa Pago!");
            }
            catch (Exception ex)
            {
                MetodosGerais.RegistrarLog("ENV_BOLETO", $"[ERROR]: Falha ao atualizar boleto {boletoRelacao.Id_DocumentoReceber} - {ex.Message}");
            }
        }


        private async static Task AtualizarBoletoNoCRM(RelacaoBoletoCRMModel boletoRelacao, ModeloOportunidadeRequest ModeloRequest, DadosAPIModels dadosAPI, bool boletoJaEmTabela)
        {
            using var dalBoleto = new DAL<RelacaoBoletoCRMModel>(new IntegradorDBContext());
            
            if (boletoJaEmTabela)
            {
               
                await EnviarMensagemBoleto.EnviarMensagem(ModeloRequest, dadosAPI, dalBoleto, boletoRelacao, true, false, dadosAPI.CodAPI_EnvioPDF);
            }
            else
            {
                var boletoInTableRelacao = dalBoleto.BuscarPor(x => x.Id_DocumentoReceber == boletoRelacao.Id_DocumentoReceber);
                boletoInTableRelacao.Situacao = 2;
                boletoInTableRelacao.DiasEmAtraso = boletoRelacao.DiasEmAtraso;
                boletoInTableRelacao.Quitado = 1;
                await EnviarMensagemBoleto.EnviarMensagem(ModeloRequest, dadosAPI, dalBoleto, boletoInTableRelacao, true, false, dadosAPI.CodAPI_EnvioPDF);
            }
        }
    }
}
