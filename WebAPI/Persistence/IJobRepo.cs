using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Persistence
{
    public interface IJobRepo
    {
        Task<IList<Job>> GetAllJobsAsync();
    }
}