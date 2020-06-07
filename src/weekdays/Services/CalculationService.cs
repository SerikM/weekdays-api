using Weekdays.Models;
using System;
using System.Linq;
using System.Globalization;
using System.Threading.Tasks;

namespace Weekdays.Services
{
    public class CalculationService : ICalculationService
    {
        private readonly IDBDataService<IData> _dataService;
        private readonly IHolidaysCalculationService _holCalcService;

        public CalculationService(IDBDataService<IData> dataService, IHolidaysCalculationService holCalcService)
        {
            _holCalcService = holCalcService;
            _dataService = dataService;
        }

        public async Task<int> GetWeekdays(string from, string to)
        {
            if (!IsParsable(from, to, out DateTime start, out DateTime end)) return -1;
            if (!IsValid(start, end)) return -1;

            double businessDaysCount = GetBusinessDayCount(start, end);
            var holidays = await _dataService.GetDatedItems<Holiday>(start, end);

            if (holidays == null || !holidays.Any()) return -1;
            var matches = _holCalcService.GetNumberOfMatchingHolidays(start, end, holidays);

            businessDaysCount -= matches;
            return Convert.ToInt16(businessDaysCount);
        }

        private double GetBusinessDayCount(DateTime start, DateTime end)
        {
            end = end.AddDays(-1);
            start = start.AddDays(1);

            double businessDaysCount = 1 + (((end - start).Days * 5) - ((start.DayOfWeek - end.DayOfWeek) * 2)) / 7;
            if (end.DayOfWeek == DayOfWeek.Saturday) businessDaysCount--;
            if (start.DayOfWeek == DayOfWeek.Sunday) businessDaysCount--;

            return businessDaysCount;
        }
        
        private bool IsParsable(string from, string to, out DateTime start, out DateTime end)
        {
            end = default;
            var cult = CultureInfo.InvariantCulture;
            string format = "dd/MM/yyyy";
            string format2 = "d/M/yyyy";

            if (DateTime.TryParseExact(from, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out start) && DateTime.TryParseExact(to, format, cult, DateTimeStyles.None, out end)) return true;

            return (DateTime.TryParseExact(from, format2, CultureInfo.InvariantCulture, DateTimeStyles.None, out start) && DateTime.TryParseExact(to, format2, cult, DateTimeStyles.None, out end));
        }

        private bool IsValid(DateTime start, DateTime end)
        {
            if (start == end) return false;
            return end >= start;
        }
    }
}
