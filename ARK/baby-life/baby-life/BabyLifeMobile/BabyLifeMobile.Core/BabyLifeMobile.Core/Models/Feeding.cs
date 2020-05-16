namespace BabyLifeMobile.Core.Models
{
    using System;

    public class Feeding : ObservableObject
    {
        private int feedingId;
        private string name;
        private int countMilk;
        private DateTime timeMilk;
        private int deviceId;
        private Baby baby;

        public int FeedingId
        {
            get
            {
                return this.feedingId;
            }
            set
            {
                if (this.feedingId != value)
                {
                    this.feedingId = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (this.name != value)
                {
                    this.name = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public int CountMilk
        {
            get
            {
                return this.countMilk;
            }
            set
            {
                if (this.countMilk != value)
                {
                    this.countMilk = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public DateTime TimeMilk
        {
            get
            {
                return this.timeMilk;
            }
            set
            {
                if (this.timeMilk != value)
                {
                    this.timeMilk = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public int DeviceId
        {
            get
            {
                return this.deviceId;
            }
            set
            {
                if (this.deviceId != value)
                {
                    this.deviceId = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public Baby Baby
        {
            get
            {
                return this.baby;
            }
            set
            {
                if (this.baby != value)
                {
                    this.baby = value;
                    this.OnPropertyChanged();
                }
            }
        }
    }
}
