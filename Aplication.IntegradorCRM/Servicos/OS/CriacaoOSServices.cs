

using Aplication.IntegradorCRM.Metodos.Boleto;
using Aplication.IntegradorCRM.Metodos.OS;
using Aplication.IntegradorCRM.Servicos.Boleto;
using DataBase.IntegradorCRM.Data;
using Metodos.IntegradorCRM.Metodos;
using Modelos.IntegradorCRM.Models.EF;
using Modelos.IntegradorCRM.Models.Enuns;
using Modelos.IntegradorCRMRM.Models;

namespace Aplication.IntegradorCRM.Servicos.OS
{
    internal class CriacaoOSServices
    {
        internal async static Task RealizarProcessoCriacaoOS(DadosAPIModels DadosAPI, RetornoOrdemServico RetornoOS, RelacaoOrdemServicoModels RelacaoOS)
        {
            using DAL<RelacaoOrdemServicoModels> _dalRelacaoOS = new DAL<RelacaoOrdemServicoModels>(new IntegradorDBContext());

            ModeloOportunidadeRequest OportunidadRequest = await OS_Services.InstanciarAcaoRequestSitucaoOS( Situacao_OS.Criacao, RetornoOS.Celular);

            if (OportunidadRequest is null)
                return;

            // Tenta enviar a mensagem de criacão da OS, caso nao der certo a criacão, gera um log
            if (await EnviarMensagemCriacao(OportunidadRequest, DadosAPI, RelacaoOS, _dalRelacaoOS) is false)
            {
                MetodosGerais.RegistrarLog("OS", $"Erro ao enviar mensagem de criação da OS {RelacaoOS.Id_OrdemServico} - Cat OS: {RelacaoOS.Id_CategoriaOS}");
            }

            OSEntradaServices.VerificarOSEntrada(Convert.ToInt32(RetornoOS.Id_CategoriaOS), DadosAPI, RelacaoOS, RetornoOS.Celular);
        }


        private async static Task<bool> EnviarMensagemCriacao(ModeloOportunidadeRequest request, DadosAPIModels DadosAPI, RelacaoOrdemServicoModels tableRelacaoOS, DAL<RelacaoOrdemServicoModels> dalRelacaoOS)
        {
            MetodosGerais.RegistrarLog("OS", "Criando Oportunidade no CRM....");
            
            if (await OrdemServicoRequests.EnviarMensagemViaAPI(request, DadosAPI))
            {
                // Processo de criação da OS no DB
                await OS_Services.ProcessarRespostaSucesso(tableRelacaoOS, dalRelacaoOS);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
