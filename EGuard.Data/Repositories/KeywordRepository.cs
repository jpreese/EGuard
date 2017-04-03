using System.Collections.Generic;
using EGuard.Data.Models;
using System.Data;
using Dapper;
using System.Linq;

namespace EGuard.Data.Repositories
{
    public class KeywordRepository : IKeywordRepository
    {
        private readonly IDbConnection _database;

        public KeywordRepository(IDbConnection database)
        {
            _database = database;
        }

        public void Add(Keyword model)
        {
            _database.Execute("INSERT INTO Keyword(Description) VALUES(@Description)", new { Description = model.Description });
        }

        public void Delete(Keyword model)
        {
            _database.Execute("DELETE FROM Keyword WHERE Description = @Description", new { Description = model.Description });
        }

        public Keyword Get(Keyword model)
        {
            return _database.Query<Keyword>("SELECT Description FROM Keyword WHERE Description = @Description", new { Description = model.Description }).SingleOrDefault();
        }

        public IEnumerable<Keyword> GetAllKeywords()
        {
            return _database.Query<Keyword>("SELECT Description FROM Keyword");
        }
    }
}
