using KeepAlive.Core.Domain;
using KeepAlive.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeepAlive.Core.Contracts.Data
{
    public interface IAccountData
    {
        User FindByName(string userName);
    }
}
