
using System.Net;
using System.Net.Mail;
using MimeKit;

namespace ToneGodzApp.Services
{
    public class EmailSenderService : IEmailSenderService
    {
        private readonly IConfiguration _config;
        private readonly ILogger<EmailSenderService> _logger;
        private readonly IWebHostEnvironment _env;

        public EmailSenderService(IConfiguration configuration, ILogger<EmailSenderService> logger, IWebHostEnvironment env)
        {
            _config = configuration;
            _logger = logger;
            _env = env;
        }
        public async Task SendMail(string to, string subject, string text)
        {
            try
            {
                MailMessage mailMessage = new MailMessage
                {
                    From = new MailAddress("contact@tonegodz.com"),
                    Subject = subject,
                    Body = text,
                    IsBodyHtml = true
                };

                mailMessage.To.Add(to);

                if (_env.IsProduction())
                {
                    SmtpClient smtpClient = new SmtpClient("mail.privateemail.com")
                    {
                        Port = 587,
                        Credentials = new NetworkCredential("contact@tonegodz.com", _config["PrivateEmail:Password"]),
                        EnableSsl = true
                    };
                    smtpClient.Send(mailMessage);

                }

                else if (_env.IsDevelopment())
                {
                    using (var smtpClient = new MailKit.Net.Smtp.SmtpClient())
                    {
                        smtpClient.Connect("localhost", 1025, false);  // False means no SSL
                        smtpClient.Send(MimeMessage.CreateFromMailMessage(mailMessage));
                        smtpClient.Disconnect(true);
                    }
                }

                Console.WriteLine("Email sent successfully!");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }
    }
}