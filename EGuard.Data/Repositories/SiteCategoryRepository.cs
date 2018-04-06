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

        public void Add(string url)
        {
            _database.Execute("INSERT INTO Site_Category(Url) VALUES(@Url)", new { Url = url });
        }

        public void Delete(string url)
        {
            _database.Execute("DELETE FROM Site_Category WHERE Url = @Url", new { Url = url });
        }

        public string Get(string url)
        {
            return _database.Query("SELECT Url FROM Site_Category WHERE Url = @Url", new { Url = url }).SingleOrDefault();
        }

        public IEnumerable<string> GetPendingUrls()
        {
            return _database.Query<string>("SELECT Url FROM Site_Category WHERE Category IS NULL");
        }

        public void UpdateWithCategory(Site site)
        {
            _database.Execute("UPDATE Site_Category SET Category = @Category WHERE Url = @Url", new { Category = site.Category, Url = site.Url });
        }
    }
}
