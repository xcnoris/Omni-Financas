using System.ComponentModel;

namespace Modelos.IntegradorCRM.Models.Enuns
{
    public enum Situacao_Boleto
    {
        [Description("Aberto ou Abertura")]
        AbertoOuABertura = 1,

        [Description("Quitado")]
        Quitado = 2,

        [Description("Cancelada/Estornado")]
        Cancelada_Ou_Estornado = 3
    }
}


