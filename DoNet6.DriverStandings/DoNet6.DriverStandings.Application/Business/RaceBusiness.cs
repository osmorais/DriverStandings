using AutoMapper;
using DotNet6.DriverStandings.Application.Business.Interface;
using DotNet6.DriverStandings.Domain.DAO;
using DotNet6.DriverStandings.Domain.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DotNet6.DriverStandings.Application.Business
{
    public class RaceBusiness : IRaceBusiness
    {
        public RaceBusiness()
        {
        }

        public Race UploadRace(string fileString)
        {
            var records = new RecordLog().fileStringToRecordLogList(fileString);

            var orderedDrivers = records.GroupBy(driver => driver.DriverCode)
                                        .Select(record => new
                                        {
                                            DriverCode = record.FirstOrDefault().DriverCode,
                                            Name = record.FirstOrDefault().DriverName,
                                            TotalTime = new DateTime(record.Sum(r => r.LapTime.Ticks)),
                                            CompletedLaps = record.Count(),
                                        })
                                        .OrderByDescending(r => r.CompletedLaps)
                                        .ThenBy(r => r.TotalTime)
                                        .ToList();

            var drivers = new List<Driver>();
            foreach (var item in orderedDrivers)
            {
                var driver = new Driver(item.DriverCode, item.Name, item.TotalTime);

                driver.Laps = records.Where(d => d.DriverCode == driver.DriverCode)
                                        .Select(lap => new Lap
                                        {
                                            LapNumber = lap.LapNumber,
                                            LapTime = new DateTime(lap.LapTime.Ticks),
                                            AverageSpeed = lap.AverageSpeed
                                        }).ToList();

                drivers.Add(driver);

            }

            var race = new Race(drivers[0].Laps.Count(), drivers);

            new Infra.Data.DAO.RaceDAO().CreateRace(race);

            return race;
        }

        public Race GetRaceById(Race race)
        {
            race = new Infra.Data.DAO.RaceDAO().GetRaceById(race);

            race.Drivers = new Infra.Data.DAO.DriverDAO().GetDriversByRaceId(race.RaceId);

            foreach (Driver driver in race.Drivers)
            {
                driver.Laps = new Infra.Data.DAO.LapDAO().GetLapsByDriverId(driver.DriverId);
            }

            return race;
        }

        public List<Race> ListRaces()
        {
            var races = new Infra.Data.DAO.RaceDAO().ListRaces();

            return races;
        }
    }
}
