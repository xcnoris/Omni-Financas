using Newtonsoft.Json;

namespace Modelos.IntegradorCRM
{
    public class Destinatario
    {
        [JsonProperty("nomeDestinatario")]
        public string NomeDestinatario { get; set; }

        [JsonProperty("emailDestinatario")]
        public string EmailDestinatario { get; set; }
    }
}
