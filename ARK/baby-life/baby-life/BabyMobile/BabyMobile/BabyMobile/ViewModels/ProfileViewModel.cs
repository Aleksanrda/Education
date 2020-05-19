using BabyMobile.Models;
using BabyMobile.Services;
using CommonServiceLocator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace BabyMobile.ViewModels
{
    public class ProfileViewModel : INotifyPropertyChanged
    {
        ApiServices _apiServices = new ApiServices();

        private Profile _profile;

        public Profile Profile
        {
            get { return _profile; }
            set
            {
                _profile = value;
                OnPropertyChanged();
            }
        }

        private string _message;

        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                OnPropertyChanged();
            }
        }

        public DateTime Birthday { get; set; }

        public string Email { get; set; }

        public int ShareCode { get; set; }

        public ICommand GetUserCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var userId = ServiceLocator.Current.GetInstance<UserViewModel>().User.UserId;
                    var httpGetUserBabiesUrl = string.Format("{0}{1}/{2}", "https://06b9d5c2.ngrok.io/", "api/Users", userId);
                    Profile = await _apiServices.GetUserAsync(httpGetUserBabiesUrl);
                });
            }
        }

        public ICommand EditCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var userId = ServiceLocator.Current.GetInstance<UserViewModel>().User.UserId;
                    var httpPutUserUrl = string.Format("{0}{1}/{2}", "https://06b9d5c2.ngrok.io/", "api/Users", userId);

                    var response = await _apiServices.PutProfileAsync(Profile, httpPutUserUrl);

                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        Message = "You edited profile successfully";
                    }
                    else
                    {
                        Message = "Try edited profile again";
                    }
                });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
