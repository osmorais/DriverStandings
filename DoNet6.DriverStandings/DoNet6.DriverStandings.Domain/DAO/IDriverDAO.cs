using DotNet6.DriverStandings.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet6.DriverStandings.Domain.DAO
{
    public interface IDriverDAO
    {
        public void CreateDriver(Driver driver, int raceid);
        public Driver GetDriver(Driver driver);
        public List<Driver> ListDrivers();
        public List<Driver> GetDriversByRaceId(int RaceId);
        public void DeleteDriversByRaceId(int RaceId);
    }
}
