using Aplication.IntegradorCRM.Metodos.Boleto;
using DataBase.IntegradorCRM.Data;
using Metodos.IntegradorCRM.Metodos;
using Modelos.IntegradorCRM.Models;
using Modelos.IntegradorCRM.Models.EF;
using Modelos.IntegradorCRMRM.Models;

namespace Aplication.IntegradorCRM.Servicos.Boleto
{
    internal class VerificacaoDeCobranca
    {
        internal async static Task RealizarCobranca(List<BoletoAcoesCRMModel> AcoesBoletoList, int diasAtraso, int DiasAtrasoRelBoleto, RelacaoBoletoCRMModel boletoRelacao, RetornoBoleto retornoBoleto,DadosAPIModels DadosAPI)
        {
            //Busca as configurações de dias de cobranças no DGV no Frm_GeralUC
            BoletoAcoesCRMModel? boletoAcaoBuscado = AcoesBoletoList.FirstOrDefault(x => x.Dias_Cobrancas.Equals(diasAtraso));

            if (boletoAcaoBuscado is null)
            {
                MetodosGerais.RegistrarLog("BOLETO", $"Não existe cobrança nem lembretes para data de vencimento do documento a receber: {boletoRelacao.Id_DocumentoReceber}. Atraso: {diasAtraso}!");

                return;
            }
            ModeloOportunidadeRequest atualizacaoRequest = await Boleto_Services.InstanciarAcaoRequestBoleto(retornoBoleto, diasAtraso);

            await VerificarAtraso(DiasAtrasoRelBoleto, diasAtraso, boletoRelacao, atualizacaoRequest,  DadosAPI, boletoAcaoBuscado);
        }
       

        private async static Task VerificarAtraso(int DiasAtrasoRelBoleto, int diasAtraso, RelacaoBoletoCRMModel boletoRelacao, ModeloOportunidadeRequest atualizarAcaoRequest, DadosAPIModels DadosAPI, BoletoAcoesCRMModel boletoAcaoBuscado)
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
                    MetodosGerais.RegistrarLog("BOLETO", $"Boleto {boletoRelacao.Id_DocumentoReceber} já existe na tabela relação. Está com {diasAtraso} dias em atraso. Não será realizado a cobrança porque é fim de semana!");
                }
                else
                {
                    using var dalBoleto = new DAL<RelacaoBoletoCRMModel>(new IntegradorDBContext());
                    await EnviarMensagemBoleto.EnviarMensagem(atualizarAcaoRequest, DadosAPI, dalBoleto, boletoRelacao, false, boletoAcaoBuscado.EnviarPDF, DadosAPI.CodAPI_EnvioPDF);
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
