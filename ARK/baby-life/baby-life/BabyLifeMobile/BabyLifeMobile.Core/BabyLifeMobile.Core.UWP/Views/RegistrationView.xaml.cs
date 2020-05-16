namespace BabyLifeMobile.Core.UWP.Views
{
    using BabyLifeMobile.Core.Models.Enums;
    using BabyLifeMobile.Core.ViewModels;
    using CommonServiceLocator;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.InteropServices.WindowsRuntime;
    using Windows.Foundation;
    using Windows.Foundation.Collections;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Controls.Primitives;
    using Windows.UI.Xaml.Data;
    using Windows.UI.Xaml.Input;
    using Windows.UI.Xaml.Media;
    using Windows.UI.Xaml.Navigation;

    public sealed partial class RegistrationView : Page
    {
        public RegistrationView()
        {
            this.InitializeComponent();
        }

        private void NavigateToLogIn(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            ServiceLocator.Current.GetInstance<MainNavigationViewModel>().ViewType = ViewType.AuthorizationView;
        }
    }
}
