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

        internal List<RetornoOrdemServico> BuscarOrdemDeServiçoInDB()
        {
            try
            {

                // Buscar serviços no banco de dados a partir de uma data ou parâmetro definido
                string query = @"SELECT 
                        os.id_ordem_servico, 
                        CASE 
                            WHEN e.tipo_entidade = 1 THEN pf.cpf 
                            WHEN e.tipo_entidade = 2 THEN pj.cnpj 
                            ELSE 'Tipo de entidade desconhecido' 
                        END AS identificador_cliente,
                        os.nome_cliente, 
                        CONCAT(os.celular_ddd_cliente, os.celular_numero_cliente) AS telefone,
                        os.email_cliente,
                        os.id_categoria_ordem_servico,
	                    os.situacao
                    FROM 
                        ordem_servico os
                    INNER JOIN 
                        entidade e ON os.id_entidade_cliente = e.id_entidade
                    LEFT JOIN 
                        pessoa_juridica pj ON e.id_entidade = pj.id_entidade AND e.tipo_entidade = 2
                    LEFT JOIN 
                        pessoa_fisica pf ON e.id_entidade = pf.id_entidade AND e.tipo_entidade = 1
                    WHERE 
                         OS.data_hora_cadastro >= '01/10/2024'
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
                        Identificador_Cliente = linha["identificador_cliente"].ToString(),
                        Nome_Cliente = linha["nome_cliente"].ToString(),
                        Telefone = linha["telefone"].ToString(),
                        Email_Cliente = linha["email_cliente"].ToString(),
                        Id_CategoriaOS = linha["id_categoria_ordem_servico"].ToString(),
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
