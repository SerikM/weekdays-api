using System;
using System.Collections.Generic;
using System.Linq;
using Weekdays.Models;

namespace Weekdays.Services
{
    public class HolidaysCalculationService : IHolidaysCalculationService
    {
        public int GetNumberOfMatchingHolidays(DateTime start, DateTime end, IEnumerable<Holiday> holidays)
        {
            var numToSubtract = 0;
            if (start.Year == end.Year)
            {
                numToSubtract = HandleSingleYear(start, end, holidays);
            }
            else if (end.Year - start.Year == 1)
            {
                numToSubtract = HandleMultipleJointYears(start, end, holidays);
            }
            else
            {
                numToSubtract = HandleYears(start, end, holidays);
            }

            return numToSubtract;
        }

        public int HandleYears(DateTime start, DateTime end, IEnumerable<Holiday> holidays)
        {
            var hols = holidays as Holiday[] ?? holidays.ToArray();
            var sum1 = HandleSingleYear(start, new DateTime(start.Year, 12, 31), hols);
            var sum2 = HandleMultipleYears(start, end, hols);
            var sum3 = HandleSingleYear(new DateTime(end.Year, 1, 1), end, hols, true);

            return sum1 + sum2 + sum3;
        }

        private int HandleMultipleYears(DateTime start, DateTime end, Holiday[] hols)
        {
            var total = 0;
            for (var i = start.Year + 1; i < end.Year; i++)
            {
                total += HandleSingleYear(new DateTime(i, 1, 1), new DateTime(i, 12, 31), hols, true);
            }
            return total;
        }

        public int HandleMultipleJointYears(DateTime start, DateTime end, IEnumerable<Holiday> holidays)
        {
            var hols = holidays as Holiday[] ?? holidays.ToArray();
            var sum1 = HandleSingleYear(start, new DateTime(start.Year, 12, 31), hols);
            var sum2 = HandleSingleYear(new DateTime(end.Year, 1, 1), end, hols, true);
            return sum1 + sum2;
        }

        private int HandleSingleYear(DateTime start, DateTime end, IEnumerable<Holiday> holidays, bool include = false)
        {
            int numToSubtract = 0;
            foreach (var hol in holidays)
            {
                switch (hol.Type)
                {
                    case HolidayType.One:
                        {
                            if (IsTypeOneMatch(hol, start, end))
                            {
                                numToSubtract++;
                            }
                            break;
                        }
                    case HolidayType.Two:
                        {
                            if (IsTypeTwoMatch(hol, start, end, include))
                            {
                                numToSubtract++;
                            }
                            break;
                        }
                    case HolidayType.Three:
                        {
                            if (IsTypeThreeMatch(hol, start, end))
                            {
                                numToSubtract++;
                            }
                            break;
                        }
                    case HolidayType.Four:
                        {
                            if (IsTypeFourMatch(hol, start, end))
                            {
                                numToSubtract++;
                            }
                            break;
                        }
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            return numToSubtract;
        }

        private bool IsTypeFourMatch(Holiday hol, DateTime start, DateTime end)
        {
            var target = hol.Date.DayOfWeek == DayOfWeek.Monday ? GetEasterSunday(start.Year).AddDays(-2) : GetEasterSunday(start.Year).AddDays(1);
            return target.Day != 25 && start < target && target < end;
        }

        public bool IsTypeThreeMatch(Holiday hol, DateTime start, DateTime end)
        {
            if (hol.Date.Year == start.Year) return hol.Date > start && hol.Date < end;

            if (start.Month > hol.Date.Month || end.Month < hol.Date.Month) return false;

            int ordinal;
            var diff = hol.Date.DayOfWeek - new DateTime(hol.Date.Year, hol.Date.Month, 1).DayOfWeek;
            if (diff == 0)
            {
                ordinal = (hol.Date.Day - 1) / 7 + 1;
            }
            else
            {
                var firstOccurence = 1 + (7 - Math.Abs(diff));
                ordinal = (hol.Date.Day - firstOccurence) / 7 + 1;
            }
            var targetDayOfMonth = (hol.Date.DayOfWeek - new DateTime(start.Year, hol.Date.Month, 1).DayOfWeek) + 7 * ordinal + 1;
            var targetHol = new DateTime(start.Year, hol.Date.Month, targetDayOfMonth);
            return targetHol > start && targetHol.Date < end;
        }

        public bool IsTypeTwoMatch(Holiday hol, DateTime start, DateTime end, bool include = false)
        {
            hol.Date = new DateTime(start.Year, hol.Date.Month, hol.Date.Day);

            if ((start.Date == hol.Date || start.Date.AddDays(-1) == hol.Date || start.Date.AddDays(-2) == hol.Date)
                 && (start.Date.DayOfWeek == DayOfWeek.Saturday || start.Date.DayOfWeek == DayOfWeek.Sunday))
            {
                return true;
            }

            return include ? (hol.Date >= start && hol.Date <= end) : (hol.Date > start && hol.Date < end);
        }

        public bool IsTypeOneMatch(Holiday hol, DateTime start, DateTime end)
        {
            hol.Date = new DateTime(start.Year, hol.Date.Month, hol.Date.Day);
            if (hol.Date <= start || hol.Date >= end) return false;

            var dayOfTheWeek = new DateTime(start.Year, hol.Date.Month, hol.Date.Day).DayOfWeek;
            return dayOfTheWeek != DayOfWeek.Saturday && dayOfTheWeek != DayOfWeek.Sunday;
        }

        public DateTime GetEasterSunday(int year)
        {
            //http://stackoverflow.com/questions/2510383/how-can-i-calculate-what-date-good-friday-falls-on-given-a-year

            var g = year % 19;
            var c = year / 100;
            var h = (c - c / 4 - (8 * c + 13) / 25 + 19 * g + 15) % 30;
            var i = h - (h / 28) * (1 - (h / 28) * (29 / (h + 1)) * ((21 - g) / 11));

            var day = i - ((year + (int)(year / 4) + i + 2 - c + (int)(c / 4)) % 7) + 28;
            var month = 3;

            if (day <= 31) return new DateTime(year, month, day);

            month++;
            day -= 31;

            return new DateTime(year, month, day);
        }
    }
}
