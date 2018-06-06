using KeepAlive.Core.Domain;

namespace KeepAlive.Core.Contracts.Data
{
    public interface IAccountData
    {
        User FindByName(string userName);
        bool CreateUser(User user);
    }
}
