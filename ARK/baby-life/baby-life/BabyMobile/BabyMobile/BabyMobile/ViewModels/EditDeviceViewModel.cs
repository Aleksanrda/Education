using BabyMobile.Models;
using BabyMobile.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace BabyMobile.ViewModels
{
    public class EditDeviceViewModel : INotifyPropertyChanged
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

        public BabyMobile.Models.Device Device { get; set; }

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
                    var httpPutDeviceUrl = string.Format("{0}{1}", "https://06b9d5c2.ngrok.io/", "api/Device");

                    var response = await apiServices.PutDeviceAsync(Device, httpPutDeviceUrl);

                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        Message = "You edited device successfully";
                    }
                    else
                    {
                        Message = "Try edited device again";
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
                    var deviceId = Device.Id;
                    var httpDeleteDeviceUrl = string.Format("{0}{1}/{2}", "https://06b9d5c2.ngrok.io/", "api/Device", deviceId);

                    var isSuccess = await apiServices.DeleteDeviceAsync(httpDeleteDeviceUrl);

                    if (isSuccess == true)
                    {
                        DeleteMessage = "You successfully deleted device";
                    }
                    else
                    {
                        DeleteMessage = "Try to delete device later, please!";
                    }
                });
            }
        }

    }
}
