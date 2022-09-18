using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

using MobileTallerTEC.Services;
using MobileTallerTEC.Models;
using MobileTallerTEC.Views;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MobileTallerTEC.ViewModels
{
    public class BillingViewModel : BaseViewModel
    {
        private Bill _selectedBill;
        private readonly IService _service;
        public ObservableCollection<Bill> Bills { get; }
        public Command LoadBillsCommand { get; }

        public BillingViewModel(IService service)
        {
            Title = "Facturación";
            Bills = new ObservableCollection<Bill>();
            LoadBillsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            _service = service;
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Bills.Clear();
                List<Bill> bills = await _service.GetBillsAsync(UserSingleton.GetInstance().Id);
                foreach (var bill in bills)
                {
                    Bills.Add(bill);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedBill = null;
        }

        public Bill SelectedBill
        {
            get => _selectedBill;
            set
            {
                SetProperty(ref _selectedBill, value);
            }
        }
    }
}