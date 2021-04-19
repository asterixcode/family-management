using System.Collections.Generic;
using System.Threading.Tasks;
using Shared.Models;

namespace Blazor.Services
{
    public interface IDataApiService
    {
        // family
        Task<IList<Family>> GetAllFamiliesAsync();
        Task<IList<Family>> GetFamilyByUserIdAsync(int userId);
        Task AddFamilyAsync(Family family);
        Task EditFamilyAsync(Family family);
        Task DeleteFamilyAsync(int familyId);


        // adult
        Task<IList<Adult>> GetAllAdultsAsync();
        Task<Adult> GetAdultByIdAsync(int id);
        Task AddAdultAsync(Adult adult);
        Task EditAdultAsync(Adult adult);
        Task DeleteAdultAsync(int id);

        
        // child
        //Task<IList<Child>> GetAllChildAsync();
        //Task<Child> GetChildByIdAsync(int id);
        //Task EditChildAsync(Child child);
        //Task DeleteChildAsync(int id);


        // jobs
        Task<IList<Job>> GetAllJobsAsync();
    }
}