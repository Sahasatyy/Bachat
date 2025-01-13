namespace Bachat.Components.Layout
{
    public partial class NavMenu
    { 

        private void addtransaction()
        {
            Nav.NavigateTo("/addtransaction");
        }

        private void adddebt()
        {
            Nav.NavigateTo("/adddebt");
        }

        private bool logout_confirm { get; set; }

        private void cancelLogout()
        {
            logout_confirm = false;
        }

        private void logout()
        {
            logout_confirm = true;
        }

        private void confirmLogout()
        {
            Nav.NavigateTo("/login");
        }

    }
}