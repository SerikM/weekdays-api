using Xunit;
using Moq;
using Weekdays.Services;
using Weekdays.Controllers;
using Weekdays.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Weekdays.Tests
{
    public class DefaultControllerTests
    {
        [Fact]
        public void TestGetWeekdays()
        {
            var serviceMock = new Mock<ICalculationService>();
            serviceMock.Setup(p => p.GetWeekdays(It.IsAny<string>(), It.IsAny<string>())).Returns(() => new Task<int>(null));
            var mockController = new DefaultController(serviceMock.Object);
            var response = mockController.GetWeekdays("","").Result as BadRequestObjectResult;
            Assert.NotNull(response);
            Assert.Equal("failed to process request", response.Value);
        }

        [Fact]
        public void TestGetWeekdaysSuccess()
        {
            var serviceMock = new Mock<ICalculationService>();
            serviceMock.Setup(p => p.GetWeekdays(It.IsAny<string>(), It.IsAny<string>())).Returns(() => Task.FromResult(20));
            var mockController = new DefaultController(serviceMock.Object);
            var response = mockController.GetWeekdays("01/02/2020", "01/03/2020").Result as OkObjectResult;
            Assert.NotNull(response);
            Assert.Equal("20", response.Value);
        }
    }
}
