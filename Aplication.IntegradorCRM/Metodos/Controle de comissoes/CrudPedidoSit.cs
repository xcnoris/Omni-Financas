using DataBase.IntegradorCRM.Data.DataBase;
using Metodos.IntegradorCRM.Metodos;
using Modelos.IntegradorCRM.Models.Retornos;
using System.Data;

namespace Aplication.IntegradorCRM.Metodos.ControleComissao
{
    internal class CrudPedidoSit
    {


        private ConexaoDB _conexaoDB;
        private ComandosDB _comandosDB;

        public CrudPedidoSit()
        {
            string Validacao = "";
            _conexaoDB = new ConexaoDB(Validacao);
            _comandosDB = new ComandosDB(_conexaoDB);
        }

        internal async Task<List<RetornoPedidoSit>> BuscarPedidosSitInDB()
        {
            try
            {
                string query = @$"
                    SELECT 
	                    id_pedido_venda,
	                    situacao
                    FROM 
                        pedido_venda
                ";
               
                // Converte o resultado do select em DataTable
                DataTable retornoOS = await _comandosDB.ExecuteQuery(query);

                List<RetornoPedidoSit> retornoComissoes = DataTableToList(retornoOS);

                MetodosGerais.RegistrarLog("PedidoSit_CRUD", $"Foram encontradas {retornoComissoes.Count()} Pedidos no banco de dados\n");
                return retornoComissoes;
            }
            catch (Exception ex)
            {
                MetodosGerais.RegistrarLog("PedidoSit_CRUD", $"[ERROR]: {ex.Message} - {_comandosDB.Mensagem}");
                return null;
            }
        }

        private List<RetornoPedidoSit> DataTableToList(DataTable dt)
        {
            try
            {
                List<RetornoPedidoSit> listaRetornoPedidoSit = new List<RetornoPedidoSit> ();

                foreach (DataRow linha in dt.Rows)
                {
                    RetornoPedidoSit RPedidoSit = new RetornoPedidoSit()
                    {
                        id_pedido_venda = Convert.ToInt32(linha["id_pedido_venda"]),
                        situacao = Convert.ToInt32(linha["situacao"])
                    };

                    listaRetornoPedidoSit.Add( RPedidoSit );
                }
                return listaRetornoPedidoSit;
            }
            catch (Exception ex)
            {
                MetodosGerais.RegistrarLog("PedidoSit_CRUD", ex.Message);
                return null;
            }
        }

    }
}
