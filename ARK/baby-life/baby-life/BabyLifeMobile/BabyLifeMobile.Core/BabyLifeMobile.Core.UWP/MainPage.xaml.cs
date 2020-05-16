using BabyLifeMobile.Core.Models.Enums;
using BabyLifeMobile.Core.UWP.Views;
using BabyLifeMobile.Core.ViewModels;
using CommonServiceLocator;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace BabyLifeMobile.Core.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();
            ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size(320, 500));
            this.MainFrame.Navigate(typeof(AuthoriztionView));
        }

        private void Navigate(TextBox sender, TextBoxTextChangingEventArgs args)
        {
            var viewModel = ServiceLocator.Current.GetInstance<MainNavigationViewModel>();
            var typeValue = viewModel.ViewType;
            Type type = typeof(AuthoriztionView);
            switch (typeValue)
            {
                case ViewType.AuthorizationView:
                    type = typeof(AuthoriztionView);
                    break;
                case ViewType.RegistrationView:
                    type = typeof(RegistrationView);
                    break;
                case ViewType.MainAuthorizedView:
                    type = typeof(MainAuthorizedView);
                    break;
            }
            this.MainFrame.Navigate(type);
        }
    }
}
