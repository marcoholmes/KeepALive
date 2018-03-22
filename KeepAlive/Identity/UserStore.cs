using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace KeepAlive.Identity
{
    public class UserStore : IUserStore<IdentityUser, int>
    {
        public Task CreateAsync(IdentityUser user)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public Task<IdentityUser> FindByNameAsync(string userName)
        {
            IdentityUser user = new IdentityUser(1);
            return Task.FromResult(user);
        }

        public Task UpdateAsync(IdentityUser user)
        {
            throw new NotImplementedException();
        }
    }
}