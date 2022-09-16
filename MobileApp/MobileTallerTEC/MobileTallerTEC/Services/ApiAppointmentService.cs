using MobileTallerTEC.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace MobileTallerTEC.Services
{
    public class ApiAppointmentService : IAppointmentService
    {
        private readonly HttpClient _httpClient;
        public ApiAppointmentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public Task<bool> AddItemAsync(Appointment item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteItemAsync(string licenseplate, string date)
        {
            throw new NotImplementedException();
        }

        public Task<Appointment> GetItemAsync(string licenseplate, string date)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Appointment>> GetItemsAsync(bool forceRefresh = false)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateItemAsync(Appointment item)
        {
            throw new NotImplementedException();
        }
    }
}
