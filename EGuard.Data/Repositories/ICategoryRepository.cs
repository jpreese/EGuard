using EGuard.Data.Models;
using System.Collections.Generic;

namespace EGuard.Data.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        IEnumerable<Category> GetAllCategories();
        IEnumerable<Category> GetBlockedCategories();
        void UnblockCategory(Category model);
        void BlockCategory(Category model);
    }
}
