using Aplication.IntegradorCRM.Metodos.Boleto;
using DataBase.IntegradorCRM.Data;
using Metodos.IntegradorCRM.Metodos;
using Microsoft.EntityFrameworkCore;
using Modelos.IntegradorCRM.Models;
using Modelos.IntegradorCRM.Models.EF;

namespace Aplication.IntegradorCRM.Servicos.Boleto
{
    internal class VerificacaoDeCobranca
    {
        internal async static Task RealizarCobranca(List<BoletoAcoesCRMModel> AcoesBoletoList, int diasAtraso, int DiasAtrasoRelBoleto, RelacaoBoletoCRMModel boletoRelacao, DadosAPIModels DadosAPI)
        {
            //Busca as configurações de dias de cobranças no DGV no Frm_GeralUC
            BoletoAcoesCRMModel? boletoAcaoBuscado = AcoesBoletoList.FirstOrDefault(x => x.Dias_Cobrancas.Equals(diasAtraso));

            if (boletoAcaoBuscado is null)
            {
                MetodosGerais.RegistrarLog("BOLETO", $"Não existe cobrança para o atraso do documento a receber: {boletoRelacao.Id_DocumentoReceber}. Atraso: {diasAtraso}!");

                return;
            }
            var atualizacaoRequest = CriarAtualizarAcaoRequest(boletoRelacao, boletoAcaoBuscado, DadosAPI);

            await VerificarAtraso(DiasAtrasoRelBoleto, diasAtraso, boletoRelacao, atualizacaoRequest,  DadosAPI);
        }
        private static AtualizarAcaoRequest CriarAtualizarAcaoRequest(RelacaoBoletoCRMModel boletoRelacao, BoletoAcoesCRMModel acaoSituacao, DadosAPIModels DadosAPI)
        {
            return new AtualizarAcaoRequest
            {
                codigoOportunidade = boletoRelacao.Cod_Oportunidade,
                codigoAcao = acaoSituacao.Codigo_Acao,
                codigoJornada = DadosAPI.Cod_Jornada_Boleto,
                textoFollowup = acaoSituacao.Mensagem_Atualizacao
            };
        }

        private async static Task VerificarAtraso(int DiasAtrasoRelBoleto, int diasAtraso, RelacaoBoletoCRMModel boletoRelacao, AtualizarAcaoRequest atualizarAcaoRequest, DadosAPIModels DadosAPI)
        {
            /*
                Verifica se o dia de atraso é igual ao registrado
                Caso seja, significa que já foi realizada a cobrança desse boleto para o determinado dia
            */
            if (DiasAtrasoRelBoleto != diasAtraso)
            {
                boletoRelacao.DiasEmAtraso = diasAtraso;

                // Verifica se hoje é final de semana, caso seja, não faz a cobrança dos boleto.
                if (DateTime.Today.DayOfWeek == DayOfWeek.Saturday || DateTime.Today.DayOfWeek == DayOfWeek.Sunday)
                {
                    /*
                         Cria um registro na tabela Cobrancas_Na_Segunda_CRM. Toda Segunda os registro que estao nessa tabela são
                         Lidos e enviado a mensagem de cobraça. No final e removido o registro
                    */
                    //// Anexe o boletoRelacao ao contexto como uma entidade existente
                    //IntegradorDBContext.Entry(boletoRelacao).State = EntityState.Unchanged;
                    CobrancaServicos CobrancasSegunda = new CobrancaServicos();
                    await CobrancasSegunda.SalvarDadosEmTableEspera(new CobrancasNaSegundaModel(){
                        CodigoJornada = DadosAPI.Cod_Jornada_Boleto,
                        BoletoId = boletoRelacao.Id,
                        NovoAtrasoBoleto = diasAtraso,
                        Cod_Oportunidade = boletoRelacao.Cod_Oportunidade
                    });
                }
                else
                {
                    using var dalBoleto = new DAL<RelacaoBoletoCRMModel>(new IntegradorDBContext());
                    await EnviarBoletoParaCRM.AtualizarAcao(atualizarAcaoRequest, DadosAPI.Token, dalBoleto, boletoRelacao, false);
                    MetodosGerais.RegistrarLog("BOLETO", $"Boleto já existe na tabela relação. Está com {diasAtraso} dias em atraso.");
                }
            }
            else
            {
                MetodosGerais.RegistrarLog("BOLETO", $"Boleto já existe na tabela relação. Esta na etapa atraso {diasAtraso}!");
            }
        }
    }
}
