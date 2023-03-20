using DotNet6.DriverStandings.Domain.Model;
using DotNet6.DriverStandings.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet6.DriverStandings.Tests.Domain.Model
{
    public class DriverTests
    {
        [Theory]
        [InlineData(-1, "000", "Teste")]
        public void Test1_Constructor_InvalidDriverId(int driverId, string driverCode, string name)
        {
            //Arrange
            var time = new DateTime().AddMinutes(4);
            var laps = new List<Lap>();

            //Act
            var result = Assert.Throws<DomainValidationException>(() =>
            {
                new Driver(driverId, driverCode, name, time, laps);
            });

            //Assert
            Assert.Equal("DriverId invalido.", result.Message);
        }

        [Theory]
        [InlineData(1, "", "Teste")]
        public void Test2_Constructor_InvalidDriverCode(int driverId, string driverCode, string name)
        {
            //Arrange
            var time = new DateTime().AddMinutes(4);
            var laps = new List<Lap>();

            //Act
            var result = Assert.Throws<DomainValidationException>(() =>
            {
                new Driver(driverId, driverCode, name, time, laps);
            });

            //Assert
            Assert.Equal("Codigo do piloto vazio.", result.Message);
        }

        [Theory]
        [InlineData(1, "000", "Teste@@teste")]
        public void Test3_Constructor_InvalidNameSpecialCharacters(int driverId, string driverCode, string name)
        {
            //Arrange
            var time = new DateTime().AddMinutes(4);
            var laps = new List<Lap>();

            //Act
            var result = Assert.Throws<DomainValidationException>(() =>
            {
                new Driver(driverId, driverCode, name, time, laps);
            });

            //Assert
            Assert.Equal("Nome do piloto contem caracteres especiais.", result.Message);
        }

        [Theory]
        [InlineData(1, "000", "Teste11teste")]
        public void Test3_Constructor_InvalidNameNumber(int driverId, string driverCode, string name)
        {
            //Arrange
            var time = new DateTime().AddMinutes(4);
            var laps = new List<Lap>();

            //Act
            var result = Assert.Throws<DomainValidationException>(() =>
            {
                new Driver(driverId, driverCode, name, time, laps);
            });

            //Assert
            Assert.Equal("Nome do piloto contem numero.", result.Message);
        }

        [Theory]
        [InlineData(1, "000", "Teste")]
        public void Test3_Constructor_InvalidLaps(int driverId, string driverCode, string name)
        {
            //Arrange
            var time = new DateTime().AddMinutes(4);
            var laps = new List<Lap>();

            //Act
            var result = Assert.Throws<DomainValidationException>(() =>
            {
                new Driver(driverId, driverCode, name, time, laps);
            });

            //Assert
            Assert.Equal("O piloto nao tem voltas.", result.Message);
        }
    }
}
