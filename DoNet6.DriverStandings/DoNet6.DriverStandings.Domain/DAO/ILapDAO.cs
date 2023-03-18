using DotNet6.DriverStandings.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet6.DriverStandings.Domain.DAO
{
    public interface ILapDAO
    {
        public void CreateLap(Lap lap, int driverid);
        public Lap GetLap(Lap lap);
        public List<Lap> GetLapsByDriverId(int driverId);
    }
}
