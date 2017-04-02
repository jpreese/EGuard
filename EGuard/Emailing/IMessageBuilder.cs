namespace EGuard.Emailing
{
    public interface IMessageBuilder
    {
        void SetFrom();
        void SetTo();
        void SetSubject();
        void SetBody();
        Message CreateMessage();
    }
}
