using BabyMobile.Models;
using BabyMobile.Models.Enums;
using BabyMobile.ViewModels;
using CommonServiceLocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
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

        public async void Button_Clicked(object sender, EventArgs e)
        {
            RegisterModel registerModel = new RegisterModel()
            {
                Email = emailEntry.Text,
                Year = yearEntry.Date,
                Password = passwordEntry.Text,
                PasswordConfirm = confirmPasswordEntry.Text
            };
            await Register(registerModel); 
            // await Navigation.PushAsync(new LoginPage());
        }

        //public ICommand Get { get; set; }
        //public ICommand Register
        //{
        //    get
        //    {
        //        return new Command(async () =>
        //        {
        //            var m = ServiceLocator.Current.GetInstance<RegisterViewModel>();
        //            await m.RegisterUser();

        //            var viewModel = ServiceLocator.Current.GetInstance<MainNavigationViewModel>();
        //            var typeValue = viewModel.ViewType;
        //            Type type = typeof(LoginPage);
        //            switch (typeValue)
        //            {
        //                case ViewType.LoginPage:
        //                    type = typeof(LoginPage);
        //                    await Navigation.PushAsync(new LoginPage());
        //                    break;
        //                case ViewType.RegisterPage:
        //                    type = typeof(RegisterPage);
        //                    await Navigation.PushAsync(new RegisterPage());
        //                    break;
        //                case ViewType.MainPage:
        //                    type = typeof(MainPage);
        //                    await Navigation.PushAsync(new MainPage());
        //                    break;
        //            }
        //        });
        //    }
        //}

        public async Task Register(RegisterModel registerModel)
        {
            RegisterViewModel registerViewModel = new RegisterViewModel();
            registerModel.Email = registerModel.Email;
            registerModel.Password = registerModel.Password;
            registerModel.PasswordConfirm = registerModel.PasswordConfirm;
            await registerViewModel.RegisterUser(registerModel);

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

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new LoginPage()));
        }
    }
}