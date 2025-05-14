using DataBase.IntegradorCRM.Data.DataBase;
using Metodos.IntegradorCRM;
using Metodos.IntegradorCRM.Metodos;
using Modelos.IntegradorCRM.Models.EF;
using Modelos.IntegradorCRM.Models.Retornos;
using System.Data;

namespace Aplication.IntegradorCRM.Metodos.ControleComissao
{
    internal class CrudControlComissao
    {
        private ComandosDB _comandosDB;


        internal async Task<List<Controle_Liberacao_ComissaoModel>> BuscarPedidosSitInDB()
        {
            _comandosDB = new ComandosDB();

            try
            {
                string query = @$"
                                      SELECT 
    pv.id_pedido_venda,
    pv.id_usuario_vendedor,
    usu.nome,
	nf.numero_documento_fiscal,
	nf.data_hora_emissao as emissaoNF,
	nf.id_situacao_documento_fiscal,
    dr.id_documento_receber,
    dr.numero_documento_receber,
    dr.data_vencimento,
    CASE 
        WHEN  dr.data_quitacao IS NULL AND dr.situacao is null
            THEN nf.data_hora_emissao
        ELSE dr.data_quitacao
    END AS DATA_QUITACAO,
    dr.situacao,
    COUNT(dr.id_documento_receber) OVER (PARTITION BY pv.id_pedido_venda) AS DR_TOTAL,
    CASE 
        WHEN COUNT(dr.id_documento_receber) OVER (PARTITION BY pv.id_pedido_venda) = 0 
        THEN SUM(cci.valor_comissao)
    ELSE
        (SUM(cci.valor_comissao)/ COUNT(dr.id_documento_receber) OVER (PARTITION BY pv.id_pedido_venda)) 
    END AS Valor_Comissao_Por_DR,
    0 AS Pago_Para_Vendedor
    
FROM pedido_venda pv
INNER JOIN Controle_Comissao_Item_Demander cci ON cci.codigo_pedido = pv.id_pedido_venda
INNER JOIN pedido_venda_nota_fiscal pvn ON pvn.id_pedido_venda = pv.id_pedido_venda
INNER JOIN usuario usu on usu.id_usuario = pv.id_usuario_vendedor
INNER JOIN nota_fiscal nf ON nf.id_nota_fiscal = pvn.id_nota_fiscal
INNER JOIN operacao_pdv opdv ON opdv.id_nota_fiscal = nf.id_nota_fiscal
INNER JOIN finalizador_operacao_pdv fpdv ON fpdv.id_operacao = opdv.id_operacao
LEFT JOIN documento_receber dr ON dr.id_documento_receber = fpdv.id_documento_receber
WHERE pv.situacao = 5 AND nf.id_situacao_documento_fiscal = 1 
GROUP BY 
    pv.id_pedido_venda,
    pv.id_usuario_vendedor,
    usu.nome,
    dr.id_documento_receber, 
    dr.numero_documento_receber, 
    dr.data_vencimento,
    nf.data_hora_emissao,
    dr.data_quitacao,  
    dr.situacao,
	nf.numero_documento_fiscal,
	nf.data_hora_emissao,
	nf.id_situacao_documento_fiscal;


                ";
               
                // Converte o resultado do select em DataTable
                DataTable retornoOS = await _comandosDB.ExecuteQuery(query);

                List<Controle_Liberacao_ComissaoModel> retornoComissoes = DataTableToList(retornoOS);

                MetodosGerais.RegistrarLog("Comissao_CRUD", $"Foram encontradas {retornoComissoes.Count()} Pedidos no banco de dados\n");
                return retornoComissoes;
            }
            catch (Exception ex)
            {
                MetodosGerais.RegistrarLog("Comissao_CRUD", $"[ERROR]: {ex.Message} - {_comandosDB.Mensagem}");
                return null;
            }
        }

        private List<Controle_Liberacao_ComissaoModel> DataTableToList(DataTable dt)
        {
            try
            {
                List<Controle_Liberacao_ComissaoModel> listaRetornodeComissoes = new List<Controle_Liberacao_ComissaoModel> ();

                foreach (DataRow linha in dt.Rows)
                {
                    Controle_Liberacao_ComissaoModel RComissoes = new Controle_Liberacao_ComissaoModel()
                    {
                        Id_Usuario_Vendedor = DbHelper.GetInt(linha["id_usuario_vendedor"]),
                        Nome_Vendedor = DbHelper.GetString(linha["nome"]),
                        Id_Pedido_Venda = DbHelper.GetInt(linha["id_pedido_venda"]),
                        Id_Documento_Receber = DbHelper.GetInt(linha["id_documento_receber"]),
                        Numero_Documento_Receber = DbHelper.GetString(linha["numero_documento_receber"]),
                        Data_Vencimento = DbHelper.GetDateTime(linha["data_vencimento"]),
                        Data_Quitacao = DbHelper.GetDateTime(linha["DATA_QUITACAO"]),
                        Situacao = DbHelper.GetInt(linha["situacao"]),
                        DR_Total_Gerados = DbHelper.GetInt(linha["DR_TOTAL"]),
                        Valor_Comissao_Por_Parcela = DbHelper.GetDecimal(linha["Valor_Comissao_Por_DR"]),
                        Pago_para_Vendedor = DbHelper.GetInt(linha["Pago_Para_Vendedor"]),
                        numero_documento_fiscal = DbHelper.GetInt(linha["numero_documento_fiscal"]),
                        data_hora_emissao_nota = DbHelper.GetDateTime(linha["emissaoNF"]),
                        id_situacao_documento_fiscal = DbHelper.GetInt(linha["id_situacao_documento_fiscal"]),
                    };

                    listaRetornodeComissoes.Add(RComissoes);
                }
                return listaRetornodeComissoes;
            }
            catch (Exception ex)
            {
                MetodosGerais.RegistrarLog("Comissao_CRUD", ex.Message);
                return null;
            }
        }

    }
}
