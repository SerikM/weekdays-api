using System.Threading.Tasks;
using Weekdays.Models;

namespace Weekdays.Services
{
    public interface ICalculationService
    {
        public Task<int> GetWeekdays(string from, string to);
    }
}
