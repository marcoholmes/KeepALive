using KeepAlive.Core.Domain;
using KeepAlive.Data.Extensions;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeepAlive.Data.Mappers
{
    public class UserMapper : IRowMapper<User>
    {
        public User MapRow(IDataRecord row)
        {
            return this.ReadData(row);
        }

        private User ReadData(IDataRecord record)
        {
            var item = new User()
            {
                Id = record.GetInteger("id_user"),
                UserName = record.GetString("ce_username"),
                Email = record.GetString("de_email"),
                Password = record.GetString("ce_pwd"),
                PasswordHash = record.GetString("ce_pwd_hash")
            };

            return item;
        }
    }
}
