using Modelos.IntegradorCRM.Models.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.IntegradorCRM.Models.EF
{
    public class AcaoSituacao_OS_CRM
    {
        public int Id { get; set; }
        public Situacao_OS Situacao { get; set; }
        public string CodAcaoCRM { get; set; }
        public string Mensagem_Acao { get; set; }
    }
}
