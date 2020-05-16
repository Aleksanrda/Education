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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace BabyLifeMobile.Core.UWP.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AuthoriztionView : Page
    {
        public AuthoriztionView()
        {
            this.InitializeComponent();
        }

        private void NavigateToRegistration(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            ServiceLocator.Current.GetInstance<MainNavigationViewModel>().ViewType = ViewType.RegistrationView;
        }
    }
}
