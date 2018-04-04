using EGuard.Data.Models;

namespace EGuard.Rules
{
    public interface IRule
    {
        bool Check(Site site);
        int Priority { get; }
    }
}