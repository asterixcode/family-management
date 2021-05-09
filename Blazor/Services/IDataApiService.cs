using System.Collections.Generic;
using System.Threading.Tasks;
using Blazor.Models;

namespace Blazor.Services
{
    public interface IDataApiService
    {
        // adult
        Task<IList<Adult>> GetAllAdultsAsync();
        Task<Adult> GetAdultByIdAsync(int id);
        Task AddAdultAsync(Adult adult);
        Task EditAdultAsync(Adult adult);
        Task DeleteAdultAsync(int id);
        

        // jobs
        Task<IList<Job>> GetAllJobsAsync();
    }
}