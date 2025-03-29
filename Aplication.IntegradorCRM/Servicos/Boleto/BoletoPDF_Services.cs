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
            MetodosGerais.RegistrarLog("BOLETO_PDF", $"Iniciando consulta do boleto para ID: {idDocumentoReceber}");

            string? caminhoArquivoBoleto = string.Empty; 
            string query = "SELECT caminho_arquivo_boleto FROM boleto WHERE id_documento_receber = @IdDocumentoReceber";

            try
            {
                string queryComID = query.Replace("@IdDocumentoReceber", idDocumentoReceber.ToString());

                DataTable retornoOS = _comandosDB.ExecuteQuery(queryComID);
                caminhoArquivoBoleto = retornoOS.Rows.Count > 0 ? retornoOS.Rows[0][0].ToString() : string.Empty;

            }
            catch (SqlException ex)
            {
                MetodosGerais.RegistrarLog("BOLETO_PDF", $"Erro ao acessar o banco de dados: {ex.Message}");
                throw new Exception("Erro ao acessar o banco de dados.", ex);
            }
            catch (Exception ex)
            {
                MetodosGerais.RegistrarLog("BOLETO_PDF", $"Erro inesperado: {ex.Message}");
                throw;
            }

            if (string.IsNullOrEmpty(caminhoArquivoBoleto))
            {
                MetodosGerais.RegistrarLog("BOLETO_PDF", "Caminho do arquivo não encontrado para o ID especificado.");
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
