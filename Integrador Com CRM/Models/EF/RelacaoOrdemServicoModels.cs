using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrador_Com_CRM.Models.EF
{
    internal class RelacaoOrdemServicoModels
    {
        public int Id { get; set; }
        public int Id_OrdemServico { get; set; }
        public string Cod_Oportunidade { get; set; }
        public int Id_CategoriaOS { get; set; }
        public DateTime Data_Criacao { get; set; }
        public DateTime? Data_Alteracao { get; set; }


    }
}
