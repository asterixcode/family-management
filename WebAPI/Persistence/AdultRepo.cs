using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPI.DataAccess;
using WebAPI.Models;

namespace WebAPI.Persistence
{
    public class AdultRepo : IAdultRepo
    {
        public async Task<IList<Adult>> GetAllAdultsAsync()
        {
            await using var familyDbContext = new FamilyDbContext();
            return familyDbContext.Adults
                .Include(a => a.JobTitle)
                .ToList();
        }

        public async Task<Adult> GetAdultByIdAsync(int id)
        {
            using (var familyDbContext = new FamilyDbContext())
            {
                return await familyDbContext.Adults
                    .Include(a => a.JobTitle)
                    .FirstOrDefaultAsync(a => a.Id == id);
            }
        }

        public async Task AddAdultAsync(Adult adult)
        {
            await using var familyDbContext = new FamilyDbContext();
            Job job = new Job();
            job = await familyDbContext.Jobs.FirstOrDefaultAsync(j => job.Id == adult.JobTitle.Id);
            adult.JobTitle = job;

            await familyDbContext.Adults.AddAsync(adult);
            await familyDbContext.SaveChangesAsync();
        }

        public async Task EditAdultAsync(Adult adult)
        {
            using (var familyDbContext = new FamilyDbContext())
            {
                await DeleteAdultAsync(adult.Id);
                await AddAdultAsync(adult);
                await familyDbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteAdultAsync(int id)
        {
            using (FamilyDbContext familyDbContext = new FamilyDbContext())
            {
                Adult remove = await GetAdultByIdAsync(id);
                familyDbContext.Adults.Remove(remove);
                await familyDbContext.SaveChangesAsync();
            }
        }
    }
}