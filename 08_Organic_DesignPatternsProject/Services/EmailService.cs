using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace _08_Organic_DesignPatternsProject.Services
{
    public class EmailService
    {
        private readonly EmailSettings _settings;

        public EmailService(IOptions<EmailSettings> settings)
        {
            _settings = settings.Value;
        }
        //mail gönderme
        public async Task SendAsync(string toEmail, string subject, string htmlBody)
        {
            var smtp = new SmtpClient(_settings.Host, _settings.Port)
            {
                Credentials = new NetworkCredential(_settings.SenderEmail, _settings.Password),
                EnableSsl = true
            };

            var mail = new MailMessage
            {
                From = new MailAddress(_settings.SenderEmail, _settings.SenderName),
                Subject = subject,
                Body = htmlBody,
                IsBodyHtml = true
            };

            mail.To.Add(toEmail);

            await smtp.SendMailAsync(mail);
        }
    }
}
