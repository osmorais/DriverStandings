using DotNet6.DriverStandings.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet6.DriverStandings.Domain.Model
{
    public class Race
    {
        public int RaceId { get; set; }
        public int NumberOfLaps { get; set; }
        public List<Driver> Drivers { get; set; }

        public Race() { }

        public Race(int raceId, int numberOfLaps, List<Driver> drivers)
        {
            RaceId = raceId;
            NumberOfLaps = numberOfLaps;
            Drivers = drivers;

            this.Validation();
        }

        public Race(int numberOfLaps, List<Driver> drivers)
        {
            NumberOfLaps = numberOfLaps;
            Drivers = drivers;

            this.Validation();
        }

        public void Validation()
        {
            DomainValidationException.When(this.RaceId < 0, "RaceId invalido.");
            DomainValidationException.When(this.NumberOfLaps < 0, "Numero de voltas invalido.");
            DomainValidationException.When(this.Drivers.Count() <= 0, "A corrida nao tem pilotos.");
        }
    }
}
