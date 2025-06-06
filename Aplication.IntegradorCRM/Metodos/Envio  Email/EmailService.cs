using MailKit.Net.Smtp;
using MailKit.Security;
using Metodos.IntegradorCRM.Metodos;
using MimeKit;
using Modelos.IntegradorCRM.Models;
using Modelos.IntegradorCRM.Models.EF;
using System;
using System.Net.Http;
using System.Net.Http.Json;

public static class EmailService
{
    //private static  readonly string _smtpServer = "smtp.zoho.com";
    //private static readonly int _smtpPort = 465;
    //private static readonly string _smtpUser = "augusto@casainfosc.com";
    //private static readonly string _smtpPass = "f14gDiDMda3X";

    public static async Task<bool> EnviarEmailAsync(ConfigEmail configEmail, EmailModel emailModel)
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
            for (int tentativa = 1; tentativa <= 5; tentativa++)
            {
                try
                {
                    using var smtp = new SmtpClient();
                    SecureSocketOptions securityOption = configEmail.SMTP_Port switch
                    {
                        465 => SecureSocketOptions.SslOnConnect,
                        587 => SecureSocketOptions.StartTls,
                        _ => SecureSocketOptions.Auto
                    };
                    await smtp.ConnectAsync(configEmail.SMTP_Server, configEmail.SMTP_Port ?? 587, securityOption);
                    await smtp.AuthenticateAsync(configEmail.Email, configEmail.Senha);
                    await smtp.SendAsync(email);
                    await smtp.DisconnectAsync(true);

                    MetodosGerais.RegistrarLog("BOLETO", $"Tentativa {tentativa} - E-mail enviado com sucesso para: {email.To}");
                    return true;
                }
                catch (SmtpCommandException ex)
                {
                    MetodosGerais.RegistrarLog("BOLETO", $"Tentativa {tentativa} - Erro SMTP: {ex.Message} (Status: {ex.StatusCode})");
                }
                catch (SmtpProtocolException ex)
                {
                    MetodosGerais.RegistrarLog("BOLETO", $"Tentativa {tentativa} - Erro de protocolo SMTP: {ex.Message}");
                }
                catch (Exception ex)
                {
                    MetodosGerais.RegistrarLog("BOLETO", $"Tentativa {tentativa} - Exceção geral ao enviar e-mail: {ex.Message}");
                }

                await Task.Delay(1000 * tentativa); // Backoff exponencial leve: 1s, 2s, ..., 5s
            }
        }
        catch (Exception ex)
        {
            MetodosGerais.RegistrarLog("ERROR", $"Erro inesperado no envio de e-mail: {ex.Message}");
        }

        return false;

    }
}
