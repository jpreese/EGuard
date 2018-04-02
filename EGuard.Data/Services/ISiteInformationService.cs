using EGuard.Data.Models;
using System.Threading.Tasks;

namespace EGuard.Data.Services
{
    public interface ISiteInformationService
    {
        Task<SiteInformation> GetSiteInformationAsync(string url);
    }
}
