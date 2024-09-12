using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrador_Com_CRM.Models
{
    internal class RetornoOrdemServico
    {
        public string Id_Ordem_Servico { get; set; }
        public string Identificador_Cliente { get; set; }
        public string Nome_Cliente { get; set; }
        public string Telefone { get; set; }
        public string? Email_Cliente { get; set; }
        public string Id_CategoriaOS { get; set; }
    }
}
