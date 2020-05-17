using BabyMobile.Models;
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
    public partial class LoginCarePersonPage : ContentPage
    {
        public LoginCarePersonPage()
        {
            InitializeComponent();
        }

        public async void Button_Clicked_Login(object sender, EventArgs e)
        {
            var resultShareCode = shareCodeEntry.Text;
            var convertShareCode = Convert.ToInt32(resultShareCode);
            AuthCarePersonModel authCarePersonModel = new AuthCarePersonModel()
            {
                ShareCode = convertShareCode
            };

            await LoginCarePerson(authCarePersonModel);
        }

        public async Task LoginCarePerson(AuthCarePersonModel authCarePersonModel)
        {
            AuthCarePersonViewModel authCarePersonViewModel = new AuthCarePersonViewModel();
            authCarePersonViewModel.ShareCode = authCarePersonModel.ShareCode;

            await authCarePersonViewModel.LoginCareUser(authCarePersonModel);

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
            await Navigation.PushModalAsync(new NavigationPage(new RegisterPage()));
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new LoginPage()));
        }
    }
}