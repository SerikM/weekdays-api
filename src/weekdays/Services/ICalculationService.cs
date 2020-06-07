using System.Threading.Tasks;

namespace Weekdays.Services
{
    public interface ICalculationService
    {
        public Task<int> GetWeekdays(string from, string to);
    }
}
