using EGuard.Data.Models;
using System.Data;
using Dapper;
using System.Collections.Generic;
using System.Linq;

namespace EGuard.Data.Repositories
{
    class SiteCategoryRepository : ISiteCategoryRepository
    {
        private readonly IDbConnection _database;

        public SiteCategoryRepository(IDbConnection database)
        {
            _database = database;
        }

        public void Add(SiteCategory model)
        {
            _database.Execute("INSERT INTO Site_Category(Url, Category) VALUES(@Url, @Category)", new { Site = model.Site.Url, model.Category.Name });
        }

        public void Delete(SiteCategory model)
        {
            _database.Execute("DELETE FROM Site_Category WHERE Url = @Url AND Category = @Category", new { Url = model.Site.Url, model.Category.Name });
        }

        public SiteCategory Get(SiteCategory model)
        {
            return _database.Query("SELECT Url, Category FROM Site_Category WHERE Url = @Url AND Category = @Category", new { Url = model.Site.Url, model.Category.Name }).SingleOrDefault();
        }

        public IEnumerable<SiteCategory> GetPendingSites()
        {
            return _database.Query<SiteCategory>("SELECT Url, Category FROM Site_Category WHERE Category = @Empty", new { Empty = string.Empty });
        }
    }
}
