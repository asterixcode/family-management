using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Persistence;

namespace WebAPI.Data
{
    public class FileContextAdapterJson : IFileContextAdapter
    {
        private readonly FileContext file = new FileContext();
            

        // adult
        public async Task<IList<Adult>> GetAllAdultsAsync()
        {
            IList<Adult> tmp = file.Adults;
            return tmp;
        }
        
        public async Task<Adult> GetAdultByIdAsync(int id)
        {
            return file.Adults.FirstOrDefault(a => a.Id == id);
        }

        public async Task AddAdultAsync(Adult adult) 
        {
            var max = file.Adults.Max(adult => adult.Id);
            adult.Id = (++max);
            file.Adults.Add(adult);
            file.SaveChanges();
        }

        public async Task EditAdultAsync(Adult adult)
        {
            var newAdult = file.Adults.First(a => a.Id == adult.Id);
            newAdult.JobTitle = adult.JobTitle;
            newAdult.FirstName = adult.FirstName;
            newAdult.LastName = adult.LastName;
            newAdult.HairColor = adult.HairColor;
            newAdult.EyeColor = adult.EyeColor;
            newAdult.Age = adult.Age;
            newAdult.Weight = adult.Weight;
            newAdult.Height = adult.Height;
            newAdult.Sex = adult.Sex;
            file.SaveChanges();
        }

        public async Task DeleteAdultAsync(int id)
        {
            file.Adults.Remove(file.Adults.First(a => a.Id == id));
            file.SaveChanges();
        }
        


        // job
        public async Task<IList<Job>> GetAllJobsAsync()
        {
            var adults = GetAllAdultsAsync().Result;

            return adults.Select(adult => adult.JobTitle).ToList();
        }
    }
}