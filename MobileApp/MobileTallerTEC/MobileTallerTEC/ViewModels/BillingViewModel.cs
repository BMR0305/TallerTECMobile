using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

using MobileTallerTEC.Services;

namespace MobileTallerTEC.ViewModels
{
    public class BillingViewModel : BaseViewModel
    {

        private int id = 123;
        private ApiBillsService apiBillsService;
        public BillingViewModel()
        {
            Title = "Facturacion";
            var bills = this.apiBillsService.GetItemAsync(this.id);
            Console.WriteLine(bills);
        }
    }
}