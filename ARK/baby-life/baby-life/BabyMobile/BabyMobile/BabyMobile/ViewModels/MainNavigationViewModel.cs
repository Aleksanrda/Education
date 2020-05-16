using BabyMobile.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BabyMobile.ViewModels
{
    public class MainNavigationViewModel : BaseViewModel
    {
        private ViewType viewType;

        public MainNavigationViewModel()
        {
            this.ViewType = ViewType.LoginPage;
        }

        public ViewType ViewType
        {
            get
            {
                return this.viewType;
            }
            set
            {
                if (this.viewType != value)
                {
                    this.viewType = value;
                    this.OnPropertyChanged();
                }
            }
        }
    }
}
