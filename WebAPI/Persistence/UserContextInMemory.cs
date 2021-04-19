using System;
using System.Collections.Generic;
using System.Linq;
using Shared.Models;

namespace WebAPI.Persistence
{
    public class UserContextInMemory
    {
        private List<User> users;

        public UserContextInMemory()
        {
            users = new[]
            {
                new User()
                {
                    Username = "admin",
                    Password = "admin",
                    Role = "ADMIN"
                },
                new User()
                {
                    Username = "lucas",
                    Password = "12345",
                    Role = "STUDENT",
                }
            }.ToList();
        }

        public User ValidateUserAsync(string username, string password)
        {
            User temp = users.FirstOrDefault(user => user.Username.Equals(username));
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