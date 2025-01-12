using DataAccess.Service.Interface;
using DataModel.Abstractions;
using DataModel.Model;

namespace DataAccess.Service
{
    public class TransactionService : TransactionBase, ITransactionInterface
    {
        private List<TransactionModel> _transactions;
        public TransactionService()
        {
            _transactions = LoadTransactions();

        }

        public async Task<bool> CreateTransaction(TransactionModel transaction)
        {
            _transactions.Add(new TransactionModel
            {
                TransactionId = Guid.NewGuid(),
                TransactionAmount = transaction.TransactionAmount,
                TransactionDate = transaction.TransactionDate,
                TransactionNotes = transaction.TransactionNotes,
                TransactionType = transaction.TransactionType,
                TransactionTag = transaction.TransactionTag
            });

            SaveTransactions(_transactions);
            return true;
        }

        public async Task<bool> DeleteTransaction(Guid TransactionId)
        {
            var transactions = _transactions.FirstOrDefault(t => t.TransactionId == TransactionId);

            _transactions.Remove(transactions);

            SaveTransactions(_transactions);
            return true;
        }

        public async Task<List<TransactionModel>> GetTransaction()
        {
            return _transactions;
        }

        public async Task<TransactionModel> GetTransactionById(Guid TransactionId)
        {
            var transactions = _transactions.FirstOrDefault(t => t.TransactionId == TransactionId);
            return transactions;
        }

        public async Task<bool> UpdateTransaction(TransactionModel transaction, Guid TransactionId)
        {
            var transactions = _transactions.FirstOrDefault(t => t.TransactionId == TransactionId);
            if (transaction != null)
            {
                transactions.TransactionAmount = transaction.TransactionAmount;
                transactions.TransactionDate = transaction.TransactionDate;
                transactions.TransactionNotes = transaction.TransactionNotes;
                transactions.TransactionType = transaction.TransactionType;
                transactions.TransactionTag = transaction.TransactionTag;

                SaveTransactions(_transactions);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
