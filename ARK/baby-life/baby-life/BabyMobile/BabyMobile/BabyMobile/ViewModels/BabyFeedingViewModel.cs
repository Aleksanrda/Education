using BabyMobile.Models;
using BabyMobile.Models.Constants;
using BabyMobile.Provider;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BabyMobile.ViewModels
{
    public class BabyFeedingViewModel : BaseViewModel
    {
        private const string UserHttpQuery = "api/Feedings";

        private BabyFeedingModel babyFeedingModel;

        public BabyFeedingViewModel()
        {
            this.BabyFeedingModel = new BabyFeedingModel();
        }

        public BabyFeedingModel BabyFeedingModel
        {
            get
            {
                return this.babyFeedingModel;
            }
            set
            {
                if (this.babyFeedingModel != value)
                {
                    this.babyFeedingModel = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public async void SetBaby(int id)
        {
            var babyUrl = string.Format("{0}{1}/{2}", Constants.ServerHostURL, UserHttpQuery, id);
            var userBaby = await ServerProvider.Get(babyUrl);
            try
            {
                this.BabyFeedingModel = JsonConvert.DeserializeObject<BabyFeedingModel>(userBaby);
            }
            catch
            {
                //Debug.WriteLine("Set user failed.");
            }
        }
    }
}
