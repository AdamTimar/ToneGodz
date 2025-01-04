
using System.Net;
using System.Net.Mail;

namespace ToneGodzApp.Services
{
    public class EmailSenderService : IEmailSenderService
    {
        private readonly IConfiguration _config;
        private readonly ILogger<EmailSenderService> _logger;

        public EmailSenderService(IConfiguration configuration, ILogger<EmailSenderService> logger)
        {
            _config = configuration;
            _logger = logger;

        }
        public async Task SendMail(string to, string subject, string text)
        {
            try
            {
                SmtpClient smtpClient = new SmtpClient("mail.privateemail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("contact@tonegodz.com", _config["PrivateEmail:Password"]),
                    EnableSsl = true 
                };

                MailMessage mailMessage = new MailMessage
                {
                    From = new MailAddress("contact@tonegodz.com"),
                    Subject = subject,
                    Body = text,
                    IsBodyHtml = true
                };

                mailMessage.To.Add(to);

                smtpClient.Send(mailMessage);

                Console.WriteLine("Email sent successfully!");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }
    }
}