using DataAccess.Service.Interface;
using DataModel.Abstractions;
using DataModel.Model;


namespace DataAccess.Service
{
    public class DebtService : DebtBase, IDebtInterface
    {
        private List<DebtModel> _debts;
        public DebtService()
        {
            _debts = LoadDebts();

        }

        public async Task<bool> CreateDebt(DebtModel debt)
        {
            _debts.Add(new DebtModel
            {
                DebtId = Guid.NewGuid(),
                DebtAmount = debt.DebtAmount,
                DebtStartDate = debt.DebtStartDate,
                DebtDueDate = debt.DebtDueDate,
                DebtNotes = debt.DebtNotes,
                DebtSource = debt.DebtSource,
            });

            SaveDebts(_debts);
            return true;
        }

        public async Task<bool> DeleteDebt(Guid DebtId)
        {
            var debts = _debts.FirstOrDefault(d => d.DebtId == DebtId);

            _debts.Remove(debts);

            SaveDebts(_debts);
            return true;
        }

        public async Task<List<DebtModel>> GetDebt()
        {
            return _debts;
        }

        public async Task<DebtModel> GetDebtById(Guid DebtId)
        {
            var debts = _debts.FirstOrDefault(d => d.DebtId == DebtId);
            return debts;
        }

        public async Task<bool> UpdateDebt(DebtModel debt, Guid DebtId)
        {
            var debts = _debts.FirstOrDefault(d => d.DebtId == DebtId);
            if (debt != null)
            {
                debts.DebtAmount = debt.DebtAmount;
                debts.DebtStartDate = debt.DebtStartDate;
                debts.DebtDueDate = debt.DebtDueDate;
                debts.DebtNotes = debt.DebtNotes;
                debts.DebtSource = debt.DebtSource;

                SaveDebts(_debts);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
