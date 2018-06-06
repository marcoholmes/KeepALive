using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeepAlive.Core.Domain
{
    public class User
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public DateTime DataRegistrazione { get; set; }
        public bool EmailConfermata { get; set; }
        public bool AccountBloccato { get; set; }


    }
}
