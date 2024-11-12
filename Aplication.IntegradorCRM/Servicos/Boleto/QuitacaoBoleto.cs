using Aplication.IntegradorCRM.Metodos.Boleto;
using DataBase.IntegradorCRM.Data;
using Metodos.IntegradorCRM.Metodos;
using Modelos.IntegradorCRM.Models;
using Modelos.IntegradorCRM.Models.EF;
using Modelos.IntegradorCRM.Models.Enuns;

namespace Aplication.IntegradorCRM.Servicos.Boleto
{
    internal class QuitacaoBoleto
    {
        public async Task Quitar(List<AcaoSituacao_Boleto_CRM> acoesSituacoesList, RelacaoBoletoCRMModel boletoRelacao, bool boletoJaEmTabela, DadosAPIModels dadosAPI)
        {
            var acaoSituacaoQuitacao = ObterAcaoQuitacao(acoesSituacoesList);
            if (acaoSituacaoQuitacao is null)
            {
                MetodosGerais.RegistrarLog("BOLETO", $"[ERROR]: Ação de quitação não encontrada para o boleto: {boletoRelacao.Id_DocumentoReceber}!");
                return;
            }

            var atualizarAcaoRequest = CriarAtualizarAcaoRequest(boletoRelacao, acaoSituacaoQuitacao);

            try
            {
                await AtualizarBoletoNoCRM(boletoRelacao, atualizarAcaoRequest, dadosAPI, boletoJaEmTabela);
                MetodosGerais.RegistrarLog("BOLETO", $"Boleto {boletoRelacao.Id_DocumentoReceber} atualizado para a etapa '{acaoSituacaoQuitacao.Mensagem_Acao}'. CodOp: {boletoRelacao.Cod_Oportunidade}");
            }
            catch (Exception ex)
            {
                MetodosGerais.RegistrarLog("BOLETO", $"[ERROR]: Falha ao atualizar boleto {boletoRelacao.Id_DocumentoReceber} - {ex.Message}");
            }
        }


        private AcaoSituacao_Boleto_CRM? ObterAcaoQuitacao(List<AcaoSituacao_Boleto_CRM> acoesSituacoesList)
        {
            return acoesSituacoesList.FirstOrDefault(x => x.Situacao.Equals(Situacao_Boleto.Quitado));
        }

        private AtualizarAcaoRequest CriarAtualizarAcaoRequest(RelacaoBoletoCRMModel boletoRelacao, AcaoSituacao_Boleto_CRM acaoSituacao)
        {
            return new AtualizarAcaoRequest
            {
                codigoOportunidade = boletoRelacao.Cod_Oportunidade,
                codigoAcao = acaoSituacao.CodAcaoCRM,
                codigoJornada = acaoSituacao.CodAcaoCRM,
                textoFollowup = acaoSituacao.Mensagem_Acao
            };
        }

        private async Task AtualizarBoletoNoCRM(RelacaoBoletoCRMModel boletoRelacao, AtualizarAcaoRequest atualizarAcaoRequest, DadosAPIModels dadosAPI, bool boletoJaEmTabela)
        {
            using var dalBoleto = new DAL<RelacaoBoletoCRMModel>(new IntegradorDBContext());

            if (boletoJaEmTabela)
            {
                boletoRelacao.Situacao = 2;
                await EnviarBoletoParaCRM.AtualizarAcao(atualizarAcaoRequest, dadosAPI.Token, dalBoleto, boletoRelacao, true);
            }
            else
            {
                var boletoInTableRelacao = dalBoleto.BuscarPor(x => x.Id_DocumentoReceber == boletoRelacao.Id_DocumentoReceber);
                boletoInTableRelacao.Situacao = boletoRelacao.Situacao;
                boletoInTableRelacao.DiasEmAtraso = boletoRelacao.DiasEmAtraso;
                await EnviarBoletoParaCRM.AtualizarAcao(atualizarAcaoRequest, dadosAPI.Token, dalBoleto, boletoInTableRelacao, true);
            }
        }

    }
}
