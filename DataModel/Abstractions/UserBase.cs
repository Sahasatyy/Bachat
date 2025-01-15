using DataModel.Model;
using System.Text.Json;

namespace DataModel.Abstractions
{
    public class UserBase
    {
        protected static readonly string FilePath = Path.Combine(FileSystem.AppDataDirectory, "User.json");

        protected List<UserModel> LoadUsers()
        {
            if (!File.Exists(FilePath)) return new List<UserModel>();
            var json = File.ReadAllText(FilePath);
            return JsonSerializer.Deserialize<List<UserModel>>(json) ?? new List<UserModel>();
        }

        protected void SaveUsers(List<UserModel> users)
        {
            var json = JsonSerializer.Serialize(users);
            File.WriteAllText(FilePath, json);
        }
    }
}
