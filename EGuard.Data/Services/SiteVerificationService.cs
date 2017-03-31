using EGuard.Data.Models;
using System.Threading.Tasks;

namespace EGuard.Data.Services
{
    public class SiteVerificationService : ISiteVerificationService
    {
        public async Task<bool> Verify(Site site)
        {
            return false;
        }
    }
}
