using DotNet6.DriverStandings.Domain.DAO;
using DotNet6.DriverStandings.Domain.Model;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet6.DriverStandings.Infra.Data.DAO
{
    public class DriverDAO : IDriverDAO
    {
        private static readonly string SELECT_DRIVERS = "SELECT * FROM ListDrivers();";
        private static readonly string SELECT_DRIVER_BY_ID = "SELECT * FROM GetDriverById({0});";
        private static readonly string SELECT_DRIVERS_BY_RACEID = "SELECT * FROM GetDriversByRaceId({0});";
        private static readonly string INSERT_DRIVER = "INSERT INTO DRIVER (DRIVERCODE, NAME, TOTALTIME, RACEID) VALUES (:drivercode, :name, :totaltime, :raceid) {0};";
        public void CreateDriver(Driver driver, int raceid)
        {
            NpgsqlConnection pgsqlConnection = new Infra.Data.Util.DatabaseConnection().GetConnection();
            try
            {
                using (pgsqlConnection)
                {             
                    pgsqlConnection.Open();

                    string insertQuery = string.Format(INSERT_DRIVER, "RETURNING DriverId");

                    using (NpgsqlCommand pgsqlcommand = new NpgsqlCommand(insertQuery, pgsqlConnection))
                    {
                        pgsqlcommand.Parameters.Add(new NpgsqlParameter("drivercode", driver.DriverCode));
                        pgsqlcommand.Parameters.Add(new NpgsqlParameter("name", driver.Name));
                        pgsqlcommand.Parameters.Add(new NpgsqlParameter("totaltime", driver.TotalTime));
                        pgsqlcommand.Parameters.Add(new NpgsqlParameter("raceid", raceid));
                        driver.DriverId = (int)pgsqlcommand.ExecuteScalar();
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

                foreach (var lap in driver.Laps)
                {
                    new LapDAO().CreateLap(lap, driver.DriverId);
                }
            }
        }

        public Driver GetDriver(Driver driver)
        {
            NpgsqlConnection pgsqlConnection = new Infra.Data.Util.DatabaseConnection().GetConnection();
            DataTable dt = new DataTable();

            try
            {
                using (pgsqlConnection)
                {
                    pgsqlConnection.Open();
                    string selectQuery = string.Format(SELECT_DRIVER_BY_ID, driver.DriverId);

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

            return Domain.Util.Utils.DataTableToObject<Driver>(dt);
        }

        public List<Driver> ListDrivers()
        {
            NpgsqlConnection pgsqlConnection = new Infra.Data.Util.DatabaseConnection().GetConnection();
            DataTable dt = new DataTable();

            try
            {
                using (pgsqlConnection)
                {
                    pgsqlConnection.Open();
                    string selectQuery = SELECT_DRIVERS;

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

            return Domain.Util.Utils.DataTableToListDriver(dt);
        }

        public List<Driver> GetDriversByRaceId(int raceId)
        {
            NpgsqlConnection pgsqlConnection = new Infra.Data.Util.DatabaseConnection().GetConnection();
            DataTable dt = new DataTable();

            try
            {
                using (pgsqlConnection)
                {
                    pgsqlConnection.Open();
                    string selectQuery = string.Format(SELECT_DRIVERS_BY_RACEID, raceId);

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

            return Domain.Util.Utils.DataTableToListDriver(dt);
        }
    }
}
