using MobileTallerTEC.Models;
using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace MobileTallerTEC.ViewModels
{
    public class RegistrationViewModel : BaseViewModel
    {
        private string client;
        private string license_plate;
        private string office;
        private string service;
        private string date;
        private string today;

        public RegistrationViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
            Title = "Registro de Citas";
            today = DateTime.Today.ToString("MM/dd/yyyy");
            date = DateTime.Today.ToString("MM/dd/yyyy");
        }
        private bool ValidateSave()
        {
            bool valid = false;
            if (!String.IsNullOrWhiteSpace(license_plate) && license_plate.Length == 6
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

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            Item newItem = new Item()
            {
                Id = Guid.NewGuid().ToString(),
                Text = License_plate,
                Description = Service
            };

            await DataStore.AddItemAsync(newItem);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
