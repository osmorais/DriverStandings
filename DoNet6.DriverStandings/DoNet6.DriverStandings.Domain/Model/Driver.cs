using DotNet6.DriverStandings.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DotNet6.DriverStandings.Domain.Model
{
    public class Driver
    {
        public int DriverId { get; set; }
        public string DriverCode { get; set; }
        public string Name { get; set; }
        public DateTime TotalTime { get; set; }
        public List<Lap> Laps { get; set; }

        public Driver() { }

        public Driver(int driverId, string driverCode, string name, DateTime totalTime, List<Lap> laps)
        {
            this.DriverId = driverId;
            this.DriverCode = driverCode;
            this.Name = name;
            this.TotalTime = totalTime;
            this.Laps = laps;

            this.Validation();
        }

        public Driver(string driverCode, string name, DateTime totalTime)
        {
            this.DriverCode = driverCode;
            this.Name = name;
            this.TotalTime = totalTime;

            this.Validation();
        }

        public void Validation()
        {
            DomainValidationException.When(this.DriverId < 0, "DriverId invalido.");
            DomainValidationException.When(string.IsNullOrEmpty(this.DriverCode), "Codigo do piloto vazio.");
            DomainValidationException.When(Domain.Util.Utils.hasSpecialCharacters(this.Name), "Nome do piloto contem caracteres especiais.");
            DomainValidationException.When(Domain.Util.Utils.hasNumber(this.Name), "Nome do piloto contem numero.");
            DomainValidationException.When(this.Laps.Count() <= 0, "O piloto nao tem voltas.");
        }
    }
}
