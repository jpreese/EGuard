namespace EGuard
{
    public class PasswordValidator
    {
        public bool Validate()
        {
            var passwordDialog = new PasswordDialog();

            if (passwordDialog.ShowDialog() == true && passwordDialog.Result == "abc123")
            {
                return true;
            }

            return false;
        }
    }
}
