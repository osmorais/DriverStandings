using Dapper;
using DotNet6.DriverStandings.Domain.DAO;
using DotNet6.DriverStandings.Domain.Model;
using Microsoft.Data.SqlClient;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet6.DriverStandings.Infra.Data.DAO
{
    public class RaceDAO : IRaceDAO
    {
        private static readonly string SELECT_RACES = "SELECT * FROM ListRaces();";
        private static readonly string SELECT_RACE_BY_ID = "SELECT * FROM GetRaceById({0});";

        public List<Race> ListRaces()
        {
            NpgsqlConnection pgsqlConnection = new Infra.Data.Util.DatabaseConnection().GetConnection();
            DataTable dt = new DataTable();

            try
            {
                using (pgsqlConnection)
                {
                    pgsqlConnection.Open();
                    string selectQuery = SELECT_RACES;

                    using (NpgsqlDataAdapter Adpt = new NpgsqlDataAdapter(selectQuery, pgsqlConnection))
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

            return Domain.Util.Utils.DataTableToList<Race>(dt);
        }

        public Race CreateRace(Race race)
        {
            throw new NotImplementedException();
        }

        public Race GetRaceById(Race race)
        {
            NpgsqlConnection pgsqlConnection = new Infra.Data.Util.DatabaseConnection().GetConnection();
            DataTable dt = new DataTable();

            try
            {
                using (pgsqlConnection)
                {
                    pgsqlConnection.Open();
                    string selectQuery = string.Format(SELECT_RACE_BY_ID, race.RaceId);

                    using (NpgsqlDataAdapter Adpt = new NpgsqlDataAdapter(selectQuery, pgsqlConnection))
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

            return Domain.Util.Utils.DataTableToObject<Race>(dt);
        }
    }
}
