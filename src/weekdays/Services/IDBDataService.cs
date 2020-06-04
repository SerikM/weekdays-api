using Weekdays.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Weekdays.Repositories
{
    public interface IDBDataService<T>
    {
        Task<List<T>> GetDatedItems<T>(DateTime from, DateTime to);
    }
}
