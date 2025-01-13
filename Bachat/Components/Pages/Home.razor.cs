
using DataModel.Model;
using MudBlazor.Charts;
using System.Transactions;
namespace Bachat.Components.Pages

{
    public partial class Home
    {

        private List<TransactionModel> Transactions = new();
        private bool? _isDeleted = null;
        protected async override void OnInitialized()
        {
           Transactions = await TransactionService.GetTransaction();
        }


        private async Task<List<TransactionModel>> GetTransaction()
        {
            try
            {
                Transactions = await TransactionService.GetTransaction();

                return Transactions;

            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        private async Task DeleteTransaction(Guid TranctionID)
        {
            try
            {
                _isDeleted = await TransactionService.DeleteTransaction(TranctionID);
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
    }
}