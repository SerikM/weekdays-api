using Weekdays.Models;
using System.Collections.Generic;
using System;

namespace Weekdays.Tests
{
    public static class MockData
    {
        public static string ErrorMessage = "\"failed to process request\"";
        public static string SuccessMessage = "\"successfully processed request\"";
        public static string HitMessage = "\"hit\"";
        public static string MissMessage = "\"miss\"";
        public static string Player1Id = "123";
        public static string Player2Id = "234";

        public static List<Holiday> GetMockHolidays()
        {
            return new List<Holiday>() {
                new Holiday()
                {
                    Name = "New Years Day",
                    Date =  new DateTime(2020, 1, 1)
                    //2020-01-01T00:00:00.000Z
                 },
                 new Holiday()
                {
                    Name = "Australia Day",
                    Date =  new DateTime(2020, 1, 27)
                    //2020-1-27T00:00:00.000Z
                 },
                 new Holiday()
                {
                    Name = "Good Friday",
                    Date =  new DateTime(2020, 4, 10)
                    //2020-4-10T00:00:00.000Z
                 },
                 new Holiday()
                {
                    Name = "Easter Saturday",
                    Date =  new DateTime(2020, 4, 11)
                    //2020-4-11T00:00:00.000Z
                 },
                  new Holiday()
                {
                    Name = "Easter Sunday",
                    Date =  new DateTime(2020, 4, 12)
                    //2020-4-12T00:00:00.000Z
                 },
                 new Holiday()
                {
                    Name = "Eater Monday",
                    Date =  new DateTime(2020, 4, 13)
                    //2020-4-13T00:00:00.000Z
                 },
                new Holiday()
                {
                    Name = "Anzac Day",
                    Date =  new DateTime(2020, 4, 25)
                    //2020-4-25T00:00:00.000Z
                 },
                new Holiday()
                {
                    Name = "Queens Birthday",
                    Date =  new DateTime(2020, 6, 8)
                    //2020-6-8T00:00:00.000Z
                 },
                 new Holiday()
                {
                    Name = "Labour Day",
                    Date =  new DateTime(2020, 10, 5)
                    //2020-10-5T00:00:00.000Z
                 },
                 new Holiday()
                {
                    Name = "Christmas Day",
                    Date =  new DateTime(2020, 12, 25)
                    //2020-12-25T00:00:00.000Z
                 },
                 new Holiday()
                {
                    Name = "Boxing Day",
                    Date =  new DateTime(2020, 12, 26)
                    //2020-12-26T00:00:00.000Z
                 }
                };
        }
    }
}
