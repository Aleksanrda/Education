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
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();

            ToolbarItem login = new ToolbarItem
            {
                Text = "Login",
                Order = ToolbarItemOrder.Primary,
                Priority = 0
            };

            ToolbarItem loginCarePerson = new ToolbarItem
            {
                Text = "Login for care person",
                Order = ToolbarItemOrder.Secondary,
                Priority = 1
            };

            ToolbarItem register = new ToolbarItem
            {
                Text = "Register",
                Order = ToolbarItemOrder.Secondary,
                Priority = 2
            };

            ToolbarItems.Add(login);
            ToolbarItems.Add(loginCarePerson);
            ToolbarItems.Add(register);
        }

        public async Task Button_Clicked_Login()
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
    }
}