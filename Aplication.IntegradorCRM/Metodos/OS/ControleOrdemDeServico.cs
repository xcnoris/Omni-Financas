using Integrador_Com_CRM.Data;
using Integrador_Com_CRM.Formularios;
using Integrador_Com_CRM.Models;
using Integrador_Com_CRM.Models.EF;

namespace Integrador_Com_CRM.Metodos.OS
{
    public class ControleOrdemDeServico
    {
        private readonly CrudOS _crudOS;
        private DAL<RelacaoOrdemServicoModels> dalOrdemServico;
        Frm_OSAcoesCRM_UC FrmOSAcoes;
        public ControleOrdemDeServico(Frm_OSAcoesCRM_UC frmOSAcao)
        {
            _crudOS = new CrudOS();
            FrmOSAcoes = frmOSAcao;
            dalOrdemServico = new DAL<RelacaoOrdemServicoModels>(new IntegradorDBContext());
        }

        public async Task VerificarNovosServicos(Frm_DadosAPIUC DadosAPI)
        {
            try
            {
                MetodosGerais.RegistrarInicioLog("OS");
                // Busca serviços no DB
                List<RetornoOrdemServico> OsList = _crudOS.BuscarOrdemDeServiçoInDB();
                List<RelacaoOrdemServicoModels> TableRelacaoOS = (await dalOrdemServico.ListarAsync()).ToList();

                // Passa por cada OS que retornar no select
                foreach ( var OS in OsList)
                {
                    // Acessa os valores diretamente das propriedades da classe RetornoOrdemServico
                    string id_ordemServico = OS.Id_Ordem_Servico.ToString();
                    string id_Categoria = OS.Id_CategoriaOS.ToString();
                    string cpf_cnpj_cliente = OS.Identificador_Cliente;
                    string email = OS.Email_Cliente;
                    string nomecliente = OS.Nome_Cliente;
                    string telefone = OS.Telefone;
                    string IdENome = $"{id_ordemServico} - {nomecliente}";
                    string codigoJornada = "C8DA5BD4D7";
                    int situacao = Convert.ToInt32(OS.Situacao);

                    // Crie uma nova instância de DAL para cada operação
                    using (var dalOrdemServicoUsing = new DAL<RelacaoOrdemServicoModels>(new IntegradorDBContext()))
                    {
                        // Verifica se a OS já esta na tabela de relação, caso ela este, significa que já existe um cady/oportunidade criada no CRM
                        RelacaoOrdemServicoModels OSInTableRelacao = TableRelacaoOS.FirstOrDefault(x => x.Id_OrdemServico == Convert.ToInt32(id_ordemServico));


                        RelacaoOrdemServicoModels OrdemServicoRelacao = new RelacaoOrdemServicoModels()
                        {
                            Id_OrdemServico = Convert.ToInt32(id_ordemServico),
                            Id_CategoriaOS = Convert.ToInt32(id_Categoria)

                        };


                        // Log para verificação
                        MetodosGerais.RegistrarLog("OS", $"Verificando OS {id_ordemServico}...");

                        if (OSInTableRelacao is null)
                        {
                            MetodosGerais.RegistrarLog("OS", $"OS {id_ordemServico} não encontrada na tabela de relação.");
                            if (situacao is not 1)
                            {
                                // Instancia a classe para a Ordem de Serviço que não foi encontrada na tabela Relacao_OrdemServico_CRM
                                ModeloOportunidadeRequest oportunidade = new ModeloOportunidadeRequest
                                {
                                    codigoApi = "4B29E80B1A",
                                    codigoOportunidade = "",
                                    origemOportunidade = "Lojamix - Consumo API",
                                    lead = new Lead
                                    {
                                        nomeLead = IdENome,
                                        telefoneLead = telefone,
                                        emailLead = email,
                                        cnpjLead = "",
                                        origemLead = "Serviço de consumo de API",
                                        contatos = new List<Contato>
                                {
                                    new Contato
                                    {
                                        nomeContato = nomecliente,
                                        telefoneContato = telefone,
                                        emailContato = email
                                    }
                                }
                                    },
                                    contato = new Contato
                                    {
                                        nomeContato = nomecliente,
                                        telefoneContato = telefone,
                                        emailContato = email
                                    },
                                    followups = new List<Followup>
                            {
                                new Followup { textoFollowup = "Essa oportunidade foi criada a partir da API de integração da LeadFinder" }
                            }
                                };

                                // tenta criar a oportunidade no CRM
                                OportunidadeResponse response = await EnviarOrdemServiçoForCRM.EnviarOportunidade(oportunidade, DadosAPI.Token, OrdemServicoRelacao, dalOrdemServicoUsing);


                                // Verifica se a Ordem de Serviço esta entrando com aguardando avaliação, caso nao esteja altera no CRM
                                if (!(Convert.ToInt32(id_Categoria) == 1))
                                {
                                    string cod_oportunidade = response.CodigoOportunidade.ToString();
                                    OSAcoesCRMModel OSModel = FrmOSAcoes.BuscarOSAcoes(Convert.ToInt32(id_Categoria));

                                    if (OSModel is null)
                                    {
                                        MetodosGerais.RegistrarLog("OS", $"Error: Ação do CRM correspondende para categoria {id_Categoria} não cadastrada!");
                                        MessageBox.Show(
                                          $"Error: Ação do CRM correspondende para categoria {id_Categoria} não cadastrada!",
                                          "Ocorreu uma problema",
                                          MessageBoxButtons.OK,
                                          MessageBoxIcon.Exclamation
                                      );
                                    }
                                    else
                                    {

                                        AtualizarAcaoRequest AtualizarAcao = new AtualizarAcaoRequest
                                        {
                                            codigoOportunidade = cod_oportunidade,
                                            codigoAcao = OSModel.Codigo_Acao,
                                            codigoJornada = codigoJornada,
                                            textoFollowup = OSModel.Mensagem_Atualizacao
                                        };

                                        OrdemServicoRelacao.Cod_Oportunidade = cod_oportunidade;
                                        // Atualize a categoria na tabela de relação se necessário
                                        RelacaoOrdemServicoModels TableRelacao = await dalOrdemServicoUsing.BuscarPorAsync(x => x.Id_OrdemServico == Convert.ToInt32(id_ordemServico));

                                        EnviarOrdemServiçoForCRM.AtualizarAcao(AtualizarAcao, DadosAPI.Token, TableRelacao, dalOrdemServicoUsing);
                                    }

                                }
                                MetodosGerais.RegistrarLog("OS", $"Oportunidade criada para OS {id_ordemServico} com código: {response.CodigoOportunidade}");
                            }
                            else
                            {
                                MetodosGerais.RegistrarLog("OS", $"OS: {id_ordemServico} consta como cancelada. Não será enviada para o CRM!");
                            }
                        }
                        else
                        {
                            // Caso a OS esteja na tabela de relação. Deve ser verificado se o ID da categoria mudou. 
                            // Método para ver se a categoria mudou

                            string cod_oportunidade = OSInTableRelacao.Cod_Oportunidade;
                            int idCategoria = Convert.ToInt32(id_Categoria);
                            int IdcategoriaExiste = OSInTableRelacao.Id_CategoriaOS;
                            int situacaoExistente = OSInTableRelacao.Situacao;

                            // Verifica se no DB Rel já esta marcado como 1 a situacao
                            // Caso esteja, significa que os ajustes já foram feitos
                            if (situacaoExistente is not 1)
                            {
                                OSAcoesCRMModel OSModel;
                                // Verifica se a Situacao é 1, caso seja, signica que esta cancelado a OS, e busca pelo ação -1
                                if (situacao is 1)
                                {
                                    OSModel = FrmOSAcoes.BuscarOSAcoes(-1);
                                }
                                else
                                {
                                    OSModel = FrmOSAcoes.BuscarOSAcoes(Convert.ToInt32(id_Categoria));
                                }

                                if (OSModel is null)
                                {
                                    MetodosGerais.RegistrarLog("OS", $"Error: Ação do CRM correspondende para categoria {id_Categoria} ou -1 não cadastrada!");
                                    MessageBox.Show(
                                        $"Error: Ação do CRM correspondende para categoria {id_Categoria} ou -1 não cadastrada!",
                                        "Ocorreu uma problema",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Exclamation
                                        );
                                }
                                else
                                {

                                    AtualizarAcaoRequest AtualizarAcao = new AtualizarAcaoRequest
                                    {
                                        codigoOportunidade = cod_oportunidade,
                                        codigoAcao = OSModel.Codigo_Acao,
                                        codigoJornada = codigoJornada,
                                        textoFollowup = OSModel.Mensagem_Atualizacao
                                    };
                                    OSInTableRelacao.Id_CategoriaOS = idCategoria;
                                    OSInTableRelacao.Situacao = situacao;

                                    if (situacao is 1)
                                    {
                                        EnviarOrdemServiçoForCRM.AtualizarAcao(AtualizarAcao, DadosAPI.Token, OSInTableRelacao, dalOrdemServicoUsing);
                                    }
                                    else
                                    {

                                        if (idCategoria != IdcategoriaExiste)
                                        {


                                            //RelacaoOrdemServicoModels TablerelacaoOS = await dalOrdemServico.BuscarPorAsync(x => x.Id_OrdemServico == Convert.ToInt32(id_ordemServico));

                                            // Atualize a categoria na tabela de relação se necessário
                                            EnviarOrdemServiçoForCRM.AtualizarAcao(AtualizarAcao, DadosAPI.Token, OSInTableRelacao, dalOrdemServicoUsing);


                                            MetodosGerais.RegistrarLog("OS", $"A categoria da ordem de serviço {id_ordemServico} mudou de {IdcategoriaExiste} para {id_Categoria}.");

                                        }
                                        else
                                        {
                                            MetodosGerais.RegistrarLog("OS", $"Ordem de serviço {id_ordemServico} já existe na tabela com a mesma categoria.");
                                        }
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
                MetodosGerais.RegistrarFinalLog("OS");
            }
            catch (Exception ex)
            {
                MetodosGerais.RegistrarInicioLog("OS");
                MetodosGerais.RegistrarLog("OS", $"[ERROR]: {ex.Message}");
                MetodosGerais.RegistrarFinalLog("OS");
                throw;
            }
        }
    }
}
