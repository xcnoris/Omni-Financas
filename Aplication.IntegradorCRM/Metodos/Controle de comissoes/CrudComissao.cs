using DataBase.IntegradorCRM.Data.DataBase;
using Metodos.IntegradorCRM.Metodos;
using Modelos.IntegradorCRM.Models.Retornos;
using System.Data;

namespace Aplication.IntegradorCRM.Metodos.ControleComissao
{
    internal class CrudComissao
    {
        private ComandosDB _comandosDB;

        internal async Task<List<RetornoComissao>> BuscarComissoesInDB()
        {
            _comandosDB = new ComandosDB();

            try
            {
                string query = @$"
                    SELECT 
	                    DISTINCT codigo_pedido,
	                    Situacao_Pedido
                    FROM 
                        Controle_Comissao_Item_Demander 
                ";

                // Converte o resultado do select em DataTable
                DataTable retornoOS = await _comandosDB.ExecuteQuery(query);

                List<RetornoComissao> retornoComissoes = DataTableToList(retornoOS);

                MetodosGerais.RegistrarLog("Comissao_CRUD", $"Foram encontradas {retornoComissoes.Count()} comissoes no banco de dados\n");
                return retornoComissoes;
            }
            catch (Exception ex)
            {
                MetodosGerais.RegistrarLog("Comissao_CRUD", $"[ERROR]: {ex.Message} - {_comandosDB.Mensagem}");
                return null;
            }
        }

        private List<RetornoComissao> DataTableToList(DataTable dt)
        {
            try
            {
                List<RetornoComissao> listaRetornoComissao = new List<RetornoComissao> ();

                foreach (DataRow linha in dt.Rows)
                {
                    RetornoComissao Rcomissoes = new RetornoComissao()
                    {
                        Codigo_Pedido = Convert.ToInt32(linha["codigo_pedido"]),
                        Situacao_Pedido = Convert.ToInt32(linha["Situacao_Pedido"])
                    };

                    listaRetornoComissao.Add( Rcomissoes );
                }
                return listaRetornoComissao;
            }
            catch (Exception ex)
            {
                MetodosGerais.RegistrarLog("Comissao_CRUD", ex.Message);
                return null;
            }
        }

    }
}
