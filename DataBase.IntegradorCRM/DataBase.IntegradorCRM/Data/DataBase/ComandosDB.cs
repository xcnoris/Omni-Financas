using Metodos.IntegradorCRM.Metodos;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DataBase.IntegradorCRM.Data.DataBase
{
    public class ComandosDB
    {
        private readonly ConexaoDB _conexaoDB;
        public string Mensagem { get; private set; }

        public ComandosDB(ConexaoDB conexao)
        {
            _conexaoDB = conexao;
        }

        public async Task<DataTable> ExecuteQuery(string query, SqlParameter[] parametros = null)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection connection = _conexaoDB.GetConnection())
                {
                    await _conexaoDB.OpenConnection();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        if (parametros != null)
                        {
                            cmd.Parameters.AddRange(parametros);
                        }

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
                Mensagem = "Consulta executada com sucesso!";
            }
            catch (SqlException ex)
            {
                Mensagem = "Erro ao executar a consulta: " + ex.Message;
                MetodosGerais.RegistrarLog("CRUDs", $"[ERROR]: Ocorreu um erro ao executar o comando 'ExecuteQuery'. Mensagem: {ex.Message}");
            }
            finally
            {
                _conexaoDB.CloseConnection();
            }
            return dt;
        }

        public async Task<int> ExecuteNonQueryAsync(string query, Dictionary<string, object> parametros = null)
        {
            int linhasAfetadas = 0;
            try
            {
                using (SqlConnection connection = _conexaoDB.GetConnection())
                {
                    await _conexaoDB.OpenConnection();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        if (parametros != null)
                        {
                            foreach (var param in parametros)
                            {
                                cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                            }
                        }

                        linhasAfetadas = await cmd.ExecuteNonQueryAsync();
                    }
                }
                Mensagem = "Operação realizada com sucesso!";
            }
            catch (SqlException ex)
            {
                Mensagem = "Erro ao executar a operação: " + ex.Message;
                MetodosGerais.RegistrarLog("CRUDs",$"[ERROR]: Ocorreu um erro ao executar o comando 'ExecuteNonQueryAsync'. Mensagem: {ex.Message}");
            }
            finally
            {
                _conexaoDB.CloseConnection();
            }
            return linhasAfetadas;
        }
    }
}
