using EGuard.Data.Services;
using System.Net;
using System.Net.Mail;

namespace EGuard.Emailing
{
    public class EmailSender : IEmailSender
    {
        private readonly IAuthorizationService _authorizationService;

        public EmailSender(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        public void Send(MailMessage message)
        {
            using (var client = CreateMailClient())
            {
                client.Send(message);
            }
        }

        private SmtpClient CreateMailClient()
        {
            var auth = _authorizationService.GetAuthorization();
            var client = new SmtpClient();

            client.Host = "smtp.googlemail.com";
            client.Port = 587;
            client.UseDefaultCredentials = false;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential(auth.Email, auth.Password);

            return client;
        }
    }
}
