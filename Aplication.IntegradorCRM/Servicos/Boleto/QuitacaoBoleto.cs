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
        public async static Task Quitar(List<AcaoSituacao_Boleto_CRM> acoesSituacoesList, RelacaoBoletoCRMModel boletoRelacao, bool boletoJaEmTabela, DadosAPIModels dadosAPI)
        {
            var acaoSituacaoQuitacao = ObterAcaoQuitacao(acoesSituacoesList);
            if (acaoSituacaoQuitacao is null)
            {
                MetodosGerais.RegistrarLog("ENV_BOLETO", $"[ERROR]: Ação de quitação não encontrada para o boleto: {boletoRelacao.Id_DocumentoReceber}!");
                return;
            }

            var atualizarAcaoRequest = CriarAtualizarAcaoRequest(boletoRelacao, acaoSituacaoQuitacao, dadosAPI);
            boletoRelacao.Situacao = 2;
            boletoRelacao.Quitado = 1;

            try
            {

                await AtualizarBoletoNoCRM(boletoRelacao, atualizarAcaoRequest, dadosAPI, boletoJaEmTabela);
                //MetodosGerais.RegistrarLog("BOLETO", $"Boleto {boletoRelacao.Id_DocumentoReceber} já existe na tabela relação. Foi atualizado para etapa Pago!");
            }
            catch (Exception ex)
            {
                MetodosGerais.RegistrarLog("ENV_BOLETO", $"[ERROR]: Falha ao atualizar boleto {boletoRelacao.Id_DocumentoReceber} - {ex.Message}");
            }
        }


        private static AcaoSituacao_Boleto_CRM? ObterAcaoQuitacao(List<AcaoSituacao_Boleto_CRM> acoesSituacoesList)
        {
            return acoesSituacoesList.FirstOrDefault(x => x.Situacao.Equals(Situacao_Boleto.Quitado));
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

        private async static Task AtualizarBoletoNoCRM(RelacaoBoletoCRMModel boletoRelacao, AtualizarAcaoRequest atualizarAcaoRequest, DadosAPIModels dadosAPI, bool boletoJaEmTabela)
        {
            using var dalBoleto = new DAL<RelacaoBoletoCRMModel>(new IntegradorDBContext());
            
            if (boletoJaEmTabela)
            {
               
                await EnviarBoletoParaCRM.AtualizarAcao(atualizarAcaoRequest, dadosAPI.Token, dalBoleto, boletoRelacao, true, false);
            }
            else
            {
                var boletoInTableRelacao = dalBoleto.BuscarPor(x => x.Id_DocumentoReceber == boletoRelacao.Id_DocumentoReceber);
                boletoInTableRelacao.Situacao = 2;
                boletoInTableRelacao.DiasEmAtraso = boletoRelacao.DiasEmAtraso;
                boletoInTableRelacao.Quitado = 1;
                await EnviarBoletoParaCRM.AtualizarAcao(atualizarAcaoRequest, dadosAPI.Token, dalBoleto, boletoInTableRelacao, true, false);
            }
        }
    }
}
