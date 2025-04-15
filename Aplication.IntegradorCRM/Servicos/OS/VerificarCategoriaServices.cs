
using Aplication.IntegradorCRM.Metodos.OS;
using DataBase.IntegradorCRM.Data;
using Metodos.IntegradorCRM.Metodos;
using Modelos.IntegradorCRM.Models.EF;
using Modelos.IntegradorCRM.Models.Enuns;
using Modelos.IntegradorCRMRM.Models;

namespace Aplication.IntegradorCRM.Servicos.OS
{
    internal class VerificarCategoriaServices
    {

        internal static async Task VerificarCategorias(RetornoOrdemServico RetornoOS, RelacaoOrdemServicoModels OSInTBRelacao, DadosAPIModels DadosAPI, bool EnviarMensagemCancelamento)
        {
            using DAL<OSAcoesCRMModel> dalOSAcoes = new DAL<OSAcoesCRMModel>(new IntegradorDBContext());
            using DAL<RelacaoOrdemServicoModels> dalRelacaoOS = new DAL<RelacaoOrdemServicoModels>(new IntegradorDBContext());
            List<OSAcoesCRMModel> _oSAcoesCRM = (await dalOSAcoes.ListarAsync()).ToList();

            // Busca a Ação correspondente a situacao ou a categoria na OS
            ModeloOportunidadeRequest? ModeloRequest = await OS_Services.InstanciarOSAcoes(Convert.ToInt32(RetornoOS.Situacao), RetornoOS, _oSAcoesCRM);

            // Verifica se foi encontrado alguma Acão para a categoria ou situacao correspondente
            if (ModeloRequest is null)
            {
                MetodosGerais.RegistrarLog("OS", $"Error: Ação do CRM correspondende para categoria {RetornoOS.Id_CategoriaOS} ou -1 não cadastrada!");
                return;
            }
            
            OSInTBRelacao.Situacao = Convert.ToInt32(RetornoOS.Situacao);

            // verifica se a OS esta cancelada
            if ((Situacao_OS)Convert.ToInt32(RetornoOS.Situacao) is Situacao_OS.Cancelada)
            {
                if (EnviarMensagemCancelamento)
                    await OrdemServicoRequests.EnviarMensagemViaAPI(ModeloRequest, DadosAPI);
                
                OS_Services.ProcessarRespostaAtualizacao(OSInTBRelacao);
                MetodosGerais.RegistrarLog("OS", $"OS atualizada para Cancelada na TB relacao {RetornoOS.Id_Ordem_Servico}!");
                
            }
            else
            {
                if (Convert.ToInt32(RetornoOS.Id_CategoriaOS) != OSInTBRelacao.Id_CategoriaOS)
                {
                    if (await OrdemServicoRequests.EnviarMensagemViaAPI(ModeloRequest, DadosAPI))
                    {
                        MetodosGerais.RegistrarLog("OS", $"A categoria da ordem de serviço {OSInTBRelacao.Id_OrdemServico} mudou de {OSInTBRelacao.Id_CategoriaOS} para {Convert.ToInt32(RetornoOS.Id_CategoriaOS)}.");
                        OSInTBRelacao.Id_CategoriaOS = Convert.ToInt32(RetornoOS.Id_CategoriaOS);
                        OS_Services.ProcessarRespostaAtualizacao(OSInTBRelacao);
                    }
                    // Atualize a categoria na tabela de relação se necessário
                    //OrdemServicoRequests.AtualizarAcao(ModeloRequest, DadosAPI, OSInTableRelacao);
                    
                }
                else
                {
                    MetodosGerais.RegistrarLog("OS", $"Ordem de serviço {OSInTBRelacao.Id_OrdemServico} já existe na tabela com a mesma categoria. Cat OS: {OSInTBRelacao.Id_CategoriaOS}");
                }
            }

        }
    }
}
