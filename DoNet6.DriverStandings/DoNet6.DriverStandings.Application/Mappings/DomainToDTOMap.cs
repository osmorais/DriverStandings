﻿using AutoMapper;
using DotNet6.DriverStandings.Application.DTO;
using DotNet6.DriverStandings.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace DotNet6.DriverStandings.Application.Mappings
{
    public class DomainToDTOMap : Profile 
    {
        public DomainToDTOMap() 
        {
            CreateMap<Race, RaceDTO>();
            CreateMap<Driver, DriverDTO>();
            CreateMap<Lap, LapDTO>();
        }
    }
}
