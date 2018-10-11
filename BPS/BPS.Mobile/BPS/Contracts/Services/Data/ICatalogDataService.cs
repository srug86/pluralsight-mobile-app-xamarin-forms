using System.Collections.Generic;
using System.Threading.Tasks;
using BPS.Core.Models;

namespace BPS.Core.Contracts.Services.Data
{
    public interface ICatalogDataService
    {
        Task<IEnumerable<Pie>> GetAllPiesAsync();
        Task<IEnumerable<Pie>> GetPiesOfTheWeekAsync();
    }
}
