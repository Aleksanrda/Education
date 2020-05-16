namespace BabyLifeMobile.Core.Models
{
    using System.ComponentModel.DataAnnotations;

    public class AuthModel : ObservableObject
    {
        private string email;
        private string password;
        private bool rememberMe;

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

        [DataType(DataType.Password)]
        public string Password
        {
            get
            {
                return this.password;
            }
            set
            {
                if (this.password != value)
                {
                    this.password = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public bool RememberMe;
    }
}
