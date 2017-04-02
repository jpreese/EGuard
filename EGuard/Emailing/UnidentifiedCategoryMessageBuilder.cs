namespace EGuard.Emailing
{
    class UnidentifiedCategoryMessageBuilder : IMessageBuilder
    {
        private Message message;

        public UnidentifiedCategoryMessageBuilder()
        {
            message = new Message();
        }

        public Message CreateMessage()
        {
            return message;
        }

        public void SetBody()
        {
            message.Body = "email from eguard";
        }

        public void SetFrom()
        {
            message.From = "noreply@eguard.com";
        }

        public void SetSubject()
        {
            message.Subject = "Unidentified Category";
        }

        public void SetTo()
        {
            message.To = "frogub@gmail.com";
        }
    }
}
