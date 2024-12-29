namespace Bachat.Components.Pages
{
    public partial class Home
    {
        protected override void OnInitialized()
        {
            Nav.NavigateTo("/login");
        }
    }
}