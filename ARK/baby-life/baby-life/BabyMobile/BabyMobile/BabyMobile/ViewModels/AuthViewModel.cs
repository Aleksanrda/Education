using BabyMobile.Models;
using BabyMobile.Models.Enums;
using BabyMobile.Provider;
using BabyMobile.Services;
using BabyMobile.Views;
using CommonServiceLocator;
using GalaSoft.MvvmLight.Command;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using constants = BabyMobile.Models.Constants;

namespace BabyMobile.ViewModels
{
    public class AuthViewModel : BaseViewModel
    {
        private bool isUserAuthorized;

        private ApiServices _apiServices = new ApiServices();

        public string Email { get; set; }

        public string Password { get; set; }
        public RelayCommand LogoutCommand { get; private set; }

        public AuthViewModel()
        {
            this.LogoutCommand = new RelayCommand(this.LogOutExecute, isUserAuthorized);
        }

        public ICommand LoginCommand
        {
            get
            {
                return new Command(async() =>
                {
                    var responseResult = await _apiServices.LoginAsync(Email, Password);

                    try
                    {
                        var token = JsonConvert.DeserializeObject<JwtToken>(responseResult);
                        ServiceLocator.Current.GetInstance<UserViewModel>().JwtToken = token;
                        this.IsUserAuthorized = true;
                    }
                    catch
                    {
                        this.IsUserAuthorized = false;
                    }
                    if (this.isUserAuthorized)
                    {
                        LoginPage loginPage = new LoginPage();
                        ServiceLocator.Current.GetInstance<MainNavigationViewModel>().ViewType = ViewType.MainPage;
                        await loginPage.Button_Clicked_Login();
                    }
                });
            }
        }

        public bool IsUserAuthorized
        {
            get
            {
                return this.isUserAuthorized;
            }
            set
            {
                if (this.isUserAuthorized != value)
                {
                    this.isUserAuthorized = value;
                    this.OnPropertyChanged();
                }
            }
        }

        private async void LogOutExecute()
        {
            var loginURL = constants.Constants.ServerHostURL + LogoutCommand;
            var responseStatus = await ServerProvider.Post(loginURL);
            this.IsUserAuthorized = !(responseStatus == HttpStatusCode.OK ||
                responseStatus == HttpStatusCode.Accepted ||
                responseStatus == HttpStatusCode.Created);
            if (!this.isUserAuthorized)
            {
                ServiceLocator.Current.GetInstance<MainNavigationViewModel>().ViewType = ViewType.LoginPage;
            }
        }
    }
}
