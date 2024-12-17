

using Newtonsoft.Json;

namespace Modelos.IntegradorCRM.Models
{
    public class EmailRequest
    {
        [JsonProperty("textoEmail")]
        public string TextoEmail { get; set; }

        [JsonProperty("tituloEmail")]
        public string TituloEmail { get; set; }

        [JsonProperty("destinatarios")]
        public List<Destinatario> Destinatarios { get; set; }
    }
}
