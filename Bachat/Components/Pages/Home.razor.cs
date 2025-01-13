
using DataModel.Model;
namespace Bachat.Components.Pages

{
    public partial class Home
    {

        private List<TransactionModel> Transactions = new();
        private List<DebtModel> Debts = new();
        private bool? _isDeletedTransaction = null;
        private bool? _isDeletedDebt = null;

        private double totaldebt = 0;
        private double totalcredit = 0; 
        private double totaldebit = 0;
        private double currentBalance = 0;
        private double cleareddebt = 0;
        private double remainingdebt = 0;

        string[] labels = { "totaldebts", "totalcredits", "totaldebits" };
        public int Index { get; set; } = -1;

        protected async override Task OnInitializedAsync()
        {
           Transactions = await TransactionService.GetTransaction();
           Debts = await DebtService.GetDebt();
           var localdebt = await DebtService.GetClearedDebt();
           cleareddebt = localdebt.Sum(x => Convert.ToDouble(x.DebtAmount));
           totaldebt = Debts.Sum(x => Convert.ToDouble(x.DebtAmount));
           totaldebit = Transactions.Where(x => x.TransactionType == TransactionType.Debit).Sum(x => Convert.ToDouble(x.TransactionAmount));
           totalcredit = Transactions.Where(x => x.TransactionType == TransactionType.Credit).Sum(x => Convert.ToDouble(x.TransactionAmount));
           currentBalance = totalcredit - totaldebit;
           remainingdebt = totaldebt - cleareddebt;
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
                Debts = await DebtService.GetDebt();
                var localdebt = await DebtService.GetClearedDebt();
                cleareddebt = localdebt.Sum(x => Convert.ToDouble(x.DebtAmount));
                StateHasChanged();

            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }


    }
}