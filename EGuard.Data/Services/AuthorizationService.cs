using System.Data;
using EGuard.Data.Models;
using System.Linq;
using Dapper;

namespace EGuard.Data.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly IDbConnection _database;

        public AuthorizationService(IDbConnection database)
        {
            _database = database;
        }

        public Authorization GetAuthorization()
        {
            return _database.Query<Authorization>("SELECT Email,Password FROM Authorization").SingleOrDefault();
        }
    }
}
