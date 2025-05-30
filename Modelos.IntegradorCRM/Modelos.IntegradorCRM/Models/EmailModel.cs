
namespace Modelos.IntegradorCRM.Models
{
    public class EmailModel
    {
        public string destinatario { get; set; }
        public string assunto { get; set; }
        public string mensagem { get; set; }
        public string? nomeDestinatario { get; set; } = null;
        public string? pdfBase64 { get; set; } = null;
        public string? nomeAnexo { get; set; } = "Boleto.pdf";
        public bool mensagemEhHtml { get; set; } = true;
    }
}
