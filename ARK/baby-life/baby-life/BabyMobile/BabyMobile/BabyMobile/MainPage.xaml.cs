using BabyMobile.Models.Enums;
using BabyMobile.ViewModels;
using BabyMobile.Views;
using CommonServiceLocator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BabyMobile
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            ToolbarItem profile = new ToolbarItem
            {
                Text = "Profile",
                Order = ToolbarItemOrder.Primary,
                Priority = 1
            };

            ToolbarItem babies = new ToolbarItem
            {
                Text = "Babies",
                Order = ToolbarItemOrder.Secondary,
                Priority = 2
            };

            ToolbarItem reminders = new ToolbarItem
            {
                Text = "Reminders",
                Order = ToolbarItemOrder.Secondary,
                Priority = 3
            };

            ToolbarItem devices = new ToolbarItem
            {
                Text = "Devices",
                Order = ToolbarItemOrder.Secondary,
                Priority = 4
            };

            ToolbarItem feedings = new ToolbarItem
            {
                Text = "Feedings",
                Order = ToolbarItemOrder.Secondary,
                Priority = 5
            };

            ToolbarItem logout = new ToolbarItem
            {
                Text = "Logout",
                Order = ToolbarItemOrder.Secondary,
                Priority = 6
            };

            babies.Clicked += async (s, e) =>
            {
                await Navigation.PushModalAsync(new NavigationPage(new BabiesPage()));
            };

            logout.Clicked += async (s, e) =>
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
                        break;
                    case ViewType.MainPage:
                        type = typeof(MainPage);
                        break;
                }
            };

            ToolbarItems.Add(babies);
            ToolbarItems.Add(reminders);
            ToolbarItems.Add(devices);
            ToolbarItems.Add(feedings);
            ToolbarItems.Add(logout);
        }
    }
}
