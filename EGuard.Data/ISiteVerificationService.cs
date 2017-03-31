using EGuard.Data.Models;
using System.Threading.Tasks;

namespace EGuard.Data
{
    public interface ISiteVerificationService
    {
        Task<bool> Verify(Site site);
    }
}
