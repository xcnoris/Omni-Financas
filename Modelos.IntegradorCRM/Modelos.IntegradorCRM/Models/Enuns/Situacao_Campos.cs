using System.ComponentModel;

namespace Modelos.IntegradorCRM.Models.Enuns
{
    public enum Situacao_Campos
    {
        [Description("Boleto Crição")]
        Boleto_Criacao = 1,
        [Description("Boleto Quitado")]
        Boleto_Quitado = 2,
        [Description("Boleto Cancelado")]
        Boleto_Cancelado = 3,


        [Description("OS Crição")]
        OS_Criacao = -1,
        [Description("OS Cancelamento")]
        OS_Cancelamento = 11,
    }
}


