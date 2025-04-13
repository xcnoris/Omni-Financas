
using Aplication.IntegradorCRM.Metodos.OS;
using DataBase.IntegradorCRM.Data;
using Metodos.IntegradorCRM.Metodos;
using Modelos.IntegradorCRM.Models.EF;
using Modelos.IntegradorCRMRM.Models;

namespace Aplication.IntegradorCRM.Servicos.OS
{
    internal class OSEntradaServices
    {
        public async static Task VerificarOSEntrada(int idCategoria, DadosAPIModels DadosAPI, RelacaoOrdemServicoModels RelOSModel, string celular)
        {
            using DAL<RelacaoOrdemServicoModels> dalRelOSModel = new DAL<RelacaoOrdemServicoModels>(new IntegradorDBContext());


            // Instancia a ser enviado para atualizar a etapa da oportunidade no CRM
            ModeloOportunidadeRequest RequestAtualzacao = await OS_Services.InstanciarAcaoRequest(idCategoria, celular);
            if(RequestAtualzacao is null)
                return;

            await Task.Delay(30000); // 30 Segundos
            if (await OrdemServicoRequests.EnviarMensagemViaAPI(RequestAtualzacao, DadosAPI))
            {
                // Atualize a categoria na tabela de relação se necessário
                RelacaoOrdemServicoModels TableRelacao = await dalRelOSModel.BuscarPorAsync(x => x.Id_OrdemServico == RelOSModel.Id_OrdemServico);

                OS_Services.ProcessarRespostaAtualizacao(TableRelacao);
            }
            else
            {
                MetodosGerais.RegistrarLog("OS", $"Ocorreu um erro ao enviar a mensagem de catergoria da OS {RelOSModel.Id_OrdemServico}. Cat OS: {idCategoria}!");
            }
        }
    }
}
