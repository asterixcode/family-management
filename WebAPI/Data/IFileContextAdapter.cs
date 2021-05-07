using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Data
{
    public interface IFileContextAdapter
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