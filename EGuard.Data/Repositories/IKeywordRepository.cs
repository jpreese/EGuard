using EGuard.Data.Models;
using System.Collections.Generic;

namespace EGuard.Data.Repositories
{
    public interface IKeywordRepository : IRepository<Keyword>
    {
        IEnumerable<Keyword> GetAllKeywords();
    }
}
