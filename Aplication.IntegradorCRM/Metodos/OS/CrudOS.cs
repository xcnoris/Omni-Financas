using DataBase.IntegradorCRM.Data.DataBase;
using Metodos.IntegradorCRM.Metodos;
using Modelos.IntegradorCRMRM.Models;
using System.Data;

namespace Aplication.IntegradorCRM.Metodos.OS
{
    internal class CrudOS
    {


        private ConexaoDB _conexaoDB;
        private ComandosDB _comandosDB;

        public CrudOS()
        {
            string Validacao = "";
            _conexaoDB = new ConexaoDB(Validacao);
            _comandosDB = new ComandosDB(_conexaoDB);
        }

        internal List<RetornoOrdemServico> BuscarOrdemDeServiçoInDB(DateTime DateTime)
        {
            try
            {

                // Buscar serviços no banco de dados a partir de uma data ou parâmetro definido
                string query = @$"
                 SELECT 
                      os.id_ordem_servico, 
                        os.nsu,
                        CASE 
                            WHEN e.tipo_entidade = 1 THEN pf.cpf 
                            WHEN e.tipo_entidade = 2 THEN pj.cnpj 
                            ELSE 'Tipo de entidade desconhecido' 
                        END AS identificador_cliente,
                        e.id_entidade,
                        os.nome_cliente, 
	                  CASE 
                            WHEN ent.tipo_entidade = 1 THEN LEFT(ent.nome, CHARINDEX(' ', ent.nome + ' ') - 1)
                            WHEN ent.tipo_entidade = 2 THEN pj.nome_fantasia 
                            ELSE 'Tipo de entidade desconhecido' 
                        END AS nomeFantasia,
                        CONCAT(
                            COALESCE(ent.celular_ddd, ''),
                            CASE 
                                WHEN LEN(LTRIM(RTRIM(COALESCE(ent.celular_numero, '')))) = 8 AND LEFT(LTRIM(RTRIM(ent.celular_numero)), 1) != '3' THEN 
                                    -- Coloca 9 somente se for número de 8 dígitos e não começar com 3 (fixo)
                                    CONCAT('9', LTRIM(RTRIM(ent.celular_numero)))
                                ELSE 
                                    LTRIM(RTRIM(ent.celular_numero))
                            END
                        ) AS celular,
                        os.email_cliente,
                        os.id_categoria_ordem_servico,
                        catOS.nome as categoria,
                        os.situacao
                 FROM 
                     ordem_servico os
                 INNER JOIN 
                     entidade e ON os.id_entidade_cliente = e.id_entidade
                 INNER JOIN
	                categoria_ordem_servico catOS on catOS.id_categoria_ordem_servico = os.id_categoria_ordem_servico
                 LEFT JOIN 
                     pessoa_juridica pj ON e.id_entidade = pj.id_entidade AND e.tipo_entidade = 2
                 LEFT JOIN 
                     pessoa_fisica pf ON e.id_entidade = pf.id_entidade AND e.tipo_entidade = 1
                    WHERE 
                         OS.data_hora_cadastro >= '{DateTime}' 
                        
                ";
                //string query = "SELECT id_ordem_servico, nome_cliente, fone_ddd_cliente + fone_numero_cliente AS telefone, email_cliente, id_categoria_ordem_servico FROM ordem_servico WHERE id_ordem_servico = 8674";

                // Converte o resultado do select em DataTable
                DataTable retornoOS = _comandosDB.ExecuteQuery(query);

                List<RetornoOrdemServico> retornoOSs = DataTableToList(retornoOS);

                MetodosGerais.RegistrarLog("OS", $"Foram encontradas {retornoOSs.Count()} ordem de serviço no banco de dados\n");
                return retornoOSs;
            }
            catch (Exception ex)
            {
                MetodosGerais.RegistrarLog("OS", $"[ERROR]: {ex.Message} - {_comandosDB.Mensagem}");
                return null;
            }
        }

        private List<RetornoOrdemServico> DataTableToList(DataTable dt)
        {
            try
            {
                List<RetornoOrdemServico> listaRetornoOS = new List<RetornoOrdemServico> ();

                foreach (DataRow linha in dt.Rows)
                {
                    RetornoOrdemServico ROS = new RetornoOrdemServico()
                    {
                        Id_Ordem_Servico = linha["id_ordem_servico"].ToString(),
                        NSU = linha["nsu"].ToString(),
                        Id_entidade = linha["id_entidade"].ToString(),
                        Identificador_Cliente = linha["identificador_cliente"].ToString(),
                        Nome_RazSocial = linha["nome_cliente"].ToString(),
                        PrimNome_Fantasia = linha["nomeFantasia"].ToString(),
                        Celular = linha["celular"].ToString(),
                        Email_Cliente = linha["email_cliente"].ToString(),
                        Id_CategoriaOS = linha["id_categoria_ordem_servico"].ToString(),
                        Categoria = linha["categoria"].ToString(),
                        Situacao = linha["situacao"].ToString()
                    };

                    listaRetornoOS.Add( ROS );
                }
                return listaRetornoOS;
            }
            catch (Exception ex)
            {
                MetodosGerais.RegistrarLog("OS", ex.Message);
                return null;
            }
        }

    }
}
