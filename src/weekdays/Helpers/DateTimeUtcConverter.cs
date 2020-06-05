using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using System;

namespace Weekdays.Helpers
{
    public class DateTimeUtcConverter : IPropertyConverter
    {
        public DynamoDBEntry ToEntry(object value) => (DateTime)value;

        public object FromEntry(DynamoDBEntry entry)
        {
            var dateTime = entry.AsDateTime();
            return dateTime.ToUniversalTime();
        }
    }
}