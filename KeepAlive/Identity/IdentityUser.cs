using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace KeepAlive.Identity
{
    public class IdentityUser : IUser<int>
    {
        public IdentityUser()
        {
            
        }
        public IdentityUser(int id)
        {
            this.Id = id;
        }
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public string PhoneNumber { get; set; }


    }
}