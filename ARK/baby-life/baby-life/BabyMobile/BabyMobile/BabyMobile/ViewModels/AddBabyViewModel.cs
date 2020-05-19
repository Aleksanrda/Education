using BabyMobile.Models;
using BabyMobile.Services;
using CommonServiceLocator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace BabyMobile.ViewModels
{
    public class AddBabyViewModel : INotifyPropertyChanged
    {
        ApiServices apiServices = new ApiServices();

        private string _message;

        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                OnPropertyChanged();
            }
        }

        public string Name { get; set; }

        public string GenderType { get; set; }

        public string BloodType { get; set; }

        public string Allergies { get; set; }

        public string Notes { get; set; }

        public ICommand AddCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var baby = new Baby()
                    {
                        Name = Name,
                        GenderType = GenderType,
                        BloodType = BloodType,
                        Allergies = Allergies,
                        Notes = Notes,
                    };

                    var userId = ServiceLocator.Current.GetInstance<UserViewModel>().User.UserId;
                    var httpGetUserBabiesUrl = string.Format("{0}{1}/{2}", "https://06b9d5c2.ngrok.io/", "api/Babies", userId);

                    var isSuccess = await apiServices.PostBabyAsync(baby, httpGetUserBabiesUrl);

                    if (isSuccess)
                    {
                        Message = "You added baby successfully";
                    }
                    else
                    {
                        Message = "Try again";
                    }
                });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
