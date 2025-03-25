using Aplication.IntegradorCRM.Servicos;
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
        private readonly DAL<RelacaoOrdemServicoModels> dalOrdemServico;
        private readonly DAL<AcaoSituacao_OS_CRM> _dalAcaoSituacaoOS;
        private readonly DAL<OSAcoesCRMModel> _dalOSAcao = new DAL<OSAcoesCRMModel>(new IntegradorDBContext());
        private List<OSAcoesCRMModel> _oSAcoesCRM;
        public ControleOrdemDeServico()
        {
            _crudOS = new CrudOS();
            dalOrdemServico = new DAL<RelacaoOrdemServicoModels>(new IntegradorDBContext());
            _dalAcaoSituacaoOS = new DAL<AcaoSituacao_OS_CRM>(new IntegradorDBContext());
          
        }

        public async Task VerificarNovosServicos(DadosAPIModels DadosAPI, DateTime Datetime)
        {
            try
            {
                _oSAcoesCRM = (await _dalOSAcao.ListarAsync()).ToList();
                MetodosGerais.RegistrarInicioLog("OS");
                // Busca serviços no DB
                List<RetornoOrdemServico> OsList = _crudOS.BuscarOrdemDeServiçoInDB(Datetime);
                List<RelacaoOrdemServicoModels> TableRelacaoOS = (await dalOrdemServico.ListarAsync()).ToList();

                // Passa por cada OS que retornar no select
                foreach ( var OS in OsList)
                {
                    // Acessa os valores diretamente das propriedades da classe RetornoOrdemServico
                    string id_ordemServico = OS.Id_Ordem_Servico;
                    string id_Categoria = OS.Id_CategoriaOS;
                    string cpf_cnpj_cliente = OS.Identificador_Cliente;
                    string? email = OS.Email_Cliente;
                    string nomecliente = OS.Nome_Cliente;
                    string telefone = OS.Telefone;
                    string IdENome = $"{id_ordemServico} - {nomecliente}";
                    int situacao = Convert.ToInt32(OS.Situacao);

                    // Crie uma nova instância de DAL para cada operação
                    using (var dalOrdemServicoUsing = new DAL<RelacaoOrdemServicoModels>(new IntegradorDBContext()))
                    {
                        // Verifica se a OS já esta na tabela de relação, caso ela este, significa que já existe um cady/oportunidade criada no CRM
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
                            Caso a OS já esteja vindo como cancelada do modrniza, o integrador não vai nem tentar cria-la no CRM nem salvar na TB relaçã
                        */
                        if (OSInTableRelacao is null)
                        {
                            MetodosGerais.RegistrarLog("OS", $"OS {id_ordemServico} não encontrada na tabela de relação.");

                            if (situacao is not 1)
                            {
                                await OS_Services.EnviarMensagemCriacao(DadosAPI, "55" + OS.Telefone, OSInTableRelacao, dalOrdemServicoUsing);
                                // Verifica se a Ordem de Serviço esta entrando com aguardando analise, caso nao esteja altera no CRM

                                OS_Services.VerificarOSEntrada(Convert.ToInt32(OS.Id_CategoriaOS), _oSAcoesCRM, DadosAPI, OrdemServicoRelacao, dalOrdemServicoUsing);

                                MetodosGerais.RegistrarLog("OS", $"Processo de criação de OS realizado! OS {id_ordemServico}");
                            }
                            else
                            {
                                MetodosGerais.RegistrarLog("OS", $"OS: {id_ordemServico} consta como cancelada. Não será enviada mensagem!");
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
                                // Busca a Ação correspondente a situacao ou a categoria na OS
                                ModeloOportunidadeRequest? ModeloRequest = await OS_Services.InstanciarOSAcoes(situacao, OS, _oSAcoesCRM);

                                // Verifica se foi encontrado alguma Acão para a categoria ou situacao correspondente
                                if (ModeloRequest is null)
                                {
                                    MetodosGerais.RegistrarLog("OS", $"Error: Ação do CRM correspondende para categoria {id_Categoria} ou -1 não cadastrada!");
                                    continue ;
                                }
                              
                                //AtualizarAcaoRequest AtualizarAcao = OS_Services.InstanciarAcaoRequest(OSModel, cod_oportunidade, codigoJornada);

                                OSInTableRelacao.Id_CategoriaOS = idCategoria;
                                OSInTableRelacao.Situacao = situacao;

                                if (situacao is 1)
                                {
                                    OrdemServicoRequests.AtualizarAcao(ModeloRequest, DadosAPI, OSInTableRelacao);
                                    MetodosGerais.RegistrarLog("OS", $"OS {id_ordemServico} mudou para a etapa Cancelada no CRM!");
                                }
                                else
                                {
                                    if (idCategoria != IdcategoriaExiste)
                                    {
                                        // Atualize a categoria na tabela de relação se necessário
                                        OrdemServicoRequests.AtualizarAcao(ModeloRequest, DadosAPI, OSInTableRelacao);
                                        MetodosGerais.RegistrarLog("OS", $"A categoria da ordem de serviço {id_ordemServico} mudou de {IdcategoriaExiste} para {id_Categoria}.");
                                    }
                                    else
                                    {
                                        MetodosGerais.RegistrarLog("OS", $"Ordem de serviço {id_ordemServico} já existe na tabela com a mesma categoria.");
                                    }
                                }
                             
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
