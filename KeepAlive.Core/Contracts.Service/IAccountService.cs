using KeepAlive.Core.Domain;
using KeepAlive.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeepAlive.Core.Contracts.Service
{
    public interface IAccountService
    {
        User FindByName(string userName);
    }
}
