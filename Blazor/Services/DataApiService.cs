using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Blazor.Models;

namespace Blazor.Services
{
    public class DataApiService : IDataApiService
    {
        private readonly HttpClient _httpClient;

        // dependency injection for the the HttpClient
        // -> DI can be used in the constructor of a Service class
        // (can't be used in a Blazor Component -> have to use the [inject] attribute in the property) 
        public DataApiService(HttpClient client)
        {
            _httpClient = client;
        }
        
        // Adults
        // GET ALL ADULTS
        public async Task<IList<Adult>> GetAllAdultsAsync()
        {
            // return await httpClient.GetJsonAsync<Adult[]>("/adults");  // using the Microsoft.AspNetCore.Components httpClient nuget package
            
            HttpResponseMessage response = await _httpClient.GetAsync("/adult");
           
            if (!response.IsSuccessStatusCode)
                throw new Exception($"Error: {response.StatusCode}, {response.ReasonPhrase}");
            
            string responseContent = await response.Content.ReadAsStringAsync();
            List<Adult> allAdults = JsonSerializer.Deserialize<List<Adult>>(responseContent, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return allAdults;
        }
        
        // GET ADULT BY ID
        public async Task<Adult> GetAdultByIdAsync(int id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"/adult/{id}");
            if (!response.IsSuccessStatusCode)
                throw new Exception($"Error: {response.StatusCode}, {response.ReasonPhrase}");

            string responseContent = await response.Content.ReadAsStringAsync();
            Adult adult = JsonSerializer.Deserialize<Adult>(responseContent, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return adult;
        }

        // ADD ADULT
        public async Task AddAdultAsync(Adult adult)
        {
            // string jsonAdult = JsonSerializer.Serialize(adult);
            // StringContent content = new StringContent(jsonAdult, Encoding.UTF8, "application/json");
            //
            // HttpResponseMessage response = await httpClient.PostAsync("/adult", content);
            // if (!response.IsSuccessStatusCode)
            //     throw new Exception($"Error: {response.StatusCode}, {response.ReasonPhrase}");
            
            var jsonAdult = new StringContent(
                JsonSerializer.Serialize(adult, typeof(Adult), new JsonSerializerOptions(JsonSerializerDefaults.Web)), Encoding.UTF8, "application/json");

            using var httpResponse = await _httpClient.PostAsync("/adult", jsonAdult);

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception(httpResponse.Content.ReadAsStringAsync().Result);
            }
            
        }

        // EDIT ADULT
        public async Task EditAdultAsync(Adult adult)
        {
            string jsonAdult = JsonSerializer.Serialize(adult);
            StringContent content = new StringContent(jsonAdult, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PatchAsync("/adult", content);
            if (!response.IsSuccessStatusCode)
                throw new Exception($"Error: {response.StatusCode}, {response.ReasonPhrase}");
        }

        // DELETE ADULT
        public async Task DeleteAdultAsync(int id)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync("/adult/{id}");
            if (!response.IsSuccessStatusCode)
                throw new Exception($"Error: {response.StatusCode}, {response.ReasonPhrase}");
        }

        
        // jobs
        // GET ALL JOBS
        public async Task<IList<Job>> GetAllJobsAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("/jobs");
           
            if (!response.IsSuccessStatusCode)
                throw new Exception($"Error: {response.StatusCode}, {response.ReasonPhrase}");
            
            string responseContent = await response.Content.ReadAsStringAsync();
            List<Job> jobs = JsonSerializer.Deserialize<List<Job>>(responseContent, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            Console.WriteLine($"{jobs.Count}");
            return jobs;
        }
    }
}