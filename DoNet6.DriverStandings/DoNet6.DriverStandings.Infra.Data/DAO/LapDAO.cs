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
    public class LapDAO : ILapDAO
    {
        private static readonly string SELECT_LAPS_BY_DRIVER_ID = "SELECT * FROM GetLapsByDriverId({0});";
        private static readonly string SELECT_LAP_BY_ID = "SELECT * FROM GetLapById({0});";

        public Lap CreateLap(Lap lap)
        {
            throw new NotImplementedException();
        }

        public Lap GetLap(Lap lap)
        {
            NpgsqlConnection pgsqlConnection = new Infra.Data.Util.DatabaseConnection().GetConnection();
            DataTable dt = new DataTable();

            try
            {
                using (pgsqlConnection)
                {
                    pgsqlConnection.Open();
                    string selectQuery = string.Format(SELECT_LAP_BY_ID, lap.LapId);

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

            return new Infra.Data.Util.Utils().DataTableToObject<Lap>(dt);
        }

        public List<Lap> GetLapsByDriverId(int driverId)
        {
            NpgsqlConnection pgsqlConnection = new Infra.Data.Util.DatabaseConnection().GetConnection();
            DataTable dt = new DataTable();

            try
            {
                using (pgsqlConnection)
                {
                    pgsqlConnection.Open();
                    string selectQuery = string.Format(SELECT_LAPS_BY_DRIVER_ID, driverId);

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

            return new Infra.Data.Util.Utils().DataTableToList<Lap>(dt);
        }
    }
}
