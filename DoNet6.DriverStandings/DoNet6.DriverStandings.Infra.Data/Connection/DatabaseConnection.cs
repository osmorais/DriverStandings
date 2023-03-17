using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet6.DriverStandings.Infra.Data.Connection
{
    public class DatabaseConnection
    {
        private readonly string connectionString = "Server=127.0.0.1;Port=5432;Database=DriverStandings;User Id=postgres;Password=admin;";
        //private readonly string connectionString = "Server=localhost\\SQLEXPRESS;Database=DriverStandings;Trusted_Connection=True;TrustServerCertificate=True;";

        public List<T> ExecuteQueryList<T>(string procedure, DynamicParameters parameters)
        {
            var stopWatch = Stopwatch.StartNew();
            int commandTimeoutSeconds = 180;

            try
            {
                var command = new Dapper.CommandDefinition(procedure, parameters, commandTimeout: commandTimeoutSeconds, commandType: CommandType.StoredProcedure);
                var ret = Dapper.SqlMapper.Query<T>(new SqlConnection(connectionString), command).ToList();

                stopWatch.Stop();

                return ret;
            }
            catch (Exception ex)
            {
                stopWatch.Stop();
                return null;
            }
        }

        public T ExecuteQuery<T>(string procedure, DynamicParameters parameters)
        {
            var stopWatch = Stopwatch.StartNew();
            int commandTimeoutSeconds = 180;

            try
            {
                var command = new Dapper.CommandDefinition(procedure, parameters, commandTimeout: commandTimeoutSeconds, commandType: CommandType.StoredProcedure);
                var ret = Dapper.SqlMapper.Query<T>(new SqlConnection(connectionString), command).FirstOrDefault();

                stopWatch.Stop();

                return ret;
            }
            catch (Exception ex)
            {
                stopWatch.Stop();
                throw new Exception(ex.Message);
            }
        }
    }
}
