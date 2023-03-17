using DotNet6.DriverStandings.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet6.DriverStandings.Application.DTO
{
    public class DriverDTO
    {
        public int DriverId { get; set; }
        public string DriverCode { get; set; }
        public string Name { get; set; }
        public DateTime TotalTime { get; set; }
        public List<Lap> Laps { get; set; }
    }
}
