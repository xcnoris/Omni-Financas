using Modelos.IntegradorCRM.Models;
using Modelos.IntegradorCRMRM.Models;

namespace Aplication.IntegradorCRM.DTO
{
    public class MensagensEnvios
    {
        public ModeloOportunidadeRequest ModeloWhatsapp { get; set; }
        public EmailModel ModeloEmail { get; set; }

    }
}
