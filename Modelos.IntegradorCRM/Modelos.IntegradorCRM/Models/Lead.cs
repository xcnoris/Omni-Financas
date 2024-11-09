namespace Modelos.IntegradorCRM.Models
{
    public class Lead
    {
        public string nomeLead { get; set; }
        public string telefoneLead { get; set; }
        public string emailLead { get; set; }
        public string cnpjLead { get; set; }
        public string origemLead { get; set; }
        public List<Contato> contatos { get; set; }
    }
}