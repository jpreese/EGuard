using EGuard.Data.Models;
using System.Threading.Tasks;

namespace EGuard.Data
{
    public interface ISiteInformationService
    {
        Task<SiteInformation> GetSiteInformationAsync(string url);
    }
}
