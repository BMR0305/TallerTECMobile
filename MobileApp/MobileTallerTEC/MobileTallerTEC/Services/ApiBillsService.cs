using MobileTallerTEC.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace MobileTallerTEC.Services
{
    public class ApiBillsService : IBillsService
    {
        private readonly HttpClient _httpClient;
        public ApiBillsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public Task<bool> AddItemAsync(Bill item)
        {
            //throw new NotImplementedException();
            return null;
        }

        public Task<bool> DeleteItemAsync(string licenseplate, string date)
        {
            //throw new NotImplementedException();
            return null;
        }

        public async Task<List<Bill>> GetItemAsync(int id)
        {
            var responde = await _httpClient.GetAsync($"Quote/requestService/{id}");

            responde.EnsureSuccessStatusCode();

            var responseAsString = await responde.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Bill>>(responseAsString);
        }

        public Task<IEnumerable<Bill>> GetItemsAsync(bool forceRefresh = false)
        {
            //throw new NotImplementedException();
            return null;
        }

        public Task<bool> UpdateItemAsync(Bill item)
        {
            // new NotImplementedException();
            return null;
        }
    }
}
