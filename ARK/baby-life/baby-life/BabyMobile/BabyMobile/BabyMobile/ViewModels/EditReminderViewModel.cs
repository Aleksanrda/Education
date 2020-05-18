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
    public class EditReminderViewModel : INotifyPropertyChanged
    {
        ApiServices apiServices = new ApiServices();

        private string _deleteMessage;
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

        public string DeleteMessage
        {
            get { return _deleteMessage; }
            set
            {
                _deleteMessage = value;
                OnPropertyChanged();
            }
        }

        public Reminder Reminder { get; set; }

        public ICommand EditCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var userId = ServiceLocator.Current.GetInstance<UserViewModel>().User.UserId;
                    var httpPutReminderUrl = string.Format("{0}{1}/{2}", "https://6a2e3bcd.ngrok.io/", "api/Reminders", userId);

                    var response = await apiServices.PutReminderAsync(Reminder, httpPutReminderUrl);

                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        Message = "You edited reminder successfully";
                    }
                    else
                    {
                        Message = "Try edited reminder again";
                    }
                });
            }
        }

        public ICommand DeleteCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var reminderId = Reminder.Id;
                    var httpPutReminderUrl = string.Format("{0}{1}/{2}", "https://6a2e3bcd.ngrok.io/", "api/Reminders", reminderId);

                    var isSuccess = await apiServices.DeleteReminderAsync(httpPutReminderUrl);

                    if (isSuccess == true)
                    {
                        DeleteMessage = "You successfully deleted reminder";
                    }
                    else
                    {
                        DeleteMessage = "Try to delete reminder later, please!";
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