namespace BabyLifeMobile.Core.Models
{
    public class Point : ObservableObject
    {
        private double x;
        private double y;

        public double X
        {
            get
            {
                return this.x;
            }
            set
            {
                if (this.x != value)
                {
                    this.x = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public double Y
        {
            get
            {
                return this.y;
            }
            set
            {
                if (this.y != value)
                {
                    this.y = value;
                    this.OnPropertyChanged();
                }
            }
        }
    }
}
