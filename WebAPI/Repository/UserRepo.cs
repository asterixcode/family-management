using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPI.DataAccess;
using WebAPI.Models;

namespace WebAPI.Repository
{
    public class UserRepo : IUserRepo
    {
        public async Task<User> ValidateUserAsync(string username, string password)
        {
            using (FamilyDbContext familyDbContext = new FamilyDbContext())
            {
                User user = await familyDbContext.Users.FirstOrDefaultAsync(u => u.Username.Equals(username));
               
                if (user == null) throw new Exception("User does not exist.");
                
                if (!user.Password.Equals(password)) throw new Exception("Incorrect password.");
                
                return user;
            }
        }

        public async Task RegisterUserAsync(User user)
        {
            using (FamilyDbContext familyDbContext = new FamilyDbContext())
            {
                User first = await familyDbContext.Users.FirstOrDefaultAsync((u => u.Username.Equals(user.Username)));
                
                if (first != null) throw new Exception("Username already register. Choose another username.");

                int max = await familyDbContext.Users.MaxAsync(u => u.Id);
                user.Id = (++max);
                await familyDbContext.Users.AddAsync(user);
                await familyDbContext.SaveChangesAsync();
            }
        }
    }
}