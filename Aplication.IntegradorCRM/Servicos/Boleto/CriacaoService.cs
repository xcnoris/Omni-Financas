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
        internal async Task<bool> EnviarMensagemCriacao()
        {
            using DAL<AcaoSituacao_Boleto_CRM> dalAcaoSitBoleto = new DAL<AcaoSituacao_Boleto_CRM>(new IntegradorDBContext());
            AcaoSituacao_Boleto_CRM? AcaoSitBoleto = await dalAcaoSitBoleto.BuscarPorAsync(x => x.Situacao == Situacao_Boleto.Aberto);

            if (AcaoSitBoleto is not null)
            {Come
                ModeloOportunidadeRequest oportunidade = new ModeloOportunidadeRequest();
                oportunidade = oportunidade.CriarOportunidade(linha.Celular, );

                BoletoRelacao = new RelacaoBoletoCRMModel();
                BoletoRelacao = BoletoRelacao.InstanciaDados(linha);

                // tenta criar a oportunidade no CRM
                OportunidadeResponse response = await EnviarMensagemBoleto.EnviarMensagemCriacao(oportunidade, DadosAPI, dalBoletoUsing, BoletoRelacao, EnviarPDFaoCriarOPT, DadosAPI.CodAPI_EnvioPDF);
            }
        }
    }
}
