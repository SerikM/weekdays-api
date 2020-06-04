using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Weekdays.Models
{
    public class AwsSettingsModel
    {
        public string HolidaysTableName { get; set; }
        public string Region { get; set; }
    }
}
