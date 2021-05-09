using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DataAccess;
using WebAPI.Models;

namespace WebAPI.Repo
{
    public class JobRepo : IJobRepo
    {
        public async Task<IList<Job>> GetAllJobsAsync()
        {
            await using (FamilyDbContext familyDbContext = new FamilyDbContext())
            {
                return familyDbContext.Jobs.ToList();
            }
        }
    }
}