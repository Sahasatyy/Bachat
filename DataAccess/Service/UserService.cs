

using DataAccess.Service.Interface;
using DataModel.Abstractions;
using DataModel.Model;

namespace DataAccess.Service
{
    public class UserService : UserBase, IUserInterface
    {
        private List<UserModel> _users;

        public UserService()
        {
            _users = LoadUsers();

            // Add default admin user if the file is empty
            if (!_users.Any())
            {
                _users.Add(new UserModel { Username = UserSeeding.Username, Password = UserSeeding.Password });
                SaveUsers(_users);
            }
        }
        public async Task<bool> Login(UserModel user)
        {
            if (string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.Password))
            {
                return false;
            }
            return _users.Any(u => u.Username == user.Username && u.Password == u.Password);
        }
    }
}
