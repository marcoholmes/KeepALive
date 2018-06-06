using KeepAlive.Core.Contracts.Data;
using KeepAlive.Core.Domain;
using KeepAlive.Data.DB;
using KeepAlive.Data.Mappers;
using Microsoft.Practices.EnterpriseLibrary.Data;
using KeepAlive.Data.Extensions;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeepAlive.Data
{
    public class AccountData : IAccountData
    {

        public User FindByName(string userName)
        {

            Database db = DbFactory.CreateDatabase();
            User retVal = null;

            var sql = @"SELECT * FROM users 
                        WHERE ce_username = @ce_username";

            using (DbCommand cmd = db.GetSqlStringCommand(sql))
            {
                IRowMapper<User> mapper = new UserMapper();
                db.AddInParameter(cmd, "@ce_username", System.Data.DbType.String, userName);
                retVal = db.ExecuteDbCommand(cmd, mapper);
            }

            return retVal;
        }

        public bool CreateUser(User user)
        {
            Database db = DbFactory.CreateDatabase();
            int success = 0;

            var sql = @"INSERT INTO users (ce_username, de_email, ce_pwd_hash, ce_pwd, da_registration, yn_confirm_email, yn_locked)
                        VALUES(@ce_username, @de_email, @ce_pwd_hash, @ce_pwd, @da_registration, @yn_confirm_email, @yn_locked)";

            using (DbCommand cmd = db.GetSqlStringCommand(sql))
            {

                db.AddInParameter(cmd, "@ce_username", System.Data.DbType.String, user.UserName);
                db.AddInParameter(cmd, "@de_email", System.Data.DbType.String, user.Email);
                db.AddInParameter(cmd, "@ce_pwd_hash", System.Data.DbType.String, user.PasswordHash);
                db.AddInParameter(cmd, "@ce_pwd", System.Data.DbType.String, user.Password);
                db.AddInParameter(cmd, "@da_registration", System.Data.DbType.DateTime, user.DataRegistrazione);
                db.AddInParameter(cmd, "@yn_confirm_email", System.Data.DbType.Boolean, user.EmailConfermata);
                db.AddInParameter(cmd, "@yn_locked", System.Data.DbType.Boolean, user.AccountBloccato);

                success = db.ExecuteDbCommand(cmd);
            }

            return success > 0;
        }
    }
}
