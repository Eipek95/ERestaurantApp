﻿
using Microsoft.Extensions.Options;
using SignalR.WEB_Food.OptionsModel;
using System.Net;
using System.Net.Mail;

namespace SignalR.WEB_Food.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _emailSettings;

        public EmailService(IOptions<EmailSettings> options)
        {
            _emailSettings = options.Value;
        }

        public async Task SendResetPasswordEmail(string resetPasswordEmailLink, string ToEmail)
        {
            var smtpClient = new SmtpClient();

            smtpClient.Host = _emailSettings.Host;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Port = 587;
            smtpClient.Credentials = new NetworkCredential(_emailSettings.Email, _emailSettings.Password);
            smtpClient.EnableSsl = true;



            var mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(_emailSettings.Email);
            mailMessage.To.Add(ToEmail);


            mailMessage.Subject = "SignalR Restaurant | Şifre Sıfırlama Linki";
            mailMessage.Body = @$"
                    <h4>Şifrenizi yenilemek için aşağıdaki linkte tıklayınız.</h4> 
                    <p>
                    <a href='{resetPasswordEmailLink}'>şifre yenileme link<a/>
                    </p>";

            mailMessage.IsBodyHtml = true;
            await smtpClient.SendMailAsync(mailMessage);


        }
    }
}
