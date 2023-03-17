using DotNet6.DriverStandings.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet6.DriverStandings.Application.DTO
{
    public class RaceDTO
    {
        public int RaceId { get; set; }
        public int NumberOfLaps { get; set; }
        public List<DriverDTO> Drivers { get; set; }
    }
}
