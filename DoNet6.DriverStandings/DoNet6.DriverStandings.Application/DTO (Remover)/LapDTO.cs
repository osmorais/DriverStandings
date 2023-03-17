using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet6.DriverStandings.Application.DTO
{
    public class LapDTO
    {
        public int LapId { get; set; }
        public DateTime Time { get; set; }
        public double AverageSpeed { get; set; }
    }
}
