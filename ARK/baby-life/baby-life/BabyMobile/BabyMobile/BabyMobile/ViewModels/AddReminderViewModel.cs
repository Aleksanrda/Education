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
    public class AddReminderViewModel : INotifyPropertyChanged
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

        public string ReminderType { get; set; }

        public DateTime ReminderTime { get; set; }

        public string Infa { get; set; }

        public ICommand AddCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var reminder = new Reminder()
                    {
                        ReminderType = ReminderType,
                        ReminderTime = ReminderTime,
                        Infa = Infa,
                    };

                    var userId = ServiceLocator.Current.GetInstance<UserViewModel>().User.UserId;
                    var httpGetUserBabiesUrl = string.Format("{0}{1}/{2}", "https://6a2e3bcd.ngrok.io/", "api/Reminders", userId);

                    var isSuccess = await apiServices.PostReminderAsync(reminder, httpGetUserBabiesUrl);

                    if (isSuccess)
                    {
                        Message = "You added baby successfully";
                    }
                    else
                    {
                        Message = "Try again";
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
