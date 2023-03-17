using Dapper;
using Microsoft.Data.SqlClient;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet6.DriverStandings.Infra.Data.Util
{
    public class DatabaseConnection
    {
        private readonly string connectionString = "";
        private readonly string serverName = "127.0.0.1";
        private readonly string port = "5432";
        private readonly string userName = "postgres";
        private readonly string password = "admin";
        private readonly string databaseName = "driverstandingsdatabase";

        public DatabaseConnection()
        {
            this.connectionString = String.Format("Server={0};Port={1};User Id={2};Password={3};Database={4};",
                                                serverName, port, userName, password, databaseName);
        }

        public NpgsqlConnection GetConnection()
        {
            try
            {
                return new NpgsqlConnection(connectionString);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
