using System.Collections.Generic;
using EGuard.Data.Models;
using System.Data;
using Dapper;
using System.Linq;

namespace EGuard.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IDbConnection _database;

        public CategoryRepository(IDbConnection database)
        {
            _database = database;
        }

        public void Add(Category model)
        {
            _database.Execute("INSERT INTO Category(Name) VALUES(@Name)", new { Name = model.Name });
        }

        public void Delete(Category model)
        {
            _database.Execute("DELETE FROM Category WHERE Name = @Name", new { Name = model.Name });
        }

        public Category Get(Category model)
        {
            return _database.Query<Category>("SELECT Name FROM Category WHERE Name = @Name", new { Name = model.Name }).SingleOrDefault();
        }

        public void BlockCategory(Category model)
        {
            _database.Execute("UPDATE Category SET Blocked = 1 WHERE Name = @Name", new { Name = model.Name });
        }

        public void UnblockCategory(Category model)
        {
            _database.Execute("UPDATE Category SET Blocked = 0 WHERE Name = @Name", new { Name = model.Name });
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _database.Query<Category>("SELECT Name FROM Category");
        }

        public IEnumerable<Category> GetBlockedCategories()
        {
            return _database.Query<Category>("SELECT Name FROM Category WHERE Blocked = 1");
        }
    }
}