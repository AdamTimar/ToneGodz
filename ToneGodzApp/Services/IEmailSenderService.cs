namespace ToneGodzApp.Services
{
    public interface IEmailSenderService
    {
        public Task SendMail(string to, string subject, string text);
    }
}