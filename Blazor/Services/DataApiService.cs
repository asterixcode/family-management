using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Shared.Models;
using Microsoft.AspNetCore.Components;

namespace Blazor.Services
{
    public class DataApiService : IDataApiService
    {
        private readonly HttpClient httpClient;

        // dependency injection for the the HttpClient
        // -> DI can be used in the constructor of a Service class
        // (can't be used in a Blazor Component -> have to use the [inject] attribute in the property) 
        public DataApiService(HttpClient client)
        {
            this.httpClient = client;
        }


        // Families
        public async Task<IList<Family>> GetAllFamiliesAsync()
        {
            HttpResponseMessage response = await httpClient.GetAsync("/families");
           
            if (!response.IsSuccessStatusCode)
                throw new Exception($@"Error: {response.StatusCode}, {response.ReasonPhrase}");
            
            string responseContent = await response.Content.ReadAsStringAsync();
            List<Family> allFamilies = JsonSerializer.Deserialize<List<Family>>(responseContent, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return allFamilies;
        }

        public async Task<IList<Family>> GetFamilyByUserIdAsync(int id)
        {
            HttpResponseMessage response = await httpClient.GetAsync($"/families/adults/{id}");
            if (!response.IsSuccessStatusCode)
                throw new Exception($@"Error: {response.StatusCode}, {response.ReasonPhrase}");

            string responseContent = await response.Content.ReadAsStringAsync();
            List<Family> familyById = JsonSerializer.Deserialize<List<Family>>(responseContent, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return familyById;
        }

        public async Task AddFamilyAsync(Family family)
        {
            string jsonFamily = JsonSerializer.Serialize(family);
            StringContent content = new StringContent(jsonFamily, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await httpClient.PostAsync("/families", content);
            if (!response.IsSuccessStatusCode)
                throw new Exception($@"Error: {response.StatusCode}, {response.ReasonPhrase}");
        }

        public async Task EditFamilyAsync(Family family)
        {
            string jsonFamily = JsonSerializer.Serialize(family);
            StringContent content = new StringContent(jsonFamily, Encoding.UTF8, "application.json");

            HttpResponseMessage response = await httpClient.PatchAsync("/families", content);
            if (!response.IsSuccessStatusCode)
                throw new Exception($@"Error: {response.StatusCode}, {response.ReasonPhrase}");
        }

        public async Task DeleteFamilyAsync(int id)
        {
            HttpResponseMessage response = await httpClient.DeleteAsync("/families/{id}");
            if (!response.IsSuccessStatusCode)
                throw new Exception($@"Error: {response.StatusCode}, {response.ReasonPhrase}");
        }

        
        // Adults
        // GET ALL ADULTS
        public async Task<IList<Adult>> GetAllAdultsAsync()
        {
            // return await httpClient.GetJsonAsync<Adult[]>("/adults");  // using the Microsoft.AspNetCore.Components httpClient nuget package
            
            HttpResponseMessage response = await httpClient.GetAsync("/adult");
           
            if (!response.IsSuccessStatusCode)
                throw new Exception($@"Error: {response.StatusCode}, {response.ReasonPhrase}");
            
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
            HttpResponseMessage response = await httpClient.GetAsync($"/adult/{id}");
            if (!response.IsSuccessStatusCode)
                throw new Exception($@"Error: {response.StatusCode}, {response.ReasonPhrase}");

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
            string jsonAdult = JsonSerializer.Serialize(adult);
            StringContent content = new StringContent(jsonAdult, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await httpClient.PostAsync("/adult", content);
            if (!response.IsSuccessStatusCode)
                throw new Exception($@"Error: {response.StatusCode}, {response.ReasonPhrase}");
        }

        // EDIT ADULT
        public async Task EditAdultAsync(Adult adult)
        {
            string jsonAdult = JsonSerializer.Serialize(adult);
            StringContent content = new StringContent(jsonAdult, Encoding.UTF8, "application.json");

            HttpResponseMessage response = await httpClient.PatchAsync("/adult", content);
            if (!response.IsSuccessStatusCode)
                throw new Exception($@"Error: {response.StatusCode}, {response.ReasonPhrase}");
        }

        // DELETE ADULT
        public async Task DeleteAdultAsync(int id)
        {
            HttpResponseMessage response = await httpClient.DeleteAsync("/adult/{id}");
            if (!response.IsSuccessStatusCode)
                throw new Exception($@"Error: {response.StatusCode}, {response.ReasonPhrase}");
        }

        
        // jobs
        public async Task<IList<Job>> GetAllJobsAsync()
        {
            HttpResponseMessage response = await httpClient.GetAsync("/jobs");
           
            if (!response.IsSuccessStatusCode)
                throw new Exception($@"Error: {response.StatusCode}, {response.ReasonPhrase}");
            
            string responseContent = await response.Content.ReadAsStringAsync();
            List<Job> jobs = JsonSerializer.Deserialize<List<Job>>(responseContent, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return jobs;
        }
    }
}