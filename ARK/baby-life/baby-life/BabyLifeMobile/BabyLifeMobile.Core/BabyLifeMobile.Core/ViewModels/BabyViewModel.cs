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
    using System.Text;
    using System.Threading.Tasks;
    using constants = BabyLifeMobile.Core.Models.Constants;

    public class BabyViewModel : BaseViewModel
    {
        private const string BabyHttp = "api/Babies";
        private const string DeviceBabyHttp = "api/Devices/";

        private int selectedIndex;
        private Baby addingBaby;

        public BabyViewModel()
        {
            this.Babies = new ObservableCollection<Baby>();
            this.AddingBaby = new Baby();
            //this.AddBabyCommand = new RelayCommand(this.AddBabyExecute);
            //this.DeleteBabyCommand = new RelayCommand(this.DeleteBabyExecute);
            //this.GetActiveBabyCommand = new RelayCommand(this.GetActiveBabyExecute);
        }

        public ObservableCollection<Baby> Babies { get; set; }

        public RelayCommand AddBabyCommand { get; private set; }

        public RelayCommand DeleteBabyCommand { get; private set; }

        public RelayCommand GetActiveBabyCommand { get; private set; }

        public Baby AddingBaby
        {
            get
            {
                return this.addingBaby;
            }
            set
            {
                if (this.addingBaby != value)
                {
                    this.addingBaby = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public Baby SelectedBaby
        {
            get
            {
                return this.Babies[this.selectedIndex];
            }
            set
            {
                if (this.Babies[this.selectedIndex] != value)
                {
                    this.Babies[this.selectedIndex] = value;
                    this.OnPropertyChanged(nameof(this.Babies));
                }
            }
        }

        public int SelectedIndex
        {
            get
            {
                return this.selectedIndex;
            }
            set
            {
                if (this.selectedIndex != value)
                {
                    this.selectedIndex = value;
                    this.OnPropertyChanged();
                }
            }
        }

        //private async void GetActiveBabyExecute()
        //{
        //    var device = ServiceLocator.Current.GetInstance<DeviceViewModel>().SelectedDevice;
        //    var deviceId = device.DeviceId;
        //    var devicePoint = new Point()
        //    {
        //        X = 49.993499,
        //        Y = 36.230376
        //    };

        //    var babies = await this.GetAllBabies();

        //    for (int i = this.Babies.Count - 1; i >= 0; i++)
        //    {
        //        this.Babies.RemoveAt(i);
        //    }

        //    foreach (var baby in babies)
        //    {
        //        this.Babies.Add(baby);
        //    }
        //}

        private async Task<List<Baby>> GetActiveBaby(int deviceId, Point location)
        {
            var activeTrashCans = new List<Baby>();
            var httpQuery = string.Format("{0}{1}{2}", constants.Constants.ServerHostURL, BabyHttp, deviceId);
            var json = JsonConvert.SerializeObject(location);
            var serverResponse = await ServerProvider.Post(json, httpQuery);
            try
            {
                var nearestTrashCans = JsonConvert.DeserializeObject<List<Baby>>(serverResponse);
                activeTrashCans = nearestTrashCans;
            }
            catch
            {
                Debug.WriteLine("Get active babies failed.");
            }
            return activeTrashCans;
        }

        //private async Task<List<Baby>> GetAllBabies()
        //{
        //    var device = ServiceLocator.Current.GetInstance<DeviceViewModel>().SelectedDevice;
        //    var deviceId = device.DeviceId;
        //    var deviceTrashCans = new List<Baby>();
        //    var httpQuery = string.Format("{0}{1}", constants.Constants.ServerHostURL, BabyHttp);
        //    var serverResponse = await ServerProvider.Get(httpQuery);
        //    try
        //    {
        //        var allBabies = JsonConvert.DeserializeObject<List<Baby>>(serverResponse);
        //        deviceTrashCans = allBabies.Where(x => x.DeviceId == deviceId).ToList();
        //    }
        //    catch
        //    {
        //        Debug.WriteLine("Get all trash cans failed.");
        //    }
        //    return deviceTrashCans;
        //}

        //private async void AddBabyExecute()
        //{
        //    var addTrashCanHttpQuery = constants.Constants.ServerHostURL + BabyHttp;
        //    this.AddingBaby.DeviceId = ServiceLocator.Current.GetInstance<DeviceViewModel>().SelectedDevice.DeviceId;

        //    var trashCanJson = JsonConvert.SerializeObject(this.addingBaby);
        //    var serverResponse = await ServerProvider.Post(trashCanJson, addTrashCanHttpQuery);
        //    try
        //    {
        //        var trashCanFromJson = JsonConvert.DeserializeObject<Baby>(serverResponse);
        //        this.AddingBaby = new Baby();
        //    }
        //    catch
        //    {
        //        Debug.WriteLine("Add trash can failed");
        //    }
        //}

        //private async void DeleteBabyExecute()
        //{
        //    var deleteTrashCanHttp = string.Format("{0}{1}/{2}", constants.Constants.ServerHostURL, BabyHttp, this.SelectedTrashCan.TrashCanId);
        //    var serverResponse = await ServerProvider.Delete(deleteTrashCanHttp);
        //}
    }
}
