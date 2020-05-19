using BabyMobile;
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
    public class DeviceViewModel : INotifyPropertyChanged
    {
        ApiServices _apiServices = new ApiServices();
        private List<BabyMobile.Models.Device> _devices;

        public List<BabyMobile.Models.Device> Devices
        {
            get { return _devices; }
            set
            {
                _devices = value;
                OnPropertyChanged();
            }
        }

        public ICommand GetDevicesCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var httpGetUserDevicesUrl = string.Format("{0}{1}", "https://06b9d5c2.ngrok.io/", "api/Device");
                    Devices = await _apiServices.GetDevicesAsync(httpGetUserDevicesUrl);
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
