using BabyMobile.Models;
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
    public partial class RemindersPage : ContentPage
    {
        public RemindersPage()
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

            reminders.Clicked += async (s, e) =>
            {
                await Navigation.PushModalAsync(new NavigationPage(new RemindersPage()));
            };

            ToolbarItems.Add(profile);
            ToolbarItems.Add(babies);
            ToolbarItems.Add(reminders);
            ToolbarItems.Add(devices);
            ToolbarItems.Add(feedings);
            ToolbarItems.Add(logout);
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new AddNewReminder()));
        }

        private async void RemindersListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var reminder = e.Item as Reminder;
            await Navigation.PushModalAsync(new NavigationPage(new EditReminderPage(reminder)));
        }
    }
}