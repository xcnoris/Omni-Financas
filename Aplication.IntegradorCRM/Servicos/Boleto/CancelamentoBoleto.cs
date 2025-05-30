
using Aplication.IntegradorCRM.Metodos.Boleto;
using DataBase.IntegradorCRM.Data;
using Metodos.IntegradorCRM.Metodos;
using Modelos.IntegradorCRM.Models.EF;
using Modelos.IntegradorCRM.Models;
using Modelos.IntegradorCRM.Models.Enuns;
using Modelos.IntegradorCRMRM.Models;

namespace Aplication.IntegradorCRM.Servicos.Boleto
{
    internal class CancelamentoBoleto
    {
        public async static Task Cancelar(RelacaoBoletoModel boletoRelacao, DadosAPIModels dadosAPI, RetornoBoleto retornoBoleto, bool EnviarMensagemCancelamento)
        {
            try
            {
                ModeloOportunidadeRequest? RequestCancelamento = await Boleto_Services.InstanciarAcaoRequestSitucaoBoleto(retornoBoleto, Situacao_Boleto.Cancelada_Ou_Estornado);
              

                if (RequestCancelamento is null)
                {
                    MetodosGerais.RegistrarLog("ENV_BOLETO", $"[ERROR]: Ação de cancelamento não encontrada para o boleto: {boletoRelacao.Id_DocumentoReceber}!");
                    return;
                }

                try
                {
                    if (EnviarMensagemCancelamento)
                    {
                        await CancelarBoleto(boletoRelacao, RequestCancelamento, dadosAPI);
                    }
                    else
                    {
                        boletoRelacao.Situacao = 3;
                        await Boleto_Services.AtualizarBoletoNoBanco(boletoRelacao);
                    }
                    MetodosGerais.RegistrarLog("BOLETO", $"Boleto {boletoRelacao.Id_DocumentoReceber} atualizado para a etapa Cancelada.");
                }
                catch (Exception ex)
                {
                    MetodosGerais.RegistrarLog("ENV_BOLETO", $"[ERROR]: Falha ao atualizar boleto {boletoRelacao.Id_DocumentoReceber} para etapa Cancelado - {ex.Message}");
                }

            }
            catch (Exception ex)
            {
                MetodosGerais.RegistrarLog("BOLETO", $"[ERROR]: {ex.Message}.Erro ao tentar atualizar boleto para etapa cancelado: {boletoRelacao.Id_DocumentoReceber}");
                //Message = $"[ERROR]: {ex.Message}";
                //Status = false;
            }
        }


        private async static Task CancelarBoleto(RelacaoBoletoModel boletoRelacao, ModeloOportunidadeRequest RequestCancelamento, DadosAPIModels DadosAPI)
        {
            using var dalBoleto = new DAL<RelacaoBoletoModel>(new IntegradorDBContext());

            boletoRelacao.Situacao = 3;
            // É passado o parametro "foiQuitado" como true para remover qualquer registro de aviso que esteja aguardando para envio
            await EnviarMensagemBoleto.EnviarMensagem(RequestCancelamento, DadosAPI, dalBoleto, boletoRelacao, true, false, false, DadosAPI.CodAPI_EnvioPDF);
        
        }
    }
}
