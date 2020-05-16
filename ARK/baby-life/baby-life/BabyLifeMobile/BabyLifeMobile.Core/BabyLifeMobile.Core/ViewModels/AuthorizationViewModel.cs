namespace BabyLifeMobile.Core.ViewModels
{
    using BabyLifeMobile.Core.Models;
    using BabyLifeMobile.Core.Models.Enums;
    using BabyLifeMobile.Core.Provider;
    using CommonServiceLocator;
    using GalaSoft.MvvmLight.Command;
    using Newtonsoft.Json;
    using System.Net;
    using constants = BabyLifeMobile.Core.Models.Constants;

    public class AuthorizationViewModel : BaseViewModel
    {
        private const string LoginHttpQuery = "api/Account/login";
        private const string LogoutHttpQuery = "api/Account/logout";

        private bool isUserAuthorized;

        public AuthorizationViewModel()
        {
            this.LoginCommand = new RelayCommand(this.LoginExecute, !isUserAuthorized);
            this.LogoutCommand = new RelayCommand(this.LogOutExecute, isUserAuthorized);
            this.AuthModel = new AuthModel();
        }

        public AuthModel AuthModel { get; set; }

        public RelayCommand LoginCommand { get; private set; }
        public RelayCommand LogoutCommand { get; private set; }

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

        private async void LoginExecute()
        {
            var loginURL = constants.Constants.ServerHostURL + LoginHttpQuery;
            var json = JsonConvert.SerializeObject(this.AuthModel);
            var responseResult = await ServerProvider.Post(json, loginURL);
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
                ServiceLocator.Current.GetInstance<MainNavigationViewModel>().ViewType = ViewType.MainAuthorizedView;
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
                ServiceLocator.Current.GetInstance<MainNavigationViewModel>().ViewType = ViewType.AuthorizationView;
            }
        }
    }
}
