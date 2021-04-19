using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Shared.Models;

namespace Blazor.Services
{
    public class UserService : IUserService
    {
        private HttpClient httpClient;
        private User logged;

        public UserService(HttpClient client)
        {
            this.httpClient = client;
        }
        
        public async Task<User> ValidateUserAsync(string username, string password)
        {
            User newUser = new User();
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync($"?username={username}&password={password}");
                if (!response.IsSuccessStatusCode)
                    throw new Exception($"Error: {response.StatusCode}, {response.ReasonPhrase}");

                string responseContent = await response.Content.ReadAsStringAsync();
                newUser = JsonSerializer.Deserialize<User>(responseContent, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            Console.WriteLine("i got here with " + newUser.Username);
            logged = newUser;
            return newUser;
        }

        public async Task RegisterUser(User user)
        {
            throw new System.NotImplementedException();
        }

        public void EditUser(User user)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteUser(int userId)
        {
            throw new System.NotImplementedException();
        }

        public int GetUserId(string username)
        {
            throw new System.NotImplementedException();
        }
    }
}