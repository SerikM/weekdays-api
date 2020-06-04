using Xunit;
using Moq;
using Weekdays.Services;
using Weekdays.Repositories;
using Weekdays.Models;
using System;
using System.Threading.Tasks;

namespace Weekdays.Tests
{
    public class CalculationervicesTest
    {
        [Fact]
        public void TestStartSatEndSunday()
        {
            var dataMock = new Mock<IDBDataService<IData>>();
            var holidays = MockData.GetMockHolidays();
            dataMock.Setup(p => p.GetDatedItems<Holiday>(It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(Task.FromResult(holidays));
            var service = new CalculationService(dataMock.Object);
            var result = (int)service.GetWeekdays("01/02/2020", "01/03/2020").Result;
            Assert.Equal(20, result);
        }


        [Fact]
        public void TestStartSundayEndSunday()
        {
            var dataMock = new Mock<IDBDataService<IData>>();
            var holidays = MockData.GetMockHolidays();
            dataMock.Setup(p => p.GetDatedItems<Holiday>(It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(Task.FromResult(holidays));
            var service = new CalculationService(dataMock.Object);
            var result = (int)service.GetWeekdays("02/02/2020", "01/03/2020").Result;
            Assert.Equal(20, result);
        }


        [Fact]
        public void TestStartMondayEndSunday()
        {
            var dataMock = new Mock<IDBDataService<IData>>();
            var holidays = MockData.GetMockHolidays();
            dataMock.Setup(p => p.GetDatedItems<Holiday>(It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(Task.FromResult(holidays));
            var service = new CalculationService(dataMock.Object);
            var result = (int)service.GetWeekdays("03/02/2020", "01/03/2020").Result;
            Assert.Equal(19, result);
        }

        [Fact]
        public void TestStartAfterEnd()
        {
            var dataMock = new Mock<IDBDataService<IData>>();
            var holidays = MockData.GetMockHolidays();
            dataMock.Setup(p => p.GetDatedItems<Holiday>(It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(Task.FromResult(holidays));
            var service = new CalculationService(dataMock.Object);
            var result = (int)service.GetWeekdays("03/04/2020", "01/03/2020").Result;
            Assert.Equal(-1, result);
        }

        [Fact]
        public void TestStartSameAsEnd()
        {
            var dataMock = new Mock<IDBDataService<IData>>();
            var holidays = MockData.GetMockHolidays();
            dataMock.Setup(p => p.GetDatedItems<Holiday>(It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(Task.FromResult(holidays));
            var service = new CalculationService(dataMock.Object);
            var result = (int)service.GetWeekdays("03/04/2020", "03/04/2020").Result;
            Assert.Equal(-1, result);
        }

        [Fact]
        public void TestEndOneDayAfterStart()
        {
            var dataMock = new Mock<IDBDataService<IData>>();
            var holidays = MockData.GetMockHolidays();
            dataMock.Setup(p => p.GetDatedItems<Holiday>(It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(Task.FromResult(holidays));
            var service = new CalculationService(dataMock.Object);
            var result = (int)service.GetWeekdays("03/04/2020", "04/04/2020").Result;
            Assert.Equal(0, result);
        }

        [Fact]
        public void TestEndTwoDaysAfterStart()
        {
            var dataMock = new Mock<IDBDataService<IData>>();
            var holidays = MockData.GetMockHolidays();
            dataMock.Setup(p => p.GetDatedItems<Holiday>(It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(Task.FromResult(holidays));
            var service = new CalculationService(dataMock.Object);
            var result = (int)service.GetWeekdays("02/04/2020", "04/04/2020").Result;
            Assert.Equal(1, result);
        }

        [Fact]
        public void TestEndMondayStartFridayWith1PublicHoliday()
        {
            var dataMock = new Mock<IDBDataService<IData>>();
            var holidays = MockData.GetMockHolidays();
            dataMock.Setup(p => p.GetDatedItems<Holiday>(It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(Task.FromResult(holidays));
            var service = new CalculationService(dataMock.Object);
            var result = (int)service.GetWeekdays("08/06/2020", "12/06/2020").Result;
            Assert.Equal(2, result);
        }

        [Fact]
        public void TestStartFridayEndMonday()
        {
            var dataMock = new Mock<IDBDataService<IData>>();
            var holidays = MockData.GetMockHolidays();
            dataMock.Setup(p => p.GetDatedItems<Holiday>(It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(Task.FromResult(holidays));
            var service = new CalculationService(dataMock.Object);
            var result = (int)service.GetWeekdays("12/06/2020", "15/06/2020").Result;
            Assert.Equal(0, result);
        }

        [Fact]
        public void TestVeryLongTimeSpan()
        {
            var dataMock = new Mock<IDBDataService<IData>>();
            var holidays = MockData.GetMockHolidays();
            dataMock.Setup(p => p.GetDatedItems<Holiday>(It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(Task.FromResult(holidays));
            var service = new CalculationService(dataMock.Object);
            var result = service.GetWeekdays("12/06/2000", "15/06/2020").Result;
            Assert.Equal(5214, result);
        }
    }
}
