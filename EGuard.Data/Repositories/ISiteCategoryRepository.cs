using EGuard.Data.Models;
using System.Collections.Generic;

namespace EGuard.Data.Repositories
{
    public interface ISiteCategoryRepository : IRepository<string>
    {
        IEnumerable<string> GetPendingUrls();
        void UpdateWithCategory(Site site);
    }
}
