using KeepAlive.Core.Domain;

namespace KeepAlive.Core.Contracts.Service
{
    public interface IAccountService
    {
        User FindByName(string userName);
        bool CreateUser(User user);
        User FindByEmail(string email);
    }
}
