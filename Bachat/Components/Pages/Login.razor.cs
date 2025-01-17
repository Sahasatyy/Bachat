using DataModel.Model;

namespace Bachat.Components.Pages
{
    public partial class Login
    {
        private string? ErrorMessage;
        public UserModel user { get; set; } = new();

        private async Task HandleLogin()
        {
            // Basic client-side validation
            if (string.IsNullOrWhiteSpace(user.Username) || string.IsNullOrWhiteSpace(user.Password))
            {
                ErrorMessage = "Username and password cannot be empty.";
                return;
            }

            // Delegate server-side validation to UserService
            if (await UserService.Login(user))
            {
                Nav.NavigateTo("/home");
            }
            else
            {
                ErrorMessage = "Invalid username or password.";
            }
        }
    }
}
