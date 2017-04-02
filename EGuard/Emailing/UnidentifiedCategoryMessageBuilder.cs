using System.Net.Mail;

namespace EGuard.Emailing
{
    class UnidentifiedCategoryMessageBuilder : IMessageBuilder
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
            message.Body = "email from eguard";
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
