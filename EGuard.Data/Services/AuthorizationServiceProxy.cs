using EGuard.Data.Models;

namespace EGuard.Data.Services
{
    public class AuthorizationServiceProxy : IAuthorizationService
    {
        private readonly IAuthorizationService _authorizationService;
        private static Authorization _cache;

        public AuthorizationServiceProxy(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        public Authorization GetAuthorization()
        {
            if(_cache == null)
            {
                _cache = _authorizationService.GetAuthorization();
            }

            return _cache;
        }
    }
}
