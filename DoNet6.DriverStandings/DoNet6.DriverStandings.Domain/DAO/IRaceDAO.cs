using DotNet6.DriverStandings.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet6.DriverStandings.Domain.DAO
{
    public interface IRaceDAO
    {
        public Race CreateRace(Race race);
        public List<Race> ListRaces();
        public Race GetRace(Race race);
    }
}
