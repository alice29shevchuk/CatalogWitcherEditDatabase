using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogWitcherEditDatabase
{
    internal class Singleton
    {
        private static Singleton instance;
        public static SqlConnection connection;
        private static readonly object _lock = new object();

        //public static string stringConnection = File.ReadAllText("connectionString.json");
        private Singleton()
        { }

        public SqlConnection SqlConnectionFunction()
        {
            return connection;
        }

        public static Singleton getInstance()
        {
            if (instance == null)
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new Singleton();
                        connection = new SqlConnection(GetConnectionStrings());
                    }
                }
            }
            return instance;
        }
        public static string GetConnectionStrings()
        {
            ConnectionStringSettingsCollection settings =
                ConfigurationManager.ConnectionStrings;

            if (settings != null)
            {
                foreach (ConnectionStringSettings cs in settings)
                {
                    return cs.ConnectionString;
                }
            }
            return "";
        }
    }
}
