using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Repo
{
    public interface IJobRepo
    {
        Task<IList<Job>> GetAllJobsAsync();
    }
}