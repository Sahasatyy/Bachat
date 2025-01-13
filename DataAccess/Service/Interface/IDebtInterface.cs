using DataModel.Model;

namespace DataAccess.Service.Interface
{
    public interface IDebtInterface
    {
        Task<bool> CreateDebt(DebtModel debt);

        Task<bool> DeleteDebt(Guid DebtId);

        Task<bool> UpdateDebt(DebtModel debt, Guid DebtId);

        Task<List<DebtModel>> GetDebt();

        Task<DebtModel> GetDebtById(Guid DebtId);
    }
}
