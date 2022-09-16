using MobileTallerTEC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileTallerTEC.Services
{
    public class InMemoryAppointmentService : IAppointmentService
    {
        readonly List<Appointment> appointments;

        public InMemoryAppointmentService()
        {

        }

        public async Task<bool> AddItemAsync(Appointment item)
        {
            appointments.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Appointment item)
        {
            var oldItem = appointments.Where((Appointment arg) => arg.LicensePlate == item.LicensePlate && 
            arg.Date == item.Date).FirstOrDefault();
            appointments.Remove(oldItem);
            appointments.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string licenseplate, string date)
        {
            var oldItem = appointments.Where((Appointment arg) => arg.LicensePlate == licenseplate &&
            arg.Date == date).FirstOrDefault();
            appointments.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Appointment> GetItemAsync(string licenseplate, string date)
        {
            return await Task.FromResult(appointments.FirstOrDefault(s => s.LicensePlate == licenseplate &&
            s.Date == date));
        }

        public async Task<IEnumerable<Appointment>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(appointments);
        }
    }
}