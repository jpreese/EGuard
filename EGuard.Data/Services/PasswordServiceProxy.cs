using EGuard.Data.Models;

namespace EGuard.Data.Services
{
    public class PasswordServiceProxy
    {
        private readonly IPasswordService _passwordService;
        private static Password _cache;

        public PasswordServiceProxy(IPasswordService passwordService)
        {
            _passwordService = passwordService;
        }

        public Password GetPassword()
        {
            if(_cache == null)
            {
                _cache = _passwordService.GetPassword();
            }

            return _cache;
        }
    }
}
