namespace BabyLifeMobile.Core.Models
{
    public class UserRegisterRequestModel : AuthModel
    {
        private string birthdate;

        public string Birthdate
        {
            get
            {
                return this.birthdate;
            }
            set
            {
                if (this.birthdate != value)
                {
                    this.birthdate = value;
                    this.OnPropertyChanged();
                }
            }
        }
    }
}
