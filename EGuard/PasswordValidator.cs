using EGuard.Data;
using EGuard.Data.Services;

namespace EGuard
{
    public class PasswordValidator
    {
        private readonly PasswordServiceProxy _passwordServiceProxy;

        public PasswordValidator(PasswordServiceProxy passwordServiceProxy)
        {
            _passwordServiceProxy = passwordServiceProxy;
        }

        public bool Validate()
        {
            var passwordDialog = new PasswordDialog();

            if (passwordDialog.ShowDialog() == false)
            {
                return false;
            }

            var validPassword = passwordDialog.Result == _passwordServiceProxy.GetPassword().Current;
            return validPassword;
        }
    }
}
