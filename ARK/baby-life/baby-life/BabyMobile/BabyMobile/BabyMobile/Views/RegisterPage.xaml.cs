using BabyMobile.Models.Enums;
using BabyMobile.ViewModels;
using CommonServiceLocator;
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
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        public async Task Button_Clicked_Register()
        {
            var viewModel = ServiceLocator.Current.GetInstance<MainNavigationViewModel>();
            var typeValue = viewModel.ViewType;
            Type type = typeof(LoginPage);
            switch (typeValue)
            {
                case ViewType.LoginPage:
                    type = typeof(LoginPage);
                    await Navigation.PushAsync(new LoginPage());
                    break;
                case ViewType.RegisterPage:
                    type = typeof(RegisterPage);
                    await Navigation.PushAsync(new RegisterPage());
                    break;
                case ViewType.MainPage:
                    type = typeof(MainPage);
                    await Navigation.PushAsync(new MainPage());
                    break;
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }
    }
}