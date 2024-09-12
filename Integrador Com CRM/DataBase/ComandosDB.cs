using Integrador_Com_CRM.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrador_Com_CRM.DataBase
{
    internal class ComandosDB
    {
        private ConexaoDB _conexaoDB;
        public string Mensagem;

        public ComandosDB(ConexaoDB conexao)
        {
            _conexaoDB = conexao;
        }

        public List<RetornoOrdemServico> ExecuteQuery(string query, SqlParameter[] parametros = null)
        {
            List<RetornoOrdemServico> listaOS = new List<RetornoOrdemServico>();

            try
            {
                SqlConnection connection = _conexaoDB.GetConnection();
                _conexaoDB.OpenConnection();
                SqlCommand cmd = new SqlCommand(query, connection);

                if (parametros != null)
                {
                    cmd.Parameters.AddRange(parametros);
                }

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        RetornoOrdemServico os = new RetornoOrdemServico
                        {
                            Id_Ordem_Servico = reader.GetInt32(reader.GetOrdinal("id_ordem_servico")),
                            Identificador_Cliente = reader.GetInt32(reader.GetOrdinal("identificador_cliente")),
                            Nome_Cliente = reader.GetString(reader.GetOrdinal("nome_cliente")),
                            Telefone = reader.GetString(reader.GetOrdinal("telefone")),
                            Email_Cliente = reader.IsDBNull(reader.GetOrdinal("email_cliente")) ? null : reader.GetString(reader.GetOrdinal("email_cliente")),
                            Id_CategoriaOS = reader.GetInt32(reader.GetOrdinal("id_categoria_ordem_servico"))
                        };

                        listaOS.Add(os);
                    }
                }
            }
            catch (SqlException ex)
            {
                Mensagem = "Erro ao executar a consulta: " + ex.Message;
            }
            finally
            {
                _conexaoDB.CloseConnection();
            }

            Mensagem = "Consulta executada com sucesso!";
            return listaOS;
        }

    }
}
