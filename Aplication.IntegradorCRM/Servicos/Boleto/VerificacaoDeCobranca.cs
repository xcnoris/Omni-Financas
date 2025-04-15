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
        internal async static Task RealizarCobranca(List<BoletoAcoesCRMModel> AcoesBoletoList, int diasAtraso, int DiasAtrasoRelBoleto, RelacaoBoletoCRMModel boletoRelacao, RetornoBoleto retornoBoleto,DadosAPIModels DadosAPI, bool PermitirEnvioFinsDeSemana)
        {
            //Busca as configurações de dias de cobranças no DGV no Frm_GeralUC
            BoletoAcoesCRMModel? boletoAcaoBuscado = AcoesBoletoList.FirstOrDefault(x => x.Dias_Cobrancas.Equals(diasAtraso));

            if (boletoAcaoBuscado is null)
            {
                MetodosGerais.RegistrarLog("BOLETO", $"Não existe cobrança nem lembretes para data de vencimento do documento a receber: {boletoRelacao.Id_DocumentoReceber}. Atraso: {diasAtraso}!");

                return;
            }
            ModeloOportunidadeRequest atualizacaoRequest = await Boleto_Services.InstanciarAcaoRequestBoleto(retornoBoleto, diasAtraso);

            await VerificarAtraso(DiasAtrasoRelBoleto, diasAtraso, boletoRelacao, atualizacaoRequest,  DadosAPI, boletoAcaoBuscado, PermitirEnvioFinsDeSemana);
        }

        private async static Task VerificarAtraso(int DiasAtrasoRelBoleto, int diasAtraso, RelacaoBoletoCRMModel boletoRelacao, ModeloOportunidadeRequest atualizarAcaoRequest, DadosAPIModels DadosAPI, BoletoAcoesCRMModel boletoAcaoBuscado, bool PermitirEnvioFinsDeSemana)
        {
            if (DiasAtrasoRelBoleto != diasAtraso)
            {
                boletoRelacao.DiasEmAtraso = diasAtraso;
                bool ehFimDeSemana = DateTime.Today.DayOfWeek == DayOfWeek.Saturday || DateTime.Today.DayOfWeek == DayOfWeek.Sunday;
                string logMsg = $"Boleto {boletoRelacao.Id_DocumentoReceber} já existe na tabela relação. Está com {diasAtraso} dias em atraso.";

                if (PermitirEnvioFinsDeSemana || !ehFimDeSemana)
                {
                    using var dalBoleto = new DAL<RelacaoBoletoCRMModel>(new IntegradorDBContext());
                    await EnviarMensagemBoleto.EnviarMensagem(atualizarAcaoRequest, DadosAPI, dalBoleto, boletoRelacao, false, boletoAcaoBuscado.EnviarPDF, DadosAPI.CodAPI_EnvioPDF);
                    MetodosGerais.RegistrarLog("BOLETO", logMsg);
                }
                else
                {
                    MetodosGerais.RegistrarLog("BOLETO", $"{logMsg}. Não será realizada a cobrança porque é fim de semana!");
                }
            }
            else
            {
                MetodosGerais.RegistrarLog("BOLETO", $"Boleto já existe na tabela relação. Está na etapa atraso {diasAtraso}!");
            }
        }
    }
}
