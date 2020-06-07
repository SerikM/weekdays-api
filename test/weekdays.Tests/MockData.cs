using Weekdays.Models;
using System.Collections.Generic;
using System;
using HolidayType = Weekdays.Models.HolidayType;

namespace Weekdays.Tests
{
    public static class MockData
    {
        public static List<Holiday> GetMockHolidays()
        {
            return new List<Holiday>() {
                new Holiday()
                {
                    Name = "New Years Day",
                    Date =  new DateTime(2020, 1, 1),
                    Type = HolidayType.Two
                },
                 new Holiday()
                {
                    Name = "Australia Day",
                    Date =  new DateTime(2020, 1, 26),
                    Type = HolidayType.Two
                },
                 new Holiday()
                {
                    Name = "Good Friday",
                    Date =  new DateTime(2020,4,19),
                    Type = HolidayType.Four
                },
                 new Holiday()
                {
                    Name = "Eater Monday",
                    Date =  new DateTime(2020,4,22),
                    Type = HolidayType.Four
                },
                new Holiday()
                {
                    Name = "Anzac Day",
                    Date =  new DateTime(2020, 4, 25),
                    Type =  HolidayType.One
                 },
                new Holiday()
                {
                    Name = "Queens Birthday",
                    Date =  new DateTime(2020, 6, 8),
                    Type =  HolidayType.Three
                 },
                 new Holiday()
                {
                    Name = "Labor Day",
                    Date =  new DateTime(2020, 10, 5),
                    Type =  HolidayType.Three
                 },
                 new Holiday()
                {
                    Name = "Christmas Day",
                    Date =  new DateTime(2020, 12, 25),
                    Type =  HolidayType.One
                 },
                 new Holiday()
                {
                    Name = "Boxing Day",
                    Date =  new DateTime(2020, 12, 26),
                    Type =  HolidayType.One
                 }
            };
        }

        public static List<Holiday> GetHolidaysMultipleYears()
        {
            return new List<Holiday>() { new Holiday() { Date = new DateTime(2019, 12, 26), Type = HolidayType.One },
                new Holiday() { Date = new DateTime(2020, 1, 1), Type = HolidayType.Two }};
        }
    }
}
