using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace KeepAlive.Identity
{
    public class UserStore : IUserStore<IdentityUser, int>,
                             IUserPasswordStore<IdentityUser, int>,
                             IUserEmailStore<IdentityUser, int>
                                
    {
        public Task CreateAsync(IdentityUser user)
        {
            return Task.CompletedTask;
        }

        public Task DeleteAsync(IdentityUser user)
        {
            throw new NotImplementedException();
        }

        protected virtual void Dispose(bool disposing) { }

        public void Dispose()
        {
            //Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
            Dispose(true);
        }

        public Task<IdentityUser> FindByIdAsync(int userId)
        {
            return Task.FromResult(new IdentityUser(1));
        }

        public Task<IdentityUser> FindByNameAsync(string userName)
        {
            IdentityUser user = new IdentityUser(1);
            return Task.FromResult(default(IdentityUser));
        }

        public Task UpdateAsync(IdentityUser user)
        {
            throw new NotImplementedException();
        }

        public Task SetPasswordHashAsync(IdentityUser user, string passwordHash)
        {
            return Task.CompletedTask;
        }

        public Task<string> GetPasswordHashAsync(IdentityUser user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> HasPasswordAsync(IdentityUser user)
        {
            throw new NotImplementedException();
        }

        public Task SetEmailAsync(IdentityUser user, string email)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetEmailAsync(IdentityUser user)
        {
            return Task.FromResult("k@k.it");
        }

        public Task<bool> GetEmailConfirmedAsync(IdentityUser user)
        {
            throw new NotImplementedException();
        }

        public Task SetEmailConfirmedAsync(IdentityUser user, bool confirmed)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityUser> FindByEmailAsync(string email)
        {
            return Task.FromResult(default(IdentityUser));
        }
    }
}