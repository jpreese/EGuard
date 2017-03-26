using System.Collections.Generic;
using EGuard.Data.Models;
using System.Data;
using Dapper;
using System.Linq;

namespace EGuard.Data
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

        public IEnumerable<Category> GetAllCategories()
        {
            return _database.Query<Category>("SELECT Name FROM Category");
        }
    }
}