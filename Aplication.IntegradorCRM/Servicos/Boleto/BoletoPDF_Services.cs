
using Metodos.IntegradorCRM.Metodos;
using Microsoft.Data.SqlClient;

namespace Aplication.IntegradorCRM.Servicos.Boleto
{
    internal class BoletoPDF_Services : IDisposable
    {
        private readonly string _connectionString;

        public BoletoPDF_Services()
        {
        }

        /// <summary>
        /// Consulta o banco de dados para obter o caminho do arquivo PDF com base no id_documento_receber.
        /// </summary>
        /// <param name="idDocumentoReceber">ID do documento a ser pesquisado</param>
        /// <returns>Caminho do arquivo PDF</returns>
        public string ConsultarCaminhoBoleto(int idDocumentoReceber)
        {
            string? caminhoArquivoBoleto = null;

            string query = "SELECT caminho_arquivo_boleto FROM boleto WHERE id_documento_receber = @IdDocumentoReceber";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdDocumentoReceber", idDocumentoReceber);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            caminhoArquivoBoleto = reader["caminho_arquivo_boleto"]?.ToString();
                        }
                    }
                }
            }

            if (string.IsNullOrEmpty(caminhoArquivoBoleto))
            {
                throw new Exception("Caminho do arquivo não encontrado para o ID especificado.");
            }

            return caminhoArquivoBoleto;     
        }

        /// <summary>
        /// Converte o arquivo PDF no caminho especificado para uma string Base64.
        /// </summary>
        /// <param name="caminhoArquivo">Caminho do arquivo PDF</param>
        /// <returns>Arquivo em Base64</returns>
        public string ConverterPDFParaBase64(string caminhoArquivo)
        {
            try
            {

                if (!File.Exists(caminhoArquivo))
                {
                    MetodosGerais.RegistrarLog("BOLETO_PDF", $"O arquivo especificado não foi encontrado: {caminhoArquivo}");
                    throw new FileNotFoundException("O arquivo especificado não foi encontrado.", caminhoArquivo);
                }

                byte[] fileBytes = File.ReadAllBytes(caminhoArquivo);
                return Convert.ToBase64String(fileBytes);
            }
            catch (Exception ex)
            {
                MetodosGerais.RegistrarLog("BOLETO_PDF", $"Erro: {ex.Message}");
                throw;
            }
        }

        public void Dispose()
        {
        }
    }
}
