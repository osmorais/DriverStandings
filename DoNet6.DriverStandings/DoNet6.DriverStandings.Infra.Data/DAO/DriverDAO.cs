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
        public Driver CreateDriver(Driver driver)
        {
            throw new NotImplementedException();
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

            return new Infra.Data.Util.Utils().DataTableToObject<Driver>(dt);
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

            return new Infra.Data.Util.Utils().DataTableToList<Driver>(dt);
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

            return new Infra.Data.Util.Utils().DataTableToList<Driver>(dt);
        }
    }
}
