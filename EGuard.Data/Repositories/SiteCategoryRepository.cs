using EGuard.Data.Models;
using System.Data;
using Dapper;
using System.Collections.Generic;
using System.Linq;

namespace EGuard.Data.Repositories
{
    public class SiteCategoryRepository : ISiteCategoryRepository
    {
        private readonly IDbConnection _database;

        public SiteCategoryRepository(IDbConnection database)
        {
            _database = database;
        }

        public void Add(Site model)
        {
            _database.Execute("INSERT INTO Site_Category(Url, Category) VALUES(@Url, @Category)", new { Url = model.Url, Category = model.Category });
        }

        public void Delete(Site model)
        {
            _database.Execute("DELETE FROM Site_Category WHERE Url = @Url", new { Url = model.Url });
        }

        public Site Get(Site model)
        {
            return _database.Query("SELECT Url FROM Site_Category WHERE Url = @Url", new { Url = model.Url }).SingleOrDefault();
        }

        public IEnumerable<Site> GetPendingSites()
        {
            return _database.Query<Site>("SELECT Url FROM Site_Category WHERE Category IS NULL");
        }

        public void UpdateWithCategory(Site site)
        {
            _database.Execute("UPDATE Site_Category SET Category = @Category WHERE Url = @Url", new { Category = site.Category, Url = site.Url });
        }
    }
}
