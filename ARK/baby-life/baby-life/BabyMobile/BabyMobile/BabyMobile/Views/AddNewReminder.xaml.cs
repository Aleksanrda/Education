﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BabyMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddNewReminder : ContentPage
    {
        public AddNewReminder()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new RemindersPage()));
        }
    }
}