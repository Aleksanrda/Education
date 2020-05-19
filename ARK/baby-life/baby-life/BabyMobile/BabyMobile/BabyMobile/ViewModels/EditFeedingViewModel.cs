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
    public class EditFeedingViewModel : INotifyPropertyChanged
    {
        ApiServices apiServices = new ApiServices();

        private string _deleteMessage;
        private string _message;

        public Feeding Feeding { get; set; }

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
                    var babyId = ServiceLocator.Current.GetInstance<BabyFeedingViewModel>().BabyFeedingModel.Id;
                    var httpPutFeedingUrl = string.Format("{0}{1}/{2}", "https://06b9d5c2.ngrok.io/", "api/Feedings", babyId);

                    var response = await apiServices.PutFeedingAsync(Feeding, httpPutFeedingUrl);

                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        Message = "You edited feeding successfully";
                    }
                    else
                    {
                        Message = "Try edited feeding again later";
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
                    var feedingId = Feeding.Id;
                    var httpDeleteFeedingUrl = string.Format("{0}{1}/{2}", "https://06b9d5c2.ngrok.io/", "api/Feedings", feedingId);

                    var isSuccess = await apiServices.DeleteFeedingAsync(httpDeleteFeedingUrl);

                    if (isSuccess == true)
                    {
                        DeleteMessage = "You successfully deleted feeding";
                    }
                    else
                    {
                        DeleteMessage = "Try to delete feeding later, please!";
                    }
                });
            }
        }
    }
}
