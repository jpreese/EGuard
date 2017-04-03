namespace EGuard.Emailing
{
    public class UnidentifiedCategoryMailer
    {
        private readonly IEmailComposer _emailComposer;
        private readonly IEmailSender _emailSender;

        public UnidentifiedCategoryMailer(IEmailComposer emailComposer, IEmailSender emailSender)
        {
            _emailComposer = emailComposer;
            _emailSender = emailSender;
        }

        public void SendMail()
        {
            var message = _emailComposer.Compose();
            _emailSender.Send(message);
        }
    }
}
