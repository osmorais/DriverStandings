﻿using DotNet6.DriverStandings.Domain.Validations;
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
        public DateTime Time { get; set; }
        public double AverageSpeed { get; set; }

        public Lap() { }

        public Lap(int Lapid, DateTime time, double averageSpeed)
        {
            LapId = Lapid;
            Time = time;
            AverageSpeed = averageSpeed;
        }


        public void Validation()
        {
            DomainValidationException.When(this.LapId < 0, "LapId invalido.");
            DomainValidationException.When(this.AverageSpeed < 0, "Velocidade media da volta invalida.");
        }
    }
}
