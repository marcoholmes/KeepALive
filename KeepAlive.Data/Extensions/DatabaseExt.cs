using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace KeepAlive.Data.Extensions
{
    public static class DatabaseExt
    {
        public static TResult ExecuteDbCommand<TResult>(this Database database,
                                                        DbCommand command,
                                                        IRowMapper<TResult> mapper)
        {
            using (IDataReader reader = database.ExecuteReader(command))
            {
                if (reader.Read())
                {
                    return mapper.MapRow(reader);
                }
            }

            return default(TResult);
        }

        public static IEnumerable<TResult> ExecuteDbCommand<TResult>(this Database database,
                                                        DbCommand command,
                                                        IResultSetMapper<TResult> mapper)
        {
            IEnumerable<TResult> list = null;

            using (IDataReader reader = database.ExecuteReader(command))
            {
                list = mapper.MapSet(reader);
                return list;
            }
            
        }

        public static int ExecuteDbCommand(this Database database,
                                           DbCommand command)
        {
            int retval;

            retval = database.ExecuteNonQuery(command);

            return retval;
        }

        public static TResult ExecuteScalarAs<TResult>(this Database database,
                                               DbCommand command)
        {
            Object result = database.ExecuteScalar(command);

            if (result is null || Convert.IsDBNull(result))
            {
                return default(TResult);
            }

            return (TResult)(result);
        }

        public static IEnumerable<TResult> ExecuteListAs<TResult>(this Database database,
                                                                  DbCommand command)
        {
            var list = new List<TResult>();

            using (IDataReader reader = database.ExecuteReader(command))
            {
                while (reader.Read())
                {
                    list.Add(reader.GetValue<TResult>(0));
                }
            }

            return list;
        }
    }
}
