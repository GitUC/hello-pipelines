using System;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using WebApi.Controllers;
using Xunit;

namespace Tests
{
    public class WeatherForecastControllerTests
    {
        private Mock<ILogger<WeatherForecastController>> loggerStub = new Mock<ILogger<WeatherForecastController>>();
        private Mock<IConfiguration> configStub = new Mock<IConfiguration>();

        [Fact]
        public void Get_NoArguments_ReturnsDefaultForecastDays()
        {
            var controller = new WeatherForecastController(loggerStub.Object, configStub.Object);
            var expectedDays = 7;

            var forecasts = controller.Get();

            Assert.NotNull(forecasts);
            Assert.Equal(expectedDays, forecasts.Count());
        }
    }
}
