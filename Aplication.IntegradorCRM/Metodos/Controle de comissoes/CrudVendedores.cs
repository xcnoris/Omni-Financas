using DataBase.IntegradorCRM.Data.DataBase;
using Metodos.IntegradorCRM.Metodos;
using Modelos.IntegradorCRM.Models.Retornos;
using System.Data;

namespace Aplication.IntegradorCRM.Metodos.ControleComissao
{
    public class CrudVendedores
    {
        private ComandosDB _comandosDB;

        public async Task<List<RetornoVendedores>> BuscarComissoesInDB()
        {
            _comandosDB = new ComandosDB();

            try
            {
                string query = @$"
                    
                   select 
      id_usuario, nome 
  from usuario
  where vendedor = 1 and ativo = 1

                ";

                // Converte o resultado do select em DataTable
                DataTable retornoOS = await _comandosDB.ExecuteQuery(query);

                List<RetornoVendedores> retornoVendedores = DataTableToList(retornoOS);

                MetodosGerais.RegistrarLog("Comissao_CRUD", $"Foram encontradas {retornoVendedores.Count()} vendedores no banco de dados\n");
                return retornoVendedores;
            }
            catch (Exception ex)
            {
                MetodosGerais.RegistrarLog("Comissao_CRUD", $"[ERROR]: {ex.Message} - {_comandosDB.Mensagem}");
                return null;
            }
        }

        private List<RetornoVendedores> DataTableToList(DataTable dt)
        {
            try
            {
                List<RetornoVendedores> listaRetornoVendedores = new List<RetornoVendedores> ();

                foreach (DataRow linha in dt.Rows)
                {
                    RetornoVendedores Rcomissoes = new RetornoVendedores()
                    {
                        Id_Vendedor = Convert.ToInt32(linha["id_usuario"]),
                        Nome = (linha["nome"]).ToString()
                    };

                    listaRetornoVendedores.Add( Rcomissoes );
                }
                return listaRetornoVendedores;
            }
            catch (Exception ex)
            {
                MetodosGerais.RegistrarLog("Comissao_CRUD", ex.Message);
                return null;
            }
        }

    }
}
