using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

public static class EmailService
{
    private static  readonly string _smtpServer = "smtp.zoho.com";
    private static readonly int _smtpPort = 465;
    private static readonly string _smtpUser = "augusto@casainfosc.com";
    private static readonly string _smtpPass = "f14gDiDMda3X";

    public static async Task EnviarEmailAsync(
        string destinatario,
        string assunto,
        string mensagem,
        string? nomeDestinatario = null,
        string? pdfBase64 = null,
        string? nomeAnexo = "Boleto.pdf",
        bool mensagemEhHtml = true)
    {
        var email = new MimeMessage();
        email.From.Add(MailboxAddress.Parse(_smtpUser));
        email.To.Add(new MailboxAddress(nomeDestinatario ?? destinatario, destinatario));
        email.Subject = assunto;

        var builder = new BodyBuilder();

        // Define o corpo do e-mail como HTML ou texto simples
        if (mensagemEhHtml)
        {
            builder.HtmlBody = mensagem;
        }
        else
        {
            builder.TextBody = mensagem;
        }

        // Anexa o PDF se houver
        if (!string.IsNullOrWhiteSpace(pdfBase64))
        {
            byte[] pdfBytes = Convert.FromBase64String(pdfBase64);
            builder.Attachments.Add(nomeAnexo ?? "anexo.pdf", pdfBytes, new ContentType("application", "pdf"));
        }

        email.Body = builder.ToMessageBody();

        try
        {
            using var smtp = new SmtpClient();
            await smtp.ConnectAsync(_smtpServer, _smtpPort, SecureSocketOptions.SslOnConnect);
            await smtp.AuthenticateAsync(_smtpUser, _smtpPass);
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);
        }
        catch (Exception ex)
        {
            // Aqui você pode logar a exceção, exibir no console, salvar no banco, etc.
            Console.WriteLine($"Erro ao enviar e-mail: {ex.Message}");
            throw;
        }
    }
}
