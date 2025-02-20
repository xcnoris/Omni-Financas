using DataBase.IntegradorCRM.Data.DataBase;
using Metodos.IntegradorCRM.Metodos;
using Modelos.IntegradorCRM.Models.Retornos;
using System.Data;

namespace Aplication.IntegradorCRM.Servicos.Controle_Comissao
{
    internal class ComissaoService
    {
        private ComandosDB _comandosDB;

        public ComissaoService()
        {
            _comandosDB = new ComandosDB();
        }

        internal async Task AtualizarSituacaoComissao(RetornoComissao comissao)
        {
            try
            {
                string query = @"
                    UPDATE Controle_Comissao_Item_Demander
                    SET Situacao_Pedido = @Situacao_Pedido,
                        data_liberacao = @data_liberacao
                    WHERE Codigo_Pedido = @Codigo_Pedido";

                var parametros = new Dictionary<string, object>
                {
                    {"@Situacao_Pedido", comissao.Situacao_Pedido},
                    {"@Codigo_Pedido",comissao.Codigo_Pedido },
                    {"@data_liberacao",  DateTime.Now}
                };

                int linhasAfetadas = await _comandosDB.ExecuteNonQueryAsync(query, parametros);
             
                MetodosGerais.RegistrarLog("Comissao_CRUD", $"{linhasAfetadas} registros atualizados no banco de dados. Comissao: {comissao.Codigo_Pedido}. Situacao: {comissao.Situacao_Pedido}");
            }
            catch (Exception ex)
            {
                MetodosGerais.RegistrarErroExcecao("Comissao_CRUD", "Erro ao atualizar a situação da comissão:", ex);
                throw;
            }
        }
    }
}
