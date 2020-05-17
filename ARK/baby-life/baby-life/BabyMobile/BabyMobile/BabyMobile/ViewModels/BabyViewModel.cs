using Android.Util;
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
    public class BabyViewModel : INotifyPropertyChanged
    {
        ApiServices _apiServices = new ApiServices();
        private List<Baby> _babies;

        public List<Baby> Babies 
        {
            get { return _babies;  } 
            set
            { 
                _babies = value;
                OnPropertyChanged();
            } 
        }

        public ICommand GetBabiesCommand
        {
            get
            {
                return new Command(async() =>
                {
                    var userId = ServiceLocator.Current.GetInstance<UserViewModel>().User.UserId;
                    var httpGetUserBabiesUrl = string.Format("{0}{1}/{2}", "https://88346a15.ngrok.io/", "api/Babies/userBabies/", userId);
                    Babies = await _apiServices.GetBabiesAsync(httpGetUserBabiesUrl);
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
