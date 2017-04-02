using System.Net.Mail;

namespace EGuard.Emailing
{
    public interface IMessageBuilder
    {
        void SetFrom();
        void SetTo();
        void SetSubject();
        void SetBody();
        MailMessage CreateMessage();
    }
}
