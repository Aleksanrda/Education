using System;
using System.Collections.Generic;
using System.Text;

namespace BabyMobile.Models
{
    public class BabyFeedingModel : ObservableObject
    {
        private int id;
        private string name;
        private string genderType;
        private string bloodType;
        private string allergies;
        private string notes;
        private int longtitude;
        private int latitude;
        
        public int Id
        {
            get
            {
                return this.id;
            }
            set
            {
                if (this.id != value)
                {
                    this.id = value;
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

        public string GenderType
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

        public int Longtitude
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

        public int Latitude
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
    }
}
