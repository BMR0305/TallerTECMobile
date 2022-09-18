using MobileTallerTEC.Models;
using MobileTallerTEC.Services;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace MobileTallerTEC.ViewModels
{
    public class RegistrationViewModel : BaseViewModel
    {
        private readonly IService _service;
        private string client;
        private string license_plate;
        private string office;
        private string service;
        private string date;
        private string today;
        private string error;

        public RegistrationViewModel(IService service)
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            _service = service;
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
            Title = "Registro de Citas";
            today = DateTime.Today.ToString("MM/dd/yyyy");
            date = DateTime.Today.ToString("MM/dd/yyyy");
            Error = "";
        }
        private bool ValidateSave()
        {
            bool valid = false;
            if (!String.IsNullOrWhiteSpace(license_plate) && license_plate.Length == 7
                && !String.IsNullOrWhiteSpace(office)
                && !String.IsNullOrWhiteSpace(service)
                && !String.IsNullOrWhiteSpace(date))
            {
                valid = true;
            }
            
            return valid;
        }
        public string Today
        {
            get => today;
            set => SetProperty(ref today, value);

        }
        public string Client
        {
            get => client;
            set => SetProperty(ref client, value);

        }
        public string License_plate
        {
            get => license_plate;
            set => SetProperty(ref license_plate, value);
        }
        public string Office
        {
            get => office;
            set => SetProperty(ref office, value);
        }
        public string Service
        {
            get => service;
            set => SetProperty(ref service, value);
        }
        public string Date
        {
            get => date;
            set => SetProperty(ref date, value);
        }

        public string Error
        {
            get => error;
            set => SetProperty(ref error, value);
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            List<Replacements> Replacements = new List<Replacements>();
            try
            {
                Worker Responsible = await _service.GetWorkerRAsync();
                Worker Assistant = await _service.GetWorkerRAsync();
                var appointment = new Appointment
                {
                    responsible = Responsible.idNumber.ToString(),
                    assistant = Assistant.idNumber.ToString(),
                    licensePlate = License_plate,
                    service = Service,
                    client = UserSingleton.GetInstance().Id,
                    office = Office,
                    date = Date.Substring(0,10),
                    replacements = Replacements
                };

                await _service.AddAppointmentAsync(appointment);

                await Shell.Current.GoToAsync("..");
                Error = "Cita registrada correctamente";
            }
            catch (Exception ex)
            {
                Error = "No se pudo registrar la cita";
                Console.WriteLine(ex.Message);
            }
        }
    }
}
