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
    public partial class EditBabyPage : ContentPage
    {
        public EditBabyPage(Baby baby)
        {
            var editBabyViewModel = new EditBabyViewModel();

            editBabyViewModel.Baby = baby;

            BindingContext = editBabyViewModel;

            InitializeComponent();

            //var editBabyViewModel = BindingContext as EditBabyViewModel;

            //editBabyViewModel.Baby = baby;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new BabiesPage()));
        }

        private async void AddNewFeedingButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new AddFeedingPage()));
        }

        private async void FeedingsListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var feeding = e.Item as Feeding;
            await Navigation.PushModalAsync(new NavigationPage(new EditFeedingPage(feeding)));
        }
    }
}