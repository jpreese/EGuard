using System.Data;
using EGuard.Data.Models;
using System.Linq;
using Dapper;

namespace EGuard.Data.Services
{
    public class PasswordService : IPasswordService
    {
        private readonly IDbConnection _database;

        public PasswordService(IDbConnection database)
        {
            _database = database;
        }

        public Password GetPassword()
        {
            return _database.Query<Password>("SELECT Current FROM Password").SingleOrDefault();
        }
    }
}
