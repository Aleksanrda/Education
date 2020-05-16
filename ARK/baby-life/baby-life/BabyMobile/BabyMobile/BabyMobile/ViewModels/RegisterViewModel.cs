using Android.Content.Res;
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
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using constants = BabyMobile.Models.Constants;

namespace BabyMobile.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        private bool isErrorOccured;
        ApiServices _apiServices = new ApiServices();

        public string Email { get; set; }

        public DateTime Year { get; set; }

        public string Password { get; set; }

        public string PasswordConfirm { get; set; }

        public string Message { get; set; }

        public ICommand RegisterCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var response = await _apiServices.RegisterAsync(Email, Password, PasswordConfirm);

                    try
                    {
                        var token = JsonConvert.DeserializeObject<JwtToken>(response);
                        ServiceLocator.Current.GetInstance<UserViewModel>().JwtToken = token;
                        this.IsErrorOccured = false;
                    }
                    catch
                    {
                        this.IsErrorOccured = true;
                    }

                    if (this.IsErrorOccured)
                    {
                        ServiceLocator.Current.GetInstance<MainNavigationViewModel>().ViewType = ViewType.LoginPage;
                    }
                    else
                    {
                        RegisterPage registerPage = new RegisterPage();
                        ServiceLocator.Current.GetInstance<MainNavigationViewModel>().ViewType = ViewType.MainPage;
                        await registerPage.Button_Clicked_Register();
                    }
                });
            }
        }

        public bool IsErrorOccured
        {
            get
            {
                return this.isErrorOccured;
            }
            set
            {
                if (this.isErrorOccured != value)
                {
                    this.isErrorOccured = value;
                    this.OnPropertyChanged();
                }
            }
        }
    }
}
