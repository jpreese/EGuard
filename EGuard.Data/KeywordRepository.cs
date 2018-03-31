using System;
using System.Collections.Generic;
using EGuard.Data.Models;
using System.Data;
using Dapper;

namespace EGuard.Data
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
            throw new NotImplementedException();
        }

        public IEnumerable<Keyword> GetAllKeywords()
        {
            return _database.Query<Keyword>("SELECT Description FROM Keyword");
        }
    }
}
