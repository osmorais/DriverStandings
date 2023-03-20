using DotNet6.DriverStandings.Domain.Model;
using DotNet6.DriverStandings.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet6.DriverStandings.Tests.Domain.Model
{
    public class RaceTests
    {
        [Theory]
        [InlineData(-1, 4)]
        public void Test1_Constructor_InvalidRaceId(int raceId, int numberOfLaps)
        {
            //Arrange
            var drivers = new List<Driver>();

            //Act
            var result = Assert.Throws<DomainValidationException>(() =>
            {
                new Race(raceId, numberOfLaps, drivers);
            });

            //Assert
            Assert.Equal("RaceId invalido.", result.Message);
        }

        [Theory]
        [InlineData(1, -1)]
        public void Test2_Constructor_InvalidNumberOfLaps(int raceId, int numberOfLaps)
        {
            //Arrange
            var drivers = new List<Driver>();

            //Act
            var result = Assert.Throws<DomainValidationException>(() =>
            {
                new Race(raceId, numberOfLaps, drivers);
            });

            //Assert
            Assert.Equal("Numero de voltas invalido.", result.Message);
        }

        [Theory]
        [InlineData(1, 1)]
        public void Test3_Constructor_RaceWithoutDrivers(int raceId, int numberOfLaps)
        {
            //Arrange
            var drivers = new List<Driver>();

            //Act
            var result = Assert.Throws<DomainValidationException>(() =>
            {
                new Race(raceId, numberOfLaps, drivers);
            });

            //Assert
            Assert.Equal("A corrida nao tem pilotos.", result.Message);
        }
    }
}
