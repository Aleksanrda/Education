using BabyMobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BabyMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditDevicePage : ContentPage
    {
        public EditDevicePage(BabyMobile.Models.Device device)
        {
            var editDeviceViewModel = new EditDeviceViewModel();

            editDeviceViewModel.Device = device;

            BindingContext = editDeviceViewModel;
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new DevicesPage()));
        }
    }
}