using System.Net.Mail;

namespace EGuard.Emailing
{
    public class UnidentifiedCategoryMessageBuilder : IMessageBuilder
    {
        private MailMessage message;

        public UnidentifiedCategoryMessageBuilder()
        {
            message = new MailMessage();
        }

        public MailMessage CreateMessage()
        {
            return message;
        }

        public void SetBody()
        {
            message.Body = "This is an automated message from the EGuard system letting you know that you have a new unidentified website. ";
            message.Body = message.Body + "Please review the website at your earliest convenience.";
        }

        public void SetFrom()
        {
            message.From = new MailAddress("eguardtester@gmail.com");
        }

        public void SetSubject()
        {
            message.Subject = "Unidentified Category";
        }

        public void SetTo()
        {
            message.To.Add(new MailAddress("eguardtester@gmail.com"));
        }
    }
}
