using DataModel.Model;

namespace DataAccess.Service.Interface
{
    public interface IUserInterface
    {
        Task<bool> Login(UserModel user);
    }
}
