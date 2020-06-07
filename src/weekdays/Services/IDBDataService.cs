using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Weekdays.Services
{
    public interface IDBDataService<T>
    {
        Task<List<T>> GetDatedItems<T>(DateTime from, DateTime to);
    }
}
