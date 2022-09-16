using MobileTallerTEC.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MobileTallerTEC.Services
{
    public interface IAppointmentService
    {
        Task<bool> AddItemAsync(Appointment item);
        Task<bool> UpdateItemAsync(Appointment item);
        Task<bool> DeleteItemAsync(string licenseplate, string date);
        Task<Appointment> GetItemAsync(string licenseplate, string date);
        Task<IEnumerable<Appointment>> GetItemsAsync(bool forceRefresh = false);
    }
}

