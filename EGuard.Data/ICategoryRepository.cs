using EGuard.Data.Models;
using System.Collections.Generic;

namespace EGuard.Data
{
    public interface ICategoryRepository : IRepository<Category>
    {
        IEnumerable<Category> GetAllCategories();
    }
}
