using DataModel.Model;


namespace Bachat.Components.Pages
{
    public partial class Addtransaction
    {
        private void cancel()
        {
            Nav.NavigateTo("/home");
        }

        public TransactionModel Transaction { get; set; } = new TransactionModel();

        public string? message = null;

        public async void submitTransaction()
        {
            Transaction.TransactionDate = DateTime.Now;

            if (await TransactionService.CreateTransaction(Transaction))
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