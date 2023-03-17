using DotNet6.DriverStandings.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet6.DriverStandings.Application.Business.Interface
{
    public interface IRaceBusiness
    {
        public List<Race> ListRaces();
        public Race CreateRace(Race race);
        public Race GetRace(Race race);
    }
}
