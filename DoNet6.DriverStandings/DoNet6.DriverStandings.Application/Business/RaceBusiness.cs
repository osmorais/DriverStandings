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

        public Race GetRace(Race race)
        {
            return new Infra.Data.DAO.RaceDAO().GetRace(race);
        }

        public List<Race> ListRaces()
        {
            return new Infra.Data.DAO.RaceDAO().ListRaces();
        }
    }
}
