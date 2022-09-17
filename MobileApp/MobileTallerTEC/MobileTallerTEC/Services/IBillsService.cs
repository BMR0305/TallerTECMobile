using MobileTallerTEC.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MobileTallerTEC.Services
{
    public interface IBillsService
    {
        Task<bool> AddItemAsync(Bill item);
        Task<bool> UpdateItemAsync(Bill item);
        Task<bool> DeleteItemAsync(string licenseplate, string date);
        Task<List<Bill>> GetItemAsync(int id);
        Task<IEnumerable<Bill>> GetItemsAsync(bool forceRefresh = false);
    }
}

