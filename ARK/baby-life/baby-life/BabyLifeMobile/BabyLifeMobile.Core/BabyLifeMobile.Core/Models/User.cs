namespace BabyLifeMobile.Core.Models
{
    using System;

    public class User : ObservableObject
    {
        private string userId;
        private DateTime birthday;
        private string email;

        public string UserId
        {
            get
            {
                return this.userId;
            }
            set
            {
                if (this.userId != value)
                {
                    this.userId = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public DateTime Birthday
        {
            get
            {
                return this.birthday;
            }
            set
            {
                if (this.birthday != value)
                {
                    this.birthday = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public string Email
        {
            get
            {
                return this.email;
            }
            set
            {
                if (this.email != value)
                {
                    this.email = value;
                    this.OnPropertyChanged();
                }
            }
        }
    }
}