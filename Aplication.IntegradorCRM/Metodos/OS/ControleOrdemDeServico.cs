using Aplication.IntegradorCRM.Servicos.OS;
using DataBase.IntegradorCRM.Data;
using Metodos.IntegradorCRM.Metodos;
using Modelos.IntegradorCRM.Models;
using Modelos.IntegradorCRM.Models.EF;
using Modelos.IntegradorCRMRM.Models;

namespace Aplication.IntegradorCRM.Metodos.OS
{
    public class ControleOrdemDeServico
    {
        private readonly CrudOS _crudOS;
        
        private List<OSAcoesModel> _oSAcoesCRM;
        public ControleOrdemDeServico()
        {
            _crudOS = new CrudOS();
        }

        public async Task VerificarNovosServicos(DadosAPIModels DadosAPI, Configuracao_Geral FrmConfigUC)
        {

            using DAL<RelacaoOrdemServicoModels> dalOrdemServico = new DAL<RelacaoOrdemServicoModels>(new IntegradorDBContext());
            using DAL<AcaoSituacao_OS> _dalAcaoSituacaoOS = new DAL<AcaoSituacao_OS>(new IntegradorDBContext());
            using DAL<OSAcoesModel> _dalOSAcao = new DAL<OSAcoesModel>(new IntegradorDBContext());

            try
            {
                MetodosGerais.RegistrarInicioLog("OS");
                // Busca serviços no DB
                List<RetornoOrdemServico> OsList = _crudOS.BuscarOrdemDeServiçoInDB(FrmConfigUC.DataOSSelect);
                List<RelacaoOrdemServicoModels> TableRelacaoOS = (await dalOrdemServico.ListarAsync()).ToList();


                // Passa por cada OS que retornar no select
                foreach ( var RetornoOS in OsList)
                {
                    // Acessa os valores diretamente das propriedades da classe RetornoOrdemServico
                    string id_ordemServico = RetornoOS.Id_Ordem_Servico;
                    string id_Categoria = RetornoOS.Id_CategoriaOS;
                    int situacao = Convert.ToInt32(RetornoOS.Situacao);

                    // Crie uma nova instância de DAL para cada operação
                    using (var dalOrdemServicoUsing = new DAL<RelacaoOrdemServicoModels>(new IntegradorDBContext()))
                    {
                        // Verifica se a OS já esta na tabela de relação, caso ela este, significa que o Omni já está controlando essa OS
                        RelacaoOrdemServicoModels OSInTableRelacao = TableRelacaoOS.FirstOrDefault(x => x.Id_OrdemServico == Convert.ToInt32(id_ordemServico));

                        RelacaoOrdemServicoModels OrdemServicoRelacao = new RelacaoOrdemServicoModels()
                        {
                            Id_OrdemServico = Convert.ToInt32(id_ordemServico),
                            Id_CategoriaOS = Convert.ToInt32(id_Categoria),
                            Situacao = situacao
                        };

                        // Log para verificação
                        MetodosGerais.RegistrarLog("OS", $"Verificando OS {id_ordemServico}...");
                        /*
                            Caso seja null, siginifica que o ID da OS não foi encontrado na TB relação, então vai ser tentado criar uma oportunidade no
                            no crm, e incluido o ID da OS na TB Relação
                            Caso a OS já esteja vindo como cancelada do moderniza, o integrador não vai nem tentar enviar a mensagem nem salvar na TB relação
                        */
                        if (OSInTableRelacao is null)
                        {
                            //MetodosGerais.RegistrarLog("OS", $"OS {id_ordemServico} não encontrada na tabela de relação.");

                            if (situacao is not 1)
                            {
                                await CriacaoOSServices.RealizarProcessoCriacaoOS(DadosAPI, RetornoOS, OrdemServicoRelacao);
                            }
                            else
                            {
                                MetodosGerais.RegistrarLog("OS", $"OS: {id_ordemServico} não esta sendo sincronizada pelo CDI OmniService e consta como cancelada no ERP. Não será enviada nenhuma mensagem!");
                            }
                        }
                        else
                        {
                            // Caso a OS esteja na tabela de relação. Deve ser verificado se o ID da categoria mudou. 
                            // Método para ver se a categoria mudou

                            int idCategoria = Convert.ToInt32(id_Categoria);
                            int IdcategoriaExiste = OSInTableRelacao.Id_CategoriaOS;
                            int situacaoExistente = OSInTableRelacao.Situacao;

                            // Verifica se no TB Rel já esta marcado como 1 a situacao
                            // Caso esteja, significa que os ajustes já foram feitos
                            if (situacaoExistente is not 1)
                            {
                                await VerificarCategoriaServices.VerificarCategorias(RetornoOS, OSInTableRelacao, DadosAPI, FrmConfigUC.ChBox_OSEnviarMensCancel);
                            }
                            else
                            {
                                MetodosGerais.RegistrarLog("OS", $"OS: {id_ordemServico} já foi ajustada como Cancelada!");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MetodosGerais.RegistrarErroExcecao("OS", "Erro durante consulta das OS:", ex);
                throw;
            }
            finally
            {
                MetodosGerais.RegistrarFinalLog("OS");
            }
        }
    }
}
