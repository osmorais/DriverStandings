using DotNet6.DriverStandings.Domain.Model;
using DotNet6.DriverStandings.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet6.DriverStandings.Tests.Domain.Model
{
    public class LapTests
    {
        [Theory]
        [InlineData(-1, 1, 44.5)]
        public void Test1_Constructor_InvalidLapId(int lapId, int lapNumber, double averageSpeed)
        {
            //Arrange
            var time = new DateTime().AddMinutes(4);

            //Act
            var result = Assert.Throws<DomainValidationException>(() =>
            {
                new Lap(lapId, time, lapNumber, averageSpeed);
            });

            //Assert
            Assert.Equal("LapId invalido.", result.Message);
        }

        [Theory]
        [InlineData(1, -1, 44.5)]
        public void Test2_Constructor_InvalidLapNumber(int lapId, int lapNumber, double averageSpeed)
        {
            //Arrange
            var time = new DateTime().AddMinutes(4);

            //Act
            var result = Assert.Throws<DomainValidationException>(() =>
            {
                new Lap(lapId, time, lapNumber, averageSpeed);
            });

            //Assert
            Assert.Equal("Numero da volta invalida.", result.Message);
        }

        [Theory]
        [InlineData(1, 1, -1)]
        public void Test3_Constructor_InvalidAverageSpeed(int lapId, int lapNumber, double averageSpeed)
        {
            //Arrange
            var time = new DateTime().AddMinutes(4);

            //Act
            var result = Assert.Throws<DomainValidationException>(() =>
            {
                new Lap(lapId, time, lapNumber, averageSpeed);
            });

            //Assert
            Assert.Equal("Velocidade media da volta invalida.", result.Message);
        }
    }
}
