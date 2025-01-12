using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel.Model;

namespace DataAccess.Service.Interface
{
    public interface ITransactionInterface
    {
        Task<bool> CreateTransaction(TransactionModel transaction);

        Task<bool> DeleteTransaction(Guid TransactionId);

        Task<bool> UpdateTransaction(TransactionModel transaction, Guid TransactionId);

        Task<List<TransactionModel>> GetTransaction();

        Task<TransactionModel> GetTransactionById(Guid TransactionId);
    }
}
