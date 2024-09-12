using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrador_Com_CRM.Models
{
    internal class RetornoOrdemServico
    {
        public int Id_Ordem_Servico { get; set; }
        public int Identificador_Cliente { get; set; }
        public string Nome_Cliente { get; set; }
        public string Telefone { get; set; }
        public string Email_Cliente { get; set; }
        public int Id_CategoriaOS { get; set; }
    }
}
