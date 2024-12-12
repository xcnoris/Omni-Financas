
using Aplication.IntegradorCRM.Metodos.Boleto;
using DataBase.IntegradorCRM.Data;
using Metodos.IntegradorCRM.Metodos;
using Modelos.IntegradorCRM.Models.EF;
using Modelos.IntegradorCRM.Models;
using Modelos.IntegradorCRM.Models.Enuns;

namespace Aplication.IntegradorCRM.Servicos.Boleto
{
    internal class CancelamentoBoleto
    {
        public async static Task Cancelar(List<AcaoSituacao_Boleto_CRM> acoesSituacoesList, RelacaoBoletoCRMModel boletoRelacao, DadosAPIModels dadosAPI)
        {
            try
            {
                AcaoSituacao_Boleto_CRM? AcaoSituacaoBuscada = ObterAcaoCancelamento(acoesSituacoesList);
                if (AcaoSituacaoBuscada is null)
                {
                    MetodosGerais.RegistrarLog("ENV_BOLETO", $"[ERROR]: Ação de cancelamento não encontrada para o boleto: {boletoRelacao.Id_DocumentoReceber}!");
                    return;
                }

                var atualizacaoRequest = CriarAtualizarAcaoRequest(boletoRelacao, AcaoSituacaoBuscada, dadosAPI);

                try
                {
                    await CancelarBoletoNoCRM(boletoRelacao, atualizacaoRequest, dadosAPI);
                    MetodosGerais.RegistrarLog("BOLETO", $"Boleto {boletoRelacao.Id_DocumentoReceber} atualizado para a etapa '{AcaoSituacaoBuscada.Mensagem_Acao}'. CodOp: {boletoRelacao.Cod_Oportunidade}");
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

        private static AtualizarAcaoRequest CriarAtualizarAcaoRequest(RelacaoBoletoCRMModel boletoRelacao, AcaoSituacao_Boleto_CRM acaoSituacao, DadosAPIModels dadosAPI)
        {
            return new AtualizarAcaoRequest
            {
                codigoOportunidade = boletoRelacao.Cod_Oportunidade,
                codigoAcao = acaoSituacao.CodAcaoCRM,
                codigoJornada = dadosAPI.Cod_Jornada_Boleto,
                textoFollowup = acaoSituacao.Mensagem_Acao
            };
        }

        private static AcaoSituacao_Boleto_CRM? ObterAcaoCancelamento(List<AcaoSituacao_Boleto_CRM> acoesSituacoesList)
        {
            return acoesSituacoesList.FirstOrDefault(x => x.Situacao.Equals(Situacao_Boleto.Cancelada_Ou_Estornado));
        }


        private async static Task CancelarBoletoNoCRM(RelacaoBoletoCRMModel boletoRelacao, AtualizarAcaoRequest atualizarAcaoRequest, DadosAPIModels dadosAPI)
        {
            using var dalBoleto = new DAL<RelacaoBoletoCRMModel>(new IntegradorDBContext());

            boletoRelacao.Situacao = 3;
            // É passado o parametro "foiQuitado" como true para remover qualquer registro de aviso que esteja aguardando para envio
            await EnviarBoletoParaCRM.AtualizarAcao(atualizarAcaoRequest, dadosAPI.Token, dalBoleto, boletoRelacao, true);
         
        }
    }
}
