using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.IntegradorCRM.Models
{
    public class Configuracao_Geral
    {
        public string Token { get; set; }
        public int TimerOS { get; set; }
        public DateTime DataOSSelect { get; set; }
        public bool ChBox_OSEnviarMensCancel { get; set; }
   
        public DateTime HoraBoletoCobDiaria { get; set; }
        public DateTime HoraBoletoCobSegunda { get; set; }
        public DateTime DataBoletoSelect { get; set; }
        public bool ChBox_BoletoEnviarPDFPorWhats { get; set; }
        public bool ChBox_BoletoEnviarPDFPorEmail { get; set; }
        public bool ChBox_BoletoEnviarMensCancelamento { get; set; }
        public bool ChBox_BoletoMensFimdeSemana { get; set; }
    }
}
