using AutoMapper;
using DotNet6.DriverStandings.Application.Business.Interface;
using DotNet6.DriverStandings.Domain.DAO;
using DotNet6.DriverStandings.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet6.DriverStandings.Application.Business
{
    public class RaceBusiness : IRaceBusiness
    {
        public RaceBusiness()
        {
        }

        public Race CreateRace(Race race)
        {
            return new Infra.Data.DAO.RaceDAO().CreateRace(race);
        }

        public Race GetRaceById(Race race)
        {
            race = new Infra.Data.DAO.RaceDAO().GetRaceById(race);

            race.Drivers = new Infra.Data.DAO.DriverDAO().GetDriversByRaceId(race.RaceId);

            foreach (Driver driver in race.Drivers)
            {
                driver.Laps = new Infra.Data.DAO.LapDAO().GetLapsByDriverId(race.RaceId);
            }

            return race;
        }

        public List<Race> ListRaces()
        {
            var races = new Infra.Data.DAO.RaceDAO().ListRaces();

            return races;
        }
    }
}
