using System.Net.Mail;

namespace EGuard.Emailing
{
    public interface IEmailSender
    {
        void Send(MailMessage message);
    }
}
