using EGuard.Data;
using EGuard.Data.Services;

namespace EGuard
{
    public class PasswordValidator
    {
        private readonly AuthorizationServiceProxy _authorizationServiceProxy;

        public PasswordValidator(AuthorizationServiceProxy authorizationServiceProxy)
        {
            _authorizationServiceProxy = authorizationServiceProxy;
        }

        public bool Validate()
        {
            var passwordDialog = new PasswordDialog();

            if (passwordDialog.ShowDialog() == false)
            {
                return false;
            }

            var validPassword = passwordDialog.Result == _authorizationServiceProxy.GetAuthorization().Password;
            return validPassword;
        }
    }
}
