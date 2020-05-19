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
    public class AddFeedingViewModel : INotifyPropertyChanged
    {
        ApiServices apiServices = new ApiServices();

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

        public string Name { get; set; }

        public int CountMilk { get; set; }

        public DateTime TimeMilk { get; set; }

        public int DeviceId { get; set; }

        public ICommand AddCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var feeding = new Feeding()
                    {
                        Name = Name,
                        CountMilk = CountMilk,
                        TimeMilk = TimeMilk,
                        DeviceId = DeviceId,
                    };

                   // var userId = ServiceLocator.Current.GetInstance<UserViewModel>().User.UserId;
                    var babyId = ServiceLocator.Current.GetInstance<BabyFeedingViewModel>().BabyFeedingModel.Id;

                    var httpGetUserBabiesUrl = string.Format("{0}{1}/{2}", "https://06b9d5c2.ngrok.io/", "api/Feedings", babyId);

                    var isSuccess = await apiServices.PostFeedingAsync(feeding, httpGetUserBabiesUrl);

                    if (isSuccess)
                    {
                        Message = "You added feeding successfully";
                    }
                    else
                    {
                        Message = "Try add feeding later again";
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
