using MobileTallerTEC.Models;
using MobileTallerTEC.Services;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using static Xamarin.Essentials.Permissions;

namespace MobileTallerTEC.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        private readonly IService _service;
        private string id;
        private string name;
        private string user;
        private string email;
        private string password;
        private string error;

        public RegisterViewModel(IService service)
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            _service = service;
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
            Title = "Registrar como Cliente";
            Error = "";

        }
        private bool ValidateSave()
        {
            bool valid = false;
            if (!String.IsNullOrWhiteSpace(id) && id.Length == 9
                && !String.IsNullOrWhiteSpace(name)
                && !String.IsNullOrWhiteSpace(user)
                && !String.IsNullOrWhiteSpace(email)
                && !String.IsNullOrWhiteSpace(password))

            {
                valid = true;
            }

            return valid;
        }
        public string Id
        {
            get => id;
            set => SetProperty(ref id, value);

        }
        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }
        public string User
        {
            get => user;
            set => SetProperty(ref user, value);
        }
        public string Email
        {
            get => email;
            set => SetProperty(ref email, value);
        }
        public string Password
        {
            get => password;
            set => SetProperty(ref password, value);
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
            List<ClientAddress> Address = new List<ClientAddress>();
            List<ClientPhones> Phone = new List<ClientPhones>();
            try
            {
                var client = new Client
                {
                    Id = Id,
                    Name = Name,
                    Password = Password,
                    User = User,
                    Email = Email,
                    Address = Address,
                    Phone = Phone

                };

                await _service.AddClientAsync(client);

                await Shell.Current.GoToAsync("..");
                Error = "";
            }
            catch (Exception ex)
            {
                Error = "No se pudo registrar, un cliente ya existe con el número de cédula o usuario seleccionado";
                Console.WriteLine(ex.Message);
            }
        }
    }
}
