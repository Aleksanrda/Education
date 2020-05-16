namespace BabyLifeMobile.Core.ViewModels
{
    using BabyLifeMobile.Core.Models.Enums;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class MainNavigationViewModel : BaseViewModel
    {
        private ViewType viewType;

        public MainNavigationViewModel()
        {
            this.ViewType = ViewType.AuthorizationView;
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
