
using DataModel.Model;
using MudBlazor;
namespace Bachat.Components.Pages

{
    public partial class Home
    {

        private List<TransactionModel> Transactions = new();
        private List<DebtModel> Debts = new();
        private bool? _isDeletedTransaction = null;
        private bool? _isDeletedDebt = null;
        private double[] Top10income;
        private string[] Top10incomelabel;
        private double[] Top10expense;
        private string[] Top10expenselabel;

        private double totaldebt = 0;
        private double totalcredit = 0; 
        private double totaldebit = 0;
        private double currentBalance = 0;
        private double cleareddebt = 0;
        private double remainingdebt = 0;


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
            if (currentBalance < 0)
            {
                currentBalance = 0;
            }
            remainingdebt = totaldebt - cleareddebt;
            if (remainingdebt < 0)
            {
                remainingdebt = 0;
            }
            GetTop10TransactionLabels();
            GetTop10TransactionAmounts();
            GetTop10TransactionDLabels();
            GetTop10TransactionDAmounts();

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
        private void UpdateTransactions(Guid transactionId)
        {
            Nav.NavigateTo($"/update-transaction/{transactionId}");
        }

        private void UpdateDebts(Guid debtId)
        {
            Nav.NavigateTo($"/update-debt/{debtId}");
        }


        public void GetTop10TransactionAmounts()
        {

            Top10income = Transactions.Where(x => x.TransactionType == TransactionType.Credit)
                .OrderByDescending(x => Convert.ToDouble(x.TransactionAmount))
                .Take(10)
                .Select(x => Convert.ToDouble(x.TransactionAmount))
                .ToArray();

        }

        public void GetTop10TransactionLabels()
        {
            Top10incomelabel = Transactions.Where(x => x.TransactionType == TransactionType.Credit)
                .OrderByDescending(x => Convert.ToDouble(x.TransactionAmount))
                .Take(10)
                .Select(x => x.TransactionNotes)
                .ToArray();
        }

        public void GetTop10TransactionDAmounts()
        {

            Top10expense = Transactions.Where(x => x.TransactionType == TransactionType.Debit)
                .OrderByDescending(x => Convert.ToDouble(x.TransactionAmount))
                .Take(10)
                .Select(x => Convert.ToDouble(x.TransactionAmount))
                .ToArray();

        }

        public void GetTop10TransactionDLabels()
        {
            Top10expenselabel = Transactions.Where(x => x.TransactionType == TransactionType.Debit)
                .OrderByDescending(x => Convert.ToDouble(x.TransactionAmount))
                .Take(10)
                .Select(x => x.TransactionNotes)
                .ToArray();
        }
    }
}