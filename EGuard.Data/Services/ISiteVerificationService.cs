using EGuard.Data.Models;
using System.Threading.Tasks;

namespace EGuard.Data.Services
{
    public interface ISiteVerificationService
    {
        Task<bool> Verify(Site site);
    }
}
