using MobileTallerTEC.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

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
            Console.WriteLine(JsonConvert.SerializeObject(appointment, Formatting.Indented));
            var response = await _httpClient.PostAsync("Quote/saveQuote",
                new StringContent(JsonConvert.SerializeObject(appointment, Formatting.Indented), Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
        }
    }
}
