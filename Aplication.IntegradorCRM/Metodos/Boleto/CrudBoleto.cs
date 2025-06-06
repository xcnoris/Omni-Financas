﻿using DataBase.IntegradorCRM.Data.DataBase;
using Metodos.IntegradorCRM.Metodos;
using Modelos.IntegradorCRMRM.Models;
using System.Data;

namespace Aplication.IntegradorCRM.Metodos.Boleto
{
    internal class CrudBoleto
    {
        private ConexaoDB _conexaoDB;
        private ComandosDB _comandosDB;

        public CrudBoleto()
        {
            string Validacao = "";
            _conexaoDB = new ConexaoDB(Validacao);
            _comandosDB = new ComandosDB(_conexaoDB);
        }

        internal List<RetornoBoleto> BuscarBoletosInDB(DateTime DataCriacao)
        {
            try
            {

                // Buscar serviços no banco de dados a partir de uma data ou parâmetro definido
                string query = @$"
                     SELECT 
                           DR.numero_documento_receber,
                            DR.id_documento_receber,
                            DR.numero_documento_receber,
                            DR.id_entidade,
                            ent.nome,
	                       CASE 
                                WHEN ent.tipo_entidade = 1 THEN LEFT(ent.nome, CHARINDEX(' ', ent.nome + ' ') - 1)
                                WHEN ent.tipo_entidade = 2 THEN pj.nome_fantasia 
                                ELSE 'Tipo de entidade desconhecido' 
                            END AS nomeFantasia,
                            CONCAT(
                                COALESCE(ent.celular_ddd, ''),
                                CASE 
                                    WHEN LEN(LTRIM(RTRIM(COALESCE(ent.celular_numero, '')))) = 8 AND LEFT(LTRIM(RTRIM(ent.celular_numero)), 1) != '3' THEN 
                                        -- Coloca 9 somente se for número de 8 dígitos e não começar com 3 (fixo)
                                        CONCAT('9', LTRIM(RTRIM(ent.celular_numero)))
                                    ELSE 
                                        LTRIM(RTRIM(ent.celular_numero))
                                END
                            ) AS celular,
                            ent.email_principal,
                            DR.valor,
                            CASE 
                                WHEN ent.tipo_entidade = 1 THEN pf.cpf 
                                WHEN ent.tipo_entidade = 2 THEN pj.cnpj 
                                ELSE 'Tipo de entidade desconhecido' 
                            END AS identificador_cliente,
                            DR.situacao,
                            DR.data_vencimento
                    FROM 
                        documento_receber DR
                    INNER JOIN 
                        entidade ent ON DR.id_entidade = ent.id_entidade
                    LEFT JOIN 
                        pessoa_juridica pj ON ent.id_entidade = pj.id_entidade AND ent.tipo_entidade = 2
                    LEFT JOIN 
                        pessoa_fisica pf ON ent.id_entidade = pf.id_entidade AND ent.tipo_entidade = 1
                    WHERE 
                         DR.data_vencimento >= '{DataCriacao}'
                    AND 
                        DR.tem_boleto = 1 
                ";

                // Converte o resultado do select em DataTable
                DataTable retornoOS = _comandosDB.ExecuteQuery(query);

                List<RetornoBoleto> retornoBoletos = DataTableToList(retornoOS);

                return retornoBoletos;
            }
            catch (Exception ex)
            {
                MetodosGerais.RegistrarLog("BOLETO_CRUD", $"[ERROR]: {ex.Message} - {_comandosDB.Mensagem}");

                return null;
            }
        }

        private List<RetornoBoleto> DataTableToList(DataTable dt)
        {
            try
            {
                List<RetornoBoleto> listaRetornoOS = new List<RetornoBoleto>();

                foreach (DataRow linha in dt.Rows)
                {
                    RetornoBoleto RBoleto = new RetornoBoleto()
                    {
                        Num_DocReceber = linha["numero_documento_receber"].ToString(),
                        Id_DocReceber = linha["id_documento_receber"].ToString(),
                        Documento = linha["numero_documento_receber"].ToString(),
                        Id_Entidade = linha["id_entidade"].ToString(),
                        Nome_RazSocial = linha["nome"].ToString(),
                        PrimNome_Fantasia = linha["nomeFantasia"].ToString(),
                        Celular = linha["celular"].ToString(),
                        Email = linha["email_principal"].ToString(),
                        Valor = linha["valor"].ToString(),
                        Identificador_Cliente = linha["identificador_cliente"].ToString(),
                        Situacao = linha["situacao"].ToString(),
                        Data_Vencimento = Convert.ToDateTime(linha["data_vencimento"])
                    };
                    

                    listaRetornoOS.Add(RBoleto);
                }
                return listaRetornoOS;
            }
            catch (Exception ex)
            {
                MetodosGerais.RegistrarLog("BOLETO_CRUD", ex.Message);
                
                return null;
            }
        }
    }
}
