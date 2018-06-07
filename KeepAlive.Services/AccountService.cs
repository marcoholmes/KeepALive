using KeepAlive.Core.Contracts.Data;
using KeepAlive.Core.Contracts.Service;
using KeepAlive.Core.Domain;
using System;

namespace KeepAlive.Services
{
    public class AccountService : IAccountService
    {
        private IAccountData _accountData;

        public AccountService(IAccountData accountData)
        {
            _accountData = accountData;
        }

        public User FindByName(string userName)
        {
            return _accountData.FindByName(userName);
        }

        public User FindByEmail(string email)
        {
            return _accountData.FindByEmail(email);
        }

        public bool CreateUser(User user)
        {
            user.AccountBloccato = false;
            user.DataRegistrazione = DateTime.Now;
            user.EmailConfermata = false;
            return _accountData.CreateUser(user);
        }
    }
}
