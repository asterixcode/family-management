using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Blazor.Models;

namespace Blazor.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;
        private User _logged;

        public UserService(HttpClient client)
        {
            _httpClient = client;
        }
        
        public async Task<User> ValidateUserAsync(string username, string password)
        {
            User newUser;
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"/user?username={username}&password={password}");
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
            
            _logged = newUser;
            return newUser;
        }

        public async Task RegisterUserAsync(User user)
        {
            var jsonUser = new StringContent(
                JsonSerializer.Serialize(user, typeof(User), new JsonSerializerOptions(JsonSerializerDefaults.Web)), Encoding.UTF8, "application/json");

            using var httpResponse = await _httpClient.PostAsync("/user", jsonUser);

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception(httpResponse.Content.ReadAsStringAsync().Result);
            }
        }
        
    }
}