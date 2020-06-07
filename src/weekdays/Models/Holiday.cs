using Amazon.DynamoDBv2.DataModel;
using System;
using Weekdays.Helpers;

namespace Weekdays.Models
{
    public class Holiday : IData 
    {
        public string Name { get; set; }
        [DynamoDBProperty(typeof(DateTimeUtcConverter))]
        public DateTime Date { get; set; }
        public HolidayType Type { get; set; }
    }
}