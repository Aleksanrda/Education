using BabyMobile.Models;
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
    public partial class EditReminderPage : ContentPage
    {
        public EditReminderPage(Reminder reminder)
        {
            var editReminderViewModel = new EditReminderViewModel();

            editReminderViewModel.Reminder = reminder;

            BindingContext = editReminderViewModel;

            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new RemindersPage()));
        }
    }
}