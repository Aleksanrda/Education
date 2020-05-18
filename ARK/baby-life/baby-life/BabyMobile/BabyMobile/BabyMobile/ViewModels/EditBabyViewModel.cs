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
    public class EditBabyViewModel : INotifyPropertyChanged
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

        public Baby Baby { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand EditCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var userId = ServiceLocator.Current.GetInstance<UserViewModel>().User.UserId;
                    var httpPutBabyUrl = string.Format("{0}{1}/{2}", "https://6a2e3bcd.ngrok.io/", "api/Babies", userId);

                    var response = await apiServices.PutBabyAsync(Baby, httpPutBabyUrl);

                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        Message = "You edited baby successfully";
                    }
                    else
                    {
                        Message = "Try edited baby again";
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
                    var babyId = Baby.Id;
                    var httpPutBabyUrl = string.Format("{0}{1}/{2}", "https://6a2e3bcd.ngrok.io/", "api/Babies", babyId);

                    var isSuccess = await apiServices.DeleteBabyAsync(httpPutBabyUrl);

                    if (isSuccess == true)
                    {
                        DeleteMessage = "You successfully deleted baby";
                    }
                    else
                    {
                        DeleteMessage = "Try to delete baby later, please!";
                    }
                });
            }
        }
    }
}
