using System.Text.Json;
using DataModel.Model;

namespace DataModel.Abstractions
{
    public class DebtBase
    {
        protected static readonly string FilePath = Path.Combine(FileSystem.AppDataDirectory, "debt.json");

        protected List<DebtModel> LoadDebts()
        {
            if (!File.Exists(FilePath)) return new List<DebtModel>();
            var json = File.ReadAllText(FilePath);
            return JsonSerializer.Deserialize<List<DebtModel>>(json) ?? new List<DebtModel>();
        }

        protected void SaveDebts(List<DebtModel> debts)
        {
            var json = JsonSerializer.Serialize(debts);
            File.WriteAllText(FilePath, json);
        }
    }
}
