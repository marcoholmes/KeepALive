using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace KeepAlive.Data.DB
{
    public class DbFactory
    {
        private static DatabaseProviderFactory factory;

        static DbFactory()
        {
            factory = new DatabaseProviderFactory();
        }

        public static Database CreateDatabase()
        {
            return factory.CreateDefault();
        }

        public static Database CreateDatabase(string name)
        {
            return factory.Create(name);
        }
    }
}
