using System;
using System.Net.Mail;
using PortalDeParceiros.Application.IService;
using PortalDeParceiros.Dto.Model;
using Microsoft.Extensions.Configuration;

namespace PortalDeParceiros.Application.Service
{
    public class EmailService : IEmailService
    {
        private readonly System.Net.Mail.SmtpClient client;
        private readonly string emailBari;
        private readonly string emailBariPassword;
        private readonly IConfiguration _configuration;
        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;

            emailBari = _configuration.GetValue<string>("Email");
            emailBariPassword = _configuration.GetValue<string>("EmailPasswors");

            client = new System.Net.Mail.SmtpClient();
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.Credentials = new System.Net.NetworkCredential(emailBari, emailBariPassword);
        }
        public void SendEmailNewUser(EmailDto email)
        {
            MailMessage mail = new MailMessage();
            mail.To.Add(new MailAddress(email.Email, email.Name));
            mail.Subject = "Primeiro acesso ao portal de parceiros";
            mail.IsBodyHtml = true;
            mail.Body = email.MessageCreat;

            SendEmail(mail);
        }

        public void SendEmailResetUser(EmailDto email)
        {
            MailMessage mail = new MailMessage();
            mail.To.Add(new MailAddress(email.Email, email.Name));
            mail.Subject = "Portal de parceiro - redefinição de senha";
            mail.IsBodyHtml = true;
            mail.Body = email.MessageReset;

            SendEmail(mail);
        }

        private void SendEmail(MailMessage mail)
        {
            mail.Sender = new System.Net.Mail.MailAddress(emailBari, "Bari");
            mail.From = new MailAddress(emailBari, "Bari");
            mail.IsBodyHtml = true;

            try
            {
                client.Send(mail);
            }
            catch (System.Exception erro)
            {
                Console.WriteLine("********Email error********:. " + erro.Message);
            }
        }
    }
}