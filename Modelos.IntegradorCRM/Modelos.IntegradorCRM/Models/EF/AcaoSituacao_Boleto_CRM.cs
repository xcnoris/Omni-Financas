using Modelos.IntegradorCRM.Models.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.IntegradorCRM.Models.EF
{
    public class AcaoSituacao_Boleto_CRM
    {
        public int Id { get; set; }
        public Situacao_Boleto Situacao { get; set; }
        public string CodAcaoCRM { get; set; }
        public string Mensagem_Acao { get; set; }
        public DateTime Data_Cricao { get; set; }
        public DateTime Data_Atualizacao { get; set; }

    }
}
