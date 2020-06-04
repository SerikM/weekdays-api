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
                 },
                 new Holiday()
                {
                    Name = "Australia Day",
                    Date =  new DateTime(2020, 1, 27)
                 },
                 new Holiday()
                {
                    Name = "Good Friday",
                    Date =  new DateTime(2020, 4, 10)
                 },
                 new Holiday()
                {
                    Name = "Easter Saturday",
                    Date =  new DateTime(2020, 4, 11)
                 },
                  new Holiday()
                {
                    Name = "Easter Sunday",
                    Date =  new DateTime(2020, 4, 12)
                 },
                 new Holiday()
                {
                    Name = "Eater Monday",
                    Date =  new DateTime(2020, 4, 13)
                 },
                new Holiday()
                {
                    Name = "Anzac Day",
                    Date =  new DateTime(2020, 4, 25)
                 },
                new Holiday()
                {
                    Name = "Queens Birthday",
                    Date =  new DateTime(2020, 6, 8)
                 },
                 new Holiday()
                {
                    Name = "Labour Day",
                    Date =  new DateTime(2020, 10, 5)
                 },
                 new Holiday()
                {
                    Name = "Christmas Day",
                    Date =  new DateTime(2020, 12, 25)
                 },
                 new Holiday()
                {
                    Name = "Boxing Day",
                    Date =  new DateTime(2020, 12, 26)
                 }

                };

        }


    }
}
