﻿using System.Net.Mail;

namespace EGuard.Emailing
{
    public class EmailComposer : IEmailComposer
    {
        private readonly IMessageBuilder _builder;

        public EmailComposer(IMessageBuilder builder)
        {
            _builder = builder;
        }

        public MailMessage Compose()
        {
            _builder.SetTo();
            _builder.SetFrom();
            _builder.SetSubject();
            _builder.SetBody();

            return _builder.CreateMessage();
        }
    }
}
