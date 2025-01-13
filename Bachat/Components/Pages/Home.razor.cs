
using DataModel.Model;
namespace Bachat.Components.Pages

{
    public partial class Home
    {

        private List<TransactionModel> Transactions = new();
        private List<DebtModel> Debts = new();
        private bool? _isDeletedTransaction = null;
        private bool? _isDeletedDebt = null;
        protected async override void OnInitialized()
        {
           Transactions = await TransactionService.GetTransaction();
           Debts = await DebtService.GetDebt();
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

        private async Task<List<DebtModel>> GetDebt()
        {
            try
            {
                Debts = await DebtService.GetDebt();

                return Debts;

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
                _isDeletedTransaction = await TransactionService.DeleteTransaction(TranctionID);
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
        private async Task DeleteDebt(Guid DebtID)
        {
            try
            {
                _isDeletedDebt = await DebtService.DeleteDebt(DebtID);
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
    }
}