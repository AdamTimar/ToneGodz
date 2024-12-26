
using System.Net;
using System.Net.Mail;
using System.Text;

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
                    Port = 587,  // Port for TLS
                    Credentials = new NetworkCredential("contact@tonegodz.com", _config["PrivateEmail:Password"]),
                    EnableSsl = true // Enable SSL/TLS encryption
                };

                // Create the email message
                MailMessage mailMessage = new MailMessage
                {
                    From = new MailAddress("contact@tonegodz.com"), // Sender's email address
                    Subject = subject,
                    Body = text,
                    IsBodyHtml = true // Set to true if you are sending HTML content
                };

                // Add recipient's email address
                mailMessage.To.Add(to);

                // Send the email
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