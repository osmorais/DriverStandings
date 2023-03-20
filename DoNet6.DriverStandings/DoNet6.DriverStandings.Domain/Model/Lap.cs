using DotNet6.DriverStandings.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet6.DriverStandings.Domain.Model
{
    public class Lap
    {
        public int LapId { get; set; }
        public int LapNumber { get; set; }
        public DateTime LapTime { get; set; }
        public double AverageSpeed { get; set; }

        public Lap() { }

        public Lap(int Lapid, DateTime time, int lapNumber, double averageSpeed)
        {
            LapId = Lapid;
            LapTime = time;
            LapNumber = lapNumber;
            AverageSpeed = averageSpeed;

            this.Validation();
        }
        public Lap(DateTime time, int lapNumber, double averageSpeed)
        {
            LapTime = time;
            LapNumber = lapNumber;
            AverageSpeed = averageSpeed;

            this.Validation();
        }

        public void Validation()
        {
            DomainValidationException.When(this.LapId < 0, "LapId invalido.");
            DomainValidationException.When(this.LapNumber < 0, "Numero da volta invalida.");
            DomainValidationException.When(this.AverageSpeed < 0, "Velocidade media da volta invalida.");
        }
    }
}
