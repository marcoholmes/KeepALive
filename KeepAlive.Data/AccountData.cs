using KeepAlive.Core.Contracts.Data;
using KeepAlive.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeepAlive.Data
{
    public class AccountData : IAccountData
    {
        public IdentityUser FindByName(string userName)
        {
            throw new NotImplementedException();
        }
    }
}
