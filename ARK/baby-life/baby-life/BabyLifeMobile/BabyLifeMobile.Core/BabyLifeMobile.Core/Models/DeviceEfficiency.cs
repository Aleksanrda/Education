namespace BabyLifeMobile.Core.Models
{
    public class DeviceEfficiency : ObservableObject
    {
        private int deviceId;
        private double givenValue;

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

        public double Value
        {
            get
            {
                return this.givenValue;
            }
            set
            {
                if (this.givenValue != value)
                {
                    this.givenValue = value;
                    this.OnPropertyChanged();
                }
            }
        }
    }
}
