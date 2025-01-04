namespace Bachat.Components.Layout
{
    public partial class NavMenu
    { 
        private void logout()
        {
            Nav.NavigateTo("/login");
        }

        private void addtransaction()
        {
            Nav.NavigateTo("/addtransaction");
        }
    }
}