namespace BabyLifeMobile.Core.Models
{
    public class Device : ObservableObject
    {
        private int deviceId;
        private double actionRange;
        private double maxVolume;
        private double maxWeight;
        private User owner;

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

        public double ActionRange
        {
            get
            {
                return this.actionRange;
            }
            set
            {
                if (this.actionRange != value)
                {
                    this.actionRange = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public double MaxVolume
        {
            get
            {
                return this.maxVolume;
            }
            set
            {
                if (this.maxVolume != value)
                {
                    this.maxVolume = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public double MaxWeight
        {
            get
            {
                return this.maxWeight;
            }
            set
            {
                if (this.maxWeight != value)
                {
                    this.maxWeight = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public User Owner
        {
            get
            {
                return this.owner;
            }
            set
            {
                if (this.owner != value)
                {
                    this.owner = value;
                    this.OnPropertyChanged();
                }
            }
        }
    }
}
