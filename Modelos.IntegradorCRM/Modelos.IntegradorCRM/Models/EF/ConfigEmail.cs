

namespace Modelos.IntegradorCRM.Models.EF
{
    public class ConfigEmail
    {
        public int Id{ get; set; }
        public string? SMTP_Server { get; set; }
        public int? SMTP_Port { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
    }
}
