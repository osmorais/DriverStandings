using AutoMapper;
using DotNet6.DriverStandings.Application.DTO;
using DotNet6.DriverStandings.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet6.DriverStandings.Application.Mappings
{
    public class DTOToDomainMap : Profile
    {
        public DTOToDomainMap() 
        {
            CreateMap<RaceDTO, Race>();
            CreateMap<DriverDTO, Driver>();
            CreateMap<LapDTO, Lap>();
        }
    }
}
