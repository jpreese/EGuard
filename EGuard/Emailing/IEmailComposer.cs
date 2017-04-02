using System.Net.Mail;

namespace EGuard.Emailing
{
    public interface IEmailComposer
    {
        MailMessage Compose();
    }
}
