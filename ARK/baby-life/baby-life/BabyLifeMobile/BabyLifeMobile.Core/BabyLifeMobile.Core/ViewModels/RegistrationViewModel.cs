namespace BabyLifeMobile.Core.ViewModels
{
    using BabyLifeMobile.Core.Models;
    using BabyLifeMobile.Core.Models.Enums;
    using BabyLifeMobile.Core.Provider;
    using CommonServiceLocator;
    using GalaSoft.MvvmLight.Command;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Text;
    using constants = BabyLifeMobile.Core.Models.Constants;

    public class RegistrationViewModel : BaseViewModel
    {
        private const string RegisterHttpQuery = "api/Account/register";
        private UserRegisterRequestModel registerRequestModel;
        private bool isErrorOccured;
        private bool isRequestBusy;

        public RegistrationViewModel()
        {
            this.UserRegisterRequestModel = new UserRegisterRequestModel();
            this.RegisterCommand = new RelayCommand(this.RegisterExecute);
        }

        public RelayCommand RegisterCommand { get; private set; }

        public UserRegisterRequestModel UserRegisterRequestModel
        {
            get
            {
                return this.registerRequestModel;
            }
            set
            {
                if (this.registerRequestModel != value)
                {
                    this.registerRequestModel = value;
                    this.OnPropertyChanged();
                }
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

        private async void RegisterExecute()
        {
            var registerURL = constants.Constants.ServerHostURL + RegisterHttpQuery;

            var json = JsonConvert.SerializeObject(this.UserRegisterRequestModel);
            var responseResult = await ServerProvider.Post(json, registerURL);
            try
            {
                var token = JsonConvert.DeserializeObject<JwtToken>(responseResult);
                ServiceLocator.Current.GetInstance<UserViewModel>().JwtToken = token;
                this.IsErrorOccured = false;
            }
            catch
            {
                this.IsErrorOccured = true;
            }

            if (this.IsErrorOccured)
            {
                ServiceLocator.Current.GetInstance<MainNavigationViewModel>().ViewType = ViewType.AuthorizationView;
            }
            else
            {
                ServiceLocator.Current.GetInstance<MainNavigationViewModel>().ViewType = ViewType.MainAuthorizedView;
            }
        }
    }
}
