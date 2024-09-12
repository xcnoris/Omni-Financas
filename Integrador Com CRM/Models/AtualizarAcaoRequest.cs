using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrador_Com_CRM.Models
{
    internal class AtualizarAcaoRequest
    {
        public string codigoOportunidade { get; set; }
        public string codigoAcao { get; set; }
        public string codigoJornada { get; set; }
        public string textoFollowup { get; set; }
    }
}
