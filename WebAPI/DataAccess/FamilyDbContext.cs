using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.DataAccess
{
    public class FamilyDbContext : DbContext
    {
        public DbSet<Adult> Adults { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = C:\\Users\\lucas\\Desktop\\DNP1\\FamilyManagement\\WebAPI\\FamilyDb.db");
        }
    }
}