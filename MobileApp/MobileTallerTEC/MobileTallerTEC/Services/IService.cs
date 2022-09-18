using MobileTallerTEC.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MobileTallerTEC.Services
{
    public interface IService
    {
        Task AddAppointmentAsync(Appointment appointment);
        
    }
}

