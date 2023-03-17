using Dapper;
using DotNet6.DriverStandings.Domain.DAO;
using DotNet6.DriverStandings.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet6.DriverStandings.Infra.Data.DAO
{
    public class RaceDAO : IRaceDAO
    {
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
            return new Connection.DatabaseConnection().ExecuteQueryList<Race>("ListRaces", null);
        }
    }
}
