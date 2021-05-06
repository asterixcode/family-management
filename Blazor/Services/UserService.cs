using System;
using System.Net.Http;
using System.Text;
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
                HttpResponseMessage response = await httpClient.GetAsync($"/user?username={username}&password={password}");
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
            // string jsonUser = JsonSerializer.Serialize(user);
            // StringContent content = new StringContent(jsonUser, Encoding.UTF8, "application/json")
            // HttpResponseMessage response = await httpClient.PostAsync("/user", content);
            // if (!response.IsSuccessStatusCode)
            // {
            //     throw new Exception($"Error: {response.StatusCode}, {response.ReasonPhrase}");
            // }
            
            var jsonUser = new StringContent(
                JsonSerializer.Serialize(user, typeof(User), new JsonSerializerOptions(JsonSerializerDefaults.Web)), Encoding.UTF8, "application/json");

            using var httpResponse = await httpClient.PostAsync("/user", jsonUser);

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception(httpResponse.Content.ReadAsStringAsync().Result);
            }
        }

        public int GetUserId(string username)
        {
            throw new System.NotImplementedException();
        }
    }
}