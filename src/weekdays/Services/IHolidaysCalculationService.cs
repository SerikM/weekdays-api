using System;
using System.Collections.Generic;
using Weekdays.Models;

namespace Weekdays.Services
{
    public interface IHolidaysCalculationService
    {
        public int GetNumberOfMatchingHolidays(DateTime start, DateTime end, IEnumerable<Holiday> holidays);
    }
}
