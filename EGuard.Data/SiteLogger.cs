using System;
using System.Collections.Generic;
using EGuard.Data.Models;
using System.Data;
using Dapper;

namespace EGuard.Data
{
    public class SiteLogger : ILog<Site>
    {
        private readonly IDbConnection _database;

        public SiteLogger(IDbConnection database)
        {
            _database = database;
        }

        public IEnumerable<Site> GetByDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public void Log(Site data)
        {
            _database.Execute("INSERT INTO Site(Url, Date) VALUES(@Url, @Date)", new { Url = data.Url, Date = DateTime.Now });
        }
    }
}
