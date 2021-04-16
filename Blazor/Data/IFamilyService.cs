using System.Collections.Generic;
using Blazor.Models;

namespace Blazor.Data
{
    public interface IFamilyService
    {
        // adult
        IList<Adult> GetAllAdults();
        Adult GetAdultById(int id);
        void AddAdult(Adult adult);
        void RemoveAdult(int id);
        void UpdateAdult(Adult adult);
        
        // jobs
        IList<Job> GetAllJobs();
        
    }
}