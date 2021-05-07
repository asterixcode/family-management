using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using WebAPI.Models;

namespace WebAPI.Persistence
{
    public class FileContext
    {
        public IList<Adult> Adults { get; private set; }
        public IList<User> Users { get; private set; }


        private readonly string adultsFile = "adults.json";
        private readonly string usersFile = "users.json";

        public FileContext()
        {
            Adults = File.Exists(adultsFile) ? ReadData<Adult>(adultsFile) : new List<Adult>();
            Users = File.Exists(usersFile) ? ReadData<User>(usersFile) : new List<User>();
        }

        private IList<T> ReadData<T>(string fileName)
        {
            using (var jsonReader = File.OpenText(fileName))
            {
                return JsonSerializer.Deserialize<List<T>>(jsonReader.ReadToEnd());
            }
        }

        public void SaveChanges()
        {
            // storing persons
            string jsonAdults = JsonSerializer.Serialize(Adults, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            using (StreamWriter outputFile = new StreamWriter(adultsFile, false))
            {
                outputFile.Write(jsonAdults);
            }
            
            // storing users
            string jsonUsers = JsonSerializer.Serialize(Users, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            using (StreamWriter outputFile = new StreamWriter(usersFile, false))
            {
                outputFile.Write(jsonUsers);
            }
        }

        public User ValidateUser(string username, string password)
        {
            User user = Users.FirstOrDefault(u => u.Username.Equals(username));
            if (user == null) throw new Exception("User does not exist.");
            if (!user.Password.Equals(password)) throw new Exception("Incorrect password.");
            return user;
        }

        public void RegisterUser(User user)
        {
            User first = null;
            try
            {
                first = Users.FirstOrDefault(u => u.Username.Equals(user.Username));
            }
            catch (Exception e)
            {
            }
            
            if (first != null)
            {
                throw new Exception("Username already register. Choose another username.");
            }
            
            int max = Users.Max(u => u.Id);
            user.Id = (++max);
            Users.Add(user);
            SaveChanges();
        }

        public void EditUser(User user)
        {
            User toEdit = Users.FirstOrDefault(u => u.Id == user.Id);
            toEdit.Username = user.Username;
            toEdit.Password = user.Password;
            SaveChanges();
        }

        public void DeleteUser(int id)
        {
            User toDelete = Users.FirstOrDefault(u => u.Id == id);
            Users.Remove(toDelete);
            SaveChanges();
        }
        
        
    }
}