﻿using DotNet6.DriverStandings.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet6.DriverStandings.Domain.DAO
{
    public interface IDriverDAO
    {
        public Driver CreateDriver(Driver driver);
        public Driver GetDriver(Driver driver);
        public List<Driver> ListDrivers();
    }
}
