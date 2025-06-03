using MailKit.Net.Smtp;
using MailKit.Security;
using Metodos.IntegradorCRM.Metodos;
using MimeKit;
using Modelos.IntegradorCRM.Models;
using Modelos.IntegradorCRM.Models.EF;

public static class EmailService
{
    //private static  readonly string _smtpServer = "smtp.zoho.com";
    //private static readonly int _smtpPort = 465;
    //private static readonly string _smtpUser = "augusto@casainfosc.com";
    //private static readonly string _smtpPass = "f14gDiDMda3X";

    public static async Task EnviarEmailAsync(ConfigEmail configEmail, EmailModel emailModel)
    {
        var email = new MimeMessage();
        email.From.Add(MailboxAddress.Parse(configEmail.Email));
        email.To.Add(new MailboxAddress(emailModel.nomeDestinatario ?? emailModel.destinatario, emailModel.destinatario));
        email.Subject = emailModel.assunto;

        var builder = new BodyBuilder();

        // Define o corpo do e-mail como HTML ou texto simples
        if (emailModel.mensagemEhHtml)
        {
            builder.HtmlBody = emailModel.mensagem;
        }
        else
        {
            builder.TextBody = emailModel.mensagem;
        }

        // Anexa o PDF se houver
        if (!string.IsNullOrWhiteSpace(emailModel.pdfBase64))
        {
            byte[] pdfBytes = Convert.FromBase64String(emailModel.pdfBase64);
            builder.Attachments.Add(emailModel.nomeAnexo ?? "anexo.pdf", pdfBytes, new ContentType("application", "pdf"));
        }

        email.Body = builder.ToMessageBody();

        try
        {
            using var smtp = new SmtpClient();
            await smtp.ConnectAsync(configEmail.SMTP_Server, configEmail.SMTP_Port ?? 587, SecureSocketOptions.SslOnConnect);
            await smtp.AuthenticateAsync(configEmail.Email, configEmail.Senha);
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);
        }
        catch (Exception ex)
        {
            // Aqui você pode logar a exceção, exibir no console, salvar no banco, etc.
            MetodosGerais.RegistrarLog("ERROR", $"Erro ao enviar e-mail: {ex.Message}");
            throw;
        }
    }
}
