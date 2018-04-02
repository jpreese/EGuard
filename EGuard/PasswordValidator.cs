using EGuard.Data;

namespace EGuard
{
    public class PasswordValidator
    {
        private readonly IPasswordService _passwordService;

        public PasswordValidator(IPasswordService passwordService)
        {
            _passwordService = passwordService;
        }

        public bool Validate()
        {
            var passwordDialog = new PasswordDialog();

            if (passwordDialog.ShowDialog() == false)
            {
                return false;
            }

            var validPassword = passwordDialog.Result == _passwordService.GetPassword().Current;
            return validPassword;
        }
    }
}
