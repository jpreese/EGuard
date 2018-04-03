using EGuard.Data.Models;
using System.Collections.Generic;

namespace EGuard.Data.Repositories
{
    public interface ISiteCategoryRepository : IRepository<SiteCategory>
    {
        IEnumerable<SiteCategory> GetPendingSites();
    }
}
