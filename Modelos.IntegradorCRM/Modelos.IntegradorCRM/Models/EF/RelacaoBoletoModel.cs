﻿using Modelos.IntegradorCRMRM.Models;

namespace Modelos.IntegradorCRM.Models.EF
{
    public class RelacaoBoletoModel
    {
        public int Id { get; set; }
        public int Id_DocumentoReceber { get; set; }
        public string Numero_Documento { get; set; }
        public int Id_Entidade { get; set; }
        public string Nome_Entidade { get; set; }
        public string Celular_Entidade { get; set; }
        public string Email_Entidade { get; set; }
        public string CNPJ_CPF { get; set; }
        public int Situacao { get; set; }
        public DateTime Data_Vencimento { get; set; }
        public int Quitado { get; set; }
        public int DiasEmAtraso { get; set; }
        public DateTime Data_Criacao { get; set; }
        public DateTime Data_Atualizacao { get; set; }


        public static RelacaoBoletoModel InstanciaDados(RetornoBoleto boleto)
        {
            return new RelacaoBoletoModel
            {
                Id_DocumentoReceber = Convert.ToInt32(boleto.Id_DocReceber),
                Numero_Documento = boleto.Num_DocReceber,
                Id_Entidade = Convert.ToInt32(boleto.Id_Entidade),
                Nome_Entidade = boleto.Nome_RazSocial,
                Celular_Entidade = boleto.Celular,
                Email_Entidade = boleto.Email,
                CNPJ_CPF = boleto.Identificador_Cliente,
                Situacao = Convert.ToInt32(boleto.Situacao),
                Data_Vencimento = boleto.Data_Vencimento,
                DiasEmAtraso = 0
            };
        }
    }
}
