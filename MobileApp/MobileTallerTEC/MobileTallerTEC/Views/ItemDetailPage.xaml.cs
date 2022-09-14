using MobileTallerTEC.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace MobileTallerTEC.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}