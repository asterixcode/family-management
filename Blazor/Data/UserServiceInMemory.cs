using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazor.Models;

namespace Blazor.Data
{
    public class UserServiceInMemory : IUserService
    {
        private List<User> users;

        public UserServiceInMemory()
        {
            users = new[]
            {
                new User()
                {
                    UserName = "admin",
                    Password = "admin",
                    Role = "ADMIN"
                },
                new User()
                {
                    UserName = "lucas",
                    Password = "12345",
                    Role = "STUDENT",
                }
            }.ToList();
        }

        public async Task<User> ValidateUserAsync(string username, string password)
        {
            User temp = users.FirstOrDefault(user => user.UserName.Equals(username));
            if (temp == null)
            {
                throw new Exception("User not found.");
            }

            if (!temp.Password.Equals(password))
            {
                throw new Exception("Incorrect password.");
            }

            return temp;
        }
    }
}