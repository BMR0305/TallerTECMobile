using MobileTallerTEC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileTallerTEC.Views
{
    public partial class Billing : ContentPage
    {
        BillingViewModel _viewModel;
        public Billing()
        {
            InitializeComponent();
            BindingContext = _viewModel = Startup.Resolve<BillingViewModel>();
 
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}