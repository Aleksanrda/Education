using BabyMobile.Models;
using BabyMobile.Models.Enums;
using BabyMobile.Provider;
using BabyMobile.Services;
using CommonServiceLocator;
using GalaSoft.MvvmLight.Command;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using constants = BabyMobile.Models.Constants;

namespace BabyMobile.ViewModels
{
    public class AuthCarePersonViewModel : BaseViewModel
    {
        private ApiServices _apiServices = new ApiServices();

        private bool isUserAuthorized;

        public int ShareCode { get; set; }

        public RelayCommand LogoutCommand { get; private set; }

        public AuthCarePersonViewModel()
        {
            this.LogoutCommand = new RelayCommand(this.LogOutExecute, isUserAuthorized);
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

        public async Task LoginCareUser(AuthCarePersonModel authCarePersonModel)
        {
            var responseResult = await _apiServices.LoginCarePersonAsync(authCarePersonModel.ShareCode);

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
                ServiceLocator.Current.GetInstance<MainNavigationViewModel>().ViewType = ViewType.MainPage;
            }
        }
    }
}
