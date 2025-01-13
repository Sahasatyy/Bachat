using DataModel.Model;

namespace Bachat.Components.Pages
{
    public partial class Adddebt
    {
        private void cancel()
        {
            Nav.NavigateTo("/home");
        }

        public DebtModel Debt { get; set; } = new DebtModel();

        public string? message = null;

        public async void submitDebt()
        {
            if (await DebtService.CreateDebt(Debt))
            {
                message = "success";
                Nav.NavigateTo("/home", forceLoad: true);
            }
            else
            {
                message = "failed";
            }
        }
    }
}