using System;

namespace Weekdays.Models
{
    public class Holiday : IData 
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public HolidayType DayType { get; set; }
    }
}