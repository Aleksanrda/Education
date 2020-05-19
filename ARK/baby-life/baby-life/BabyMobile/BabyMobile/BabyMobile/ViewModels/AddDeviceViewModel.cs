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
    public class AddDeviceViewModel : INotifyPropertyChanged
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

        public int MaxVolume { get; set; }

        public int MaxWeight { get; set; }

        public ICommand AddCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var device = new BabyMobile.Models.Device()
                    {
                        Name = Name,
                        MaxVolume = MaxVolume,
                        MaxWeight = MaxWeight,
                    };

                    var httpAddDeviceUrl = string.Format("{0}{1}", "https://06b9d5c2.ngrok.io/", "api/Device");

                    var isSuccess = await apiServices.PostDeviceAsync(device, httpAddDeviceUrl);

                    if (isSuccess)
                    {
                        Message = "You added device successfully";
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
