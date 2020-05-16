namespace BabyLifeMobile.Core.ViewModels
{
    using BabyLifeMobile.Core.Models;
    using BabyLifeMobile.Core.Provider;
    using CommonServiceLocator;
    using GalaSoft.MvvmLight.Command;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.Linq;
    using constants = BabyLifeMobile.Core.Models.Constants;

    public class DeviceViewModel : BaseViewModel
    {
        private const string DevicesHttpUrl = "api/Devices";
        private BabyViewModel babyViewModel;
        private int selectedDeviceIndex;
        private Device addingDevice;

        public DeviceViewModel()
        {
            this.Devices = new ObservableCollection<Device>();
            this.DevicesEfficiency = new ObservableCollection<DeviceEfficiency>();
            this.AddingDevice = new Device();
            this.AddDeviceCommand = new RelayCommand(this.AddDeviceExecute);
            this.GetDevices();
            this.BabyViewModel = new BabyViewModel();
            this.GetEfficiency();
        }

        public RelayCommand AddDeviceCommand { get; private set; }

        public RelayCommand DeleteCommand { get; private set; }

        public RelayCommand ShowAllBabies { get; set; }

 //       public RelayCommand ShowActiveTrashCans { get; set; }

        public ObservableCollection<Device> Devices { get; set; }

        public ObservableCollection<DeviceEfficiency> DevicesEfficiency { get; set; }

        public int SelectedDeviceIndex
        {
            get
            {
                return this.selectedDeviceIndex;
            }
            set
            {
                if (this.selectedDeviceIndex != value)
                {
                    this.selectedDeviceIndex = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public Device SelectedDevice
        {
            get
            {
                return this.Devices[selectedDeviceIndex];
            }
            set
            {
                if (this.Devices[selectedDeviceIndex] != value)
                {
                    this.Devices[selectedDeviceIndex] = value;
                    this.OnPropertyChanged(nameof(this.Devices));
                    this.OnPropertyChanged();
                }
            }
        }

        public Device AddingDevice
        {
            get
            {
                return this.addingDevice;
            }
            set
            {
                if (this.addingDevice != value)
                {
                    this.addingDevice = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public BabyViewModel BabyViewModel
        {
            get
            {
                return this.babyViewModel;
            }
            set
            {
                if (this.babyViewModel != value)
                {
                    this.babyViewModel = value;
                    this.OnPropertyChanged();
                }
            }
        }

        private async void GetDevices()
        {
            var getAllDevicesHttpUrl = constants.Constants.ServerHostURL + DevicesHttpUrl;
            var jsonDevices = await ServerProvider.Get(getAllDevicesHttpUrl);
            try
            {
                var userId = ServiceLocator.Current.GetInstance<UserViewModel>().User.UserId;
                var devicesList = JsonConvert.DeserializeObject<List<Device>>(jsonDevices);
                var userDevices = devicesList.Where(x => x.Owner.UserId == userId).ToList(); ;
                foreach (var device in userDevices)
                {
                    this.Devices.Add(device);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("GetDevices ERROR:" + ex.Message);
            }
        }

        private async void AddDeviceExecute()
        {
            var devicesHttpUrl = constants.Constants.ServerHostURL + DevicesHttpUrl;
            this.AddingDevice.Owner = ServiceLocator.Current.GetInstance<UserViewModel>().User;
            var json = JsonConvert.SerializeObject(this.AddingDevice);
            var response = await ServerProvider.Post(json, devicesHttpUrl);
            try
            {
                var deviceFromJson = JsonConvert.DeserializeObject<Device>(response);
                this.Devices.Add(deviceFromJson);
                this.AddingDevice = new Device();
                this.GetEfficiency();
            }
            catch
            {
                Debug.WriteLine("Device adding failed.");
            }
        }

        private async void DeleteExecute()
        {
            var httpDeleteUrl = string.Format("{0}{1}/{2}", constants.Constants.ServerHostURL, DevicesHttpUrl, this.SelectedDevice.DeviceId);
            var response = await ServerProvider.Delete(httpDeleteUrl);

            try
            {
                var deviceFromJson = JsonConvert.DeserializeObject<Device>(response);
                this.Devices.RemoveAt(selectedDeviceIndex);
                if (this.SelectedDeviceIndex > 0)
                {
                    this.SelectedDeviceIndex--;
                }
            }
            catch
            {
                Debug.WriteLine("Device deleting failed.");
            }
        }

        private async void GetEfficiency()
        {
            foreach (var efficiency in this.DevicesEfficiency)
            {
                this.DevicesEfficiency.Remove(efficiency);
            }

            var deviceEfficiencyHttpQuery = string.Format("{0}{1}/{2}/", constants.Constants.ServerHostURL, DevicesHttpUrl, "Efficiency");
            foreach (var device in this.Devices)
            {
                var http = deviceEfficiencyHttpQuery + device.DeviceId;
                var response = await ServerProvider.Get(http);
                try
                {
                    var value = JsonConvert.DeserializeObject<double>(response);
                    this.DevicesEfficiency.Add(new DeviceEfficiency()
                    {
                        DeviceId = device.DeviceId,
                        Value = value
                    });
                }
                catch { }
            }
        }
    }
}
