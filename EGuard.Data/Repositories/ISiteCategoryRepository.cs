using EGuard.Data.Models;
using System.Collections.Generic;

namespace EGuard.Data.Repositories
{
    public interface ISiteCategoryRepository : IRepository<Site>
    {
        IEnumerable<string> GetPendingUrls();
        void UpdateWithCategory(Site site);
    }
}
