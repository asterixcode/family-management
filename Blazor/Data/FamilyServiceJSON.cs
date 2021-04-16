using System.Collections.Generic;
using System.Linq;
using Blazor.Models;
using Blazor.Persistence;

namespace Blazor.Data
{
    public class FamilyServiceJSON : IFamilyService
    {
        private FileContext FileContext = new FileContext();

        public IList<Adult> GetAllAdults()
        {
            IList<Adult> tmp = new List<Adult>(FileContext.Adults);
            return tmp;
        }
        
        public Adult GetAdultById(int id)
        {
            return FileContext.Adults.FirstOrDefault(a => a.Id == id);
        }

        public void AddAdult(Adult adult)
        {
            int max = FileContext.Adults.Max(adult => adult.Id);
            adult.Id = (++max);
            FileContext.Adults.Add(adult);
            FileContext.SaveChanges();
        }

        public void RemoveAdult(int id)
        {
            FileContext.Adults.Remove(FileContext.Adults.First(a => a.Id == id));
            FileContext.SaveChanges();
        }

        public void UpdateAdult(Adult adult)
        {
            Adult editAdult = FileContext.Adults.First(a => a.Id == adult.Id);
            editAdult.JobTitle = adult.JobTitle;
            editAdult.FirstName = adult.FirstName;
            editAdult.LastName = adult.LastName;
            editAdult.HairColor = adult.HairColor;
            editAdult.EyeColor = adult.EyeColor;
            editAdult.Age = adult.Age;
            editAdult.Weight = adult.Weight;
            editAdult.Height = adult.Height;
            editAdult.Sex = adult.Sex;
            FileContext.SaveChanges();
        }
        

        
        public IList<Job> GetAllJobs()
        {
            IList<Job> jobs = new List<Job>();
            IList<Adult> adults = GetAllAdults();
            foreach (Adult adult in adults)
            {
                jobs.Add(adult.JobTitle);
            }

            return jobs;
        }
    }
}