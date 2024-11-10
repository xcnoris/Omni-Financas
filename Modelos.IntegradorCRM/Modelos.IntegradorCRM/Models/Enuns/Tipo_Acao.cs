using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.IntegradorCRM.Models.Enuns
{
    internal enum Tipo_Acao
    {
        [Description("Ordem de Serviço")]
        Inativo = 1,

        [Description("Boleto")]
        Ativo = 2
    }
}
