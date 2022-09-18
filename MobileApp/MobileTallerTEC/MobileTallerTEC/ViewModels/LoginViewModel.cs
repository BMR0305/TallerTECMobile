using MobileTallerTEC.Models;
using MobileTallerTEC.Services;
using MobileTallerTEC.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MobileTallerTEC.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }
        public Command RegisterCommand { get; }
        private readonly IService _service;

        private string user;
        private string password;
        private string error;

        public LoginViewModel(IService service)
        {
            LoginCommand = new Command(OnLoginClicked);
            RegisterCommand = new Command(OnRegisterClicked);
            _service = service;
            Error = "";
            user = "";
            password = "";
        }

        private async void OnLoginClicked(object obj)
        {
            try
            {
                Client client = await _service.GetClientAsync(User);
                Error = "";
                if (client.Password == password)
                {
                    UserSingleton.GetInstance().Id =client.Id;
                    await Shell.Current.GoToAsync($"//{nameof(Registration)}");
                }
                else
                {
                    Error = "No se pudo iniciar sesión, contraseña equivocada";
                }
            }
            catch (Exception ex)
            {
                Error = "No se pudo iniciar sesión, nombre de usuario no encontrado";
                Console.WriteLine(ex.Message);
            }
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one

        }
        private async void OnRegisterClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Shell.Current.GoToAsync(nameof(Register));
        }

        public string User
        {
            get => user;
            set => SetProperty(ref user, value);

        }
        public string Error
        {
            get => error;
            set => SetProperty(ref error, value);

        }
        public string Password
        {
            get => password;
            set => SetProperty(ref password, value);

        }

    }
}
