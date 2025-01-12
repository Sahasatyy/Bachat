using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using DataModel.Model;

namespace DataModel.Abstractions
{
    public class TransactionBase
    {
        protected static readonly string FilePath = Path.Combine(FileSystem.AppDataDirectory, "transaction.json");

        protected List<TransactionModel> LoadTransactions()
        {
            if (!File.Exists(FilePath)) return new List<TransactionModel>();
            var json = File.ReadAllText(FilePath);
            return JsonSerializer.Deserialize<List<TransactionModel>>(json) ?? new List<TransactionModel>();
        }

        protected void SaveTransactions(List<TransactionModel> transactions)
        {
            var json = JsonSerializer.Serialize(transactions);
            File.WriteAllText(FilePath, json);
        }
    }
}
