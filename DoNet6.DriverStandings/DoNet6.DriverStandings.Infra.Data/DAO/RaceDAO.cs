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
using static System.Net.Mime.MediaTypeNames;

namespace DotNet6.DriverStandings.Infra.Data.DAO
{
    public class RaceDAO : IRaceDAO
    {
        private static readonly string SELECT_RACES = "SELECT * FROM ListRaces();";
        private static readonly string SELECT_RACE_BY_ID = "SELECT * FROM GetRaceById({0});";
        private static readonly string INSERT_RACE = "INSERT INTO RACE (NUMBEROFLAPS) VALUES (:numberoflaps) {0};";
        private static readonly string DELETE_RACE = "DELETE FROM RACE WHERE RACEID = :raceid;";

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

        public void CreateRace(Race race)
        {
            NpgsqlConnection pgsqlConnection = new Infra.Data.Util.DatabaseConnection().GetConnection();
            try
            {
                using (pgsqlConnection)
                {                
                    pgsqlConnection.Open();

                    string insertQuery = string.Format(INSERT_RACE, "RETURNING RaceId");

                    using (NpgsqlCommand pgsqlcommand = new NpgsqlCommand(insertQuery, pgsqlConnection))
                    {
                        pgsqlcommand.Parameters.Add(new NpgsqlParameter("numberoflaps", race.NumberOfLaps));
                        race.RaceId = (int)pgsqlcommand.ExecuteScalar();
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

                foreach(var driver in race.Drivers)
                {
                    new DriverDAO().CreateDriver(driver, race.RaceId);
                }
            }
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

        public void DeleteRaceById(Race race)
        {
            NpgsqlConnection pgsqlConnection = new Infra.Data.Util.DatabaseConnection().GetConnection();
            try
            {
                using (pgsqlConnection)
                {
                    pgsqlConnection.Open();

                    string insertQuery = string.Format(DELETE_RACE);

                    using (NpgsqlCommand pgsqlcommand = new NpgsqlCommand(insertQuery, pgsqlConnection))
                    {
                        pgsqlcommand.Parameters.Add(new NpgsqlParameter("raceid", race.RaceId));
                        pgsqlcommand.ExecuteNonQuery();
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
        }
    }
}
