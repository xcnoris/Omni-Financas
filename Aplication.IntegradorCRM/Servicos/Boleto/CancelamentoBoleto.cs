
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
        public async Task Cancelar(List<AcaoSituacao_Boleto_CRM> acoesSituacoesList, int diasAtraso, string codigoJornada, DadosAPIModels DadosAPI, DAL<RelacaoBoletoCRMModel> dalBoleto, RelacaoBoletoCRMModel BoletoRelacao, bool foiQuitado, bool naTableRelacao)
        {
            try
            {
                AcaoSituacao_Boleto_CRM? AcaoSituacaoBuscada = ObterAcaoCancelamento(acoesSituacoesList);
                if (AcaoSituacaoBuscada is null)
                {
                    MetodosGerais.RegistrarLog("BOLETO", $"[ERROR]: Ação de quitação não encontrada para o boleto: {boletoRelacao.Id_DocumentoReceber}!");
                    return;
                }

                if (AcaoSituacaoBuscada is not null)
                {

                    string codAcao = AcaoSituacaoBuscada.Codigo_Acao;
                    string textoFollowup = AcaoSituacaoBuscada.Mensagem_Atualizacao;

                    AtualizarAcaoRequest AtualizarAcao = new AtualizarAcaoRequest
                    {
                        codigoOportunidade = BoletoRelacao.Cod_Oportunidade,
                        codigoAcao = codAcao,
                        codigoJornada = codigoJornada,
                        textoFollowup = textoFollowup
                    };

                    /*
                        Verifica se o boleto já esta na tabela relação,caso já esteja, significa que não precisa fazer
                        uma consuta no banco para descobrir o Id, visto que a instancia que veio no parametro já tem o Id

                    */
                    if (foiQuitado)
                    {
                        BoletoRelacao.Quitado = 1;
                    }
                    if (naTableRelacao == true)
                    {
                        BoletoRelacao.Situacao = 2;
                        await EnviarBoletoParaCRM.AtualizarAcao(AtualizarAcao, DadosAPI.Token, dalBoleto, BoletoRelacao, foiQuitado);
                    }
                    else
                    {
                        RelacaoBoletoCRMModel BoletoInTableRElacao = dalBoleto.BuscarPor(x => x.Id_DocumentoReceber == BoletoRelacao.Id_DocumentoReceber);
                        BoletoInTableRElacao.Situacao = BoletoRelacao.Situacao;
                        BoletoInTableRElacao.DiasEmAtraso = BoletoRelacao.DiasEmAtraso;
                        await EnviarBoletoParaCRM.AtualizarAcao(AtualizarAcao, DadosAPI.Token, dalBoleto, BoletoInTableRElacao, foiQuitado);
                    }



                    MetodosGerais.RegistrarLog("BOLETO", $"Boleto {BoletoRelacao.Id_DocumentoReceber} atualizado para a etapa '{textoFollowup}'. CodOp: {BoletoRelacao.Cod_Oportunidade}");
                }
                else
                {
                    MetodosGerais.RegistrarLog("BOLETO", $"[ERROR]: Ao consultar Dados da Ação para o boleto: {BoletoRelacao.Id_DocumentoReceber}!");
                    Message = $"[ERROR]: Ao consultar Dados da Ação para o boleto: {BoletoRelacao.Id_DocumentoReceber}!";
                    Status = false;
                }
            }
            catch (Exception ex)
            {
                MetodosGerais.RegistrarLog("BOLETO", $"[ERROR]: {ex.Message}.Para o boleto: {BoletoRelacao.Id_DocumentoReceber}");
                Message = $"[ERROR]: {ex.Message}";
                Status = false;
            }
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

        private AcaoSituacao_Boleto_CRM? ObterAcaoCancelamento(List<AcaoSituacao_Boleto_CRM> acoesSituacoesList)
        {
            return acoesSituacoesList.FirstOrDefault(x => x.Situacao.Equals(Situacao_Boleto.Quitado));
        }
    }
}
