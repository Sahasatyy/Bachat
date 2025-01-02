using DataModel.Model;

namespace Bachat.Components.Pages
{
    public partial class Login
    {
        private string? ErrorMessage;
        public UserModel user { get; set; } = new();
        private async void HandleLogin()
        {
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