using System.Security.Cryptography;
using System.Text;
using DataAccess.Service.Interface;
using DataModel.Abstractions;
using DataModel.Model;

namespace DataAccess.Service
{
    public class UserService : UserBase, IUserInterface
    {
        public async Task<bool> Login(UserModel user)
        {
            if (string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.Password))
            {
                return false; // Invalid input
            }

            // Hash the provided password
            var hashedPassword = HashPassword(user.Password);

            // Hash the seeded password for comparison
            var seededHashedPassword = HashPassword(UserSeeding.Password);

            // Validate the username and password
            return user.Username == UserSeeding.Username && hashedPassword == seededHashedPassword;
        }

        private string HashPassword(string password)
        {
            // Use SHA256 to hash the password
            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(password);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }
    }
}
