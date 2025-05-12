using DataBase.IntegradorCRM.Data.DataBase;
using Metodos.IntegradorCRM.Metodos;
using Microsoft.Data.SqlClient;
using System.Data;
namespace Aplication.IntegradorCRM.Servicos.Boleto
{
    internal class BoletoPDF_Services : IDisposable
    {
     

        private ConexaoDB _conexaoDB;
        private ComandosDB _comandosDB;

  

        public BoletoPDF_Services()
        {
            string Validacao = "";
            _conexaoDB = new ConexaoDB(Validacao);
            _comandosDB = new ComandosDB(_conexaoDB);
           
        }

        /// <summary>
        /// Consulta o banco de dados para obter o caminho do arquivo PDF com base no id_documento_receber.
        /// </summary>
        /// <param name="idDocumentoReceber">ID do documento a ser pesquisado</param>
        /// <returns>Caminho do arquivo PDF</returns>
        public string ConsultarCaminhoBoleto(int idDocumentoReceber)
        {
            const string query = "SELECT caminho_arquivo_boleto FROM boleto WHERE id_documento_receber = @IdDocumentoReceber";

            try
            {
                MetodosGerais.RegistrarLog("BOLETO_PDF", $"Consultando boleto para ID: {idDocumentoReceber}");

                SqlParameter[] parametros =
                {
                    new SqlParameter("@IdDocumentoReceber", SqlDbType.Int) { Value = idDocumentoReceber }
                };

                DataTable resultado = _comandosDB.ExecuteQuery(query, parametros);

                if (resultado.Rows.Count == 0)
                {
                    MetodosGerais.RegistrarLog("BOLETO_PDF", $"Nenhum caminho encontrado para o ID: {idDocumentoReceber}");
                    return null;
                }

                var caminho = resultado.Rows[0]["caminho_arquivo_boleto"]?.ToString();

                if (string.IsNullOrWhiteSpace(caminho))
                {
                    MetodosGerais.RegistrarLog("BOLETO_PDF", $"Caminho vazio ou nulo para o ID: {idDocumentoReceber}");
                    return null;
                }

                return caminho;
            }
            catch (SqlException ex)
            {
                MetodosGerais.RegistrarLog("BOLETO_PDF", $"Erro SQL ao consultar boleto (ID: {idDocumentoReceber}): {ex.Message}");
                return null;
            }
            catch (Exception ex)
            {
                MetodosGerais.RegistrarLog("BOLETO_PDF", $"Erro inesperado ao consultar boleto (ID: {idDocumentoReceber}): {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Converte o arquivo PDF no caminho especificado para uma string Base64.
        /// </summary>
        /// <param name="caminhoArquivo">Caminho do arquivo PDF</param>
        /// <returns>Arquivo em Base64</returns>
        public string ConverterPDFParaBase64(string caminhoArquivo)
        {
            MetodosGerais.RegistrarLog("BOLETO_PDF", $"Iniciando conversão para Base64 do arquivo: {caminhoArquivo}");

            try
            {
                if (!File.Exists(caminhoArquivo))
                {
                    MetodosGerais.RegistrarLog("BOLETO_PDF", $"Arquivo não encontrado: {caminhoArquivo}");
                    return "";
                }

                FileInfo fileInfo = new FileInfo(caminhoArquivo);
                if (fileInfo.Length > 100 * 1024) // 100 KB em bytes
                {
                    MetodosGerais.RegistrarLog("BOLETO_PDF", $"Arquivo excede o limite de 100KB: {caminhoArquivo}");
                    return "";
                }

                byte[] fileBytes = File.ReadAllBytes(caminhoArquivo);
                string base64String = Convert.ToBase64String(fileBytes);

                MetodosGerais.RegistrarLog("BOLETO_PDF", "Conversão para Base64 realizada com sucesso.");
                return base64String;
            }
            catch (Exception ex)
            {
                MetodosGerais.RegistrarLog("BOLETO_PDF", $"Erro inesperado ao converter para Base64: {ex.Message}");
                throw;
            }
        }

        public void Dispose()
        {
            // Nada a liberar, mas mantendo para boas práticas
        }
    }
}
