using System.ComponentModel;

namespace Modelos.IntegradorCRM.Models.Enuns
{
    public enum Situacao_Boleto
    {
        [Description("Quitado")]
        Quitado = 2,
        [Description("Cancelada/Estornado")]
        Cancelada_Ou_Estornado = 3
    }
}


