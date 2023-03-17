using Dapper;
using DotNet6.DriverStandings.Domain.DAO;
using DotNet6.DriverStandings.Domain.Model;
using Microsoft.Data.SqlClient;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet6.DriverStandings.Infra.Data.DAO
{
    public class RaceDAO : IRaceDAO
    {
        private readonly string connectionString = "Host=127.0.0.1;Username=postgres;Password=admin;Database=driverstandingsdatabase";
        public Race CreateRace(Race race)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("RaceId", race.RaceId);
            parameters.Add("RaceId", race.RaceId);

            return new Connection.DatabaseConnection().ExecuteQuery<Race>("CreateRace", parameters);
        }

        public Race GetRace(Race race)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("RaceId", race.RaceId);

            return new Connection.DatabaseConnection().ExecuteQuery<Race>("GetRace", parameters);
        }

        public List<Race> ListRaces()
        {
            NpgsqlConnection pgsqlConnection = new NpgsqlConnection(connectionString);
            DataTable dt = new DataTable();

            try
            {
                using (pgsqlConnection)
                {
                    pgsqlConnection.Open();
                    string cmdSeleciona = "SELECT * FROM ListRaces();";

                    using (NpgsqlDataAdapter Adpt = new NpgsqlDataAdapter(cmdSeleciona, pgsqlConnection))
                    {
                        Adpt.Fill(dt);
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                pgsqlConnection.Close();
            }

            return ConverterParaLista<Race>(dt);
        }

        public static List<T> ConverterParaLista<T>(DataTable dt)
        {
            var columnNames = dt.Columns.Cast<DataColumn>().Select(c => c.ColumnName.ToLower()).ToList();
            var properties = typeof(T).GetProperties();
            return dt.AsEnumerable().Select(row => {
                var objT = Activator.CreateInstance<T>();
                foreach (var pro in properties)
                {
                    if (columnNames.Contains(pro.Name.ToLower()))
                    {
                        try
                        {
                            pro.SetValue(objT, row[pro.Name]);
                        }
                        catch (Exception)
                        { }
                    }
                }
                return objT;
            }).ToList();
        }
    }
}
