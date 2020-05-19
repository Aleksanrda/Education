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
    public class ReminderViewModel : INotifyPropertyChanged
    {
        ApiServices _apiServices = new ApiServices();

        private List<Reminder> _reminders;

        public List<Reminder> Reminders
        {
            get { return _reminders; }
            set
            {
                _reminders = value;
                OnPropertyChanged();
            }
        }

        public ICommand GetRemindersCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var userId = ServiceLocator.Current.GetInstance<UserViewModel>().User.UserId;
                    var httpGetUserBabiesUrl = string.Format("{0}{1}/{2}", "https://06b9d5c2.ngrok.io/", "api/Reminders/userReminders", userId);
                    Reminders = await _apiServices.GetRemindersAsync(httpGetUserBabiesUrl);
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
