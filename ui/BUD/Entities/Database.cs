using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUD
{
    public sealed class Database
    {
        private static Database databaseInstance = null;
        private static readonly object lockObject = new object();

        // private static string serverAddress = "GAPAPAIO-WIN";
        // private static string databaseName = "BUD";
        // private static readonly string connectionString = "data source=" + serverAddress + ";initial catalog=" + databaseName + ";integrated security=True";

        // This is for SQL Server Authentication when using a username and password instead of Windows Authentication
        private static string serverAddress = "mednat.ieeta.pt\\SQLSERVER,8101";
        private static string databaseName = "p10g7";
        private static string databaseUsername = "p10g7";
        private static string databasePassword = "Cum1-te";
        private static string connectionString = "data source=" + serverAddress + ";initial catalog=" + databaseName + ";uid=" + databaseUsername + ";password=" + databasePassword;

        private Database() { }

        public static Database GetDatabase()
        {
            if (databaseInstance == null)
            {
                lock (lockObject)
                {
                    if (databaseInstance == null)
                    {
                        databaseInstance = new Database();
                    }
                }
            }
            return databaseInstance;
        }

        public String GetConnectionString()
        {
            return connectionString;
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
