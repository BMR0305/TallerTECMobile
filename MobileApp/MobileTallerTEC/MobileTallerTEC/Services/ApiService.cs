using MobileTallerTEC.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace MobileTallerTEC.Services
{
    public class ApiService : IService
    {
        private readonly HttpClient _httpClient;
        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task AddAppointmentAsync(Appointment appointment)
        {
            var response = await _httpClient.PostAsync("Quote/saveQuote",
                new StringContent(JsonConvert.SerializeObject(appointment, Formatting.Indented), Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();

        }

        public async Task AddClientAsync(Client client)
        {
            var response = await _httpClient.PostAsync("Client/saveClientClient",
                new StringContent(JsonConvert.SerializeObject(client, Formatting.Indented), Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<Bill>> GetBillsAsync(string id)
        {
            var response = await _httpClient.GetAsync($"Quote/RequestBills/{id}");
            response.EnsureSuccessStatusCode();
            var responseAsString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Bill>>(responseAsString);
        }

        public async Task<Client> GetClientAsync(string user)
        {
            var response = await _httpClient.GetAsync($"Client/requestClientbyUser/{user}");
            response.EnsureSuccessStatusCode();
            string responseAsString = await response.Content.ReadAsStringAsync();
            string responseAsString_slice = responseAsString.Substring(26, responseAsString.Length - 27);
            return JsonConvert.DeserializeObject<Client>(responseAsString_slice);
        }

        public async Task<Worker> GetWorkerRAsync()
        {
            var response = await _httpClient.GetAsync("Api/requestWorkerR");
            response.EnsureSuccessStatusCode();
            string responseAsString = await response.Content.ReadAsStringAsync();
            string responseAsString_slice = responseAsString.Substring(26, responseAsString.Length - 27);
            return JsonConvert.DeserializeObject<Worker>(responseAsString_slice);
        }
    }
}
