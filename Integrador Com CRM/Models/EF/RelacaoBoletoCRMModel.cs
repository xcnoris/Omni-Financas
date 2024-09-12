using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrador_Com_CRM.Models.EF
{
    internal class RelacaoBoletoCRMModel
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
        public string Cod_Oportunidade { get; set; }
        public int Quitado { get; set; }

    }
}
