using MobileTallerTEC.Models;
using System;
using Xamarin.Forms;

namespace MobileTallerTEC.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        private string id;
        private string name;
        private string user;
        private string email;
        private string password;


        public RegisterViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
            Title = "Registrar como Cliente";

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
                Text = User,
                Description = Password
            };

            await DataStore.AddItemAsync(newItem);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
