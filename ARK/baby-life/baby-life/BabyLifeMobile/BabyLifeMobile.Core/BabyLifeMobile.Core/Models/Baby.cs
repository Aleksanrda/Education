namespace BabyLifeMobile.Core.Models
{
    using BabyLifeMobile.Core.Models.Enums;

    public class Baby : ObservableObject
    {
        private int babyId;
        private string name;
        private GenderTypes genderType;
        private string bloodType;
        private string allergies;
        private string notes;
        private User owner;
        private double longtitude;
        private double latitude;

        public int BabyId
        {
            get
            {
                return this.babyId;
            }
            set
            {
                if (this.babyId != value)
                {
                    this.babyId = value;
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

        public GenderTypes GenderType
        {
            get
            {
                return this.genderType;
            }
            set
            {
                if (this.genderType != value)
                {
                    this.genderType = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public string BloodType
        {
            get
            {
                return this.bloodType;
            }
            set
            {
                if (this.bloodType != value)
                {
                    this.bloodType = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public string Allergies
        {
            get
            {
                return this.allergies;
            }
            set
            {
                if (this.allergies != value)
                {
                    this.allergies = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public string Notes
        {
            get
            {
                return this.notes;
            }
            set
            {
                if (this.notes != value)
                {
                    this.notes = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public double Longtitude
        {
            get
            {
                return this.longtitude;
            }
            set
            {
                if (this.longtitude != value)
                {
                    this.longtitude = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public double Latitude
        {
            get
            {
                return this.latitude;
            }
            set
            {
                if (this.latitude != value)
                {
                    this.latitude = value;
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
