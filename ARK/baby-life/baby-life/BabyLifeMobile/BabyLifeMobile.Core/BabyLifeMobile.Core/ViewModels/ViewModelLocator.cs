namespace BabyLifeMobile.Core.ViewModels
{
    using CommonServiceLocator;
    using GalaSoft.MvvmLight.Ioc;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<AuthorizationViewModel>();
            SimpleIoc.Default.Register<RegistrationViewModel>();
            SimpleIoc.Default.Register<MainNavigationViewModel>();
            SimpleIoc.Default.Register<UserViewModel>();
            SimpleIoc.Default.Register<DeviceViewModel>();
        }

        public AuthorizationViewModel AuthorizationViewModel => SimpleIoc.Default.GetInstance<AuthorizationViewModel>();
        public MainNavigationViewModel MainNavigationViewModel => SimpleIoc.Default.GetInstance<MainNavigationViewModel>();
        public RegistrationViewModel RegistrationViewModel => SimpleIoc.Default.GetInstance<RegistrationViewModel>();
        public UserViewModel UserViewModel => SimpleIoc.Default.GetInstance<UserViewModel>();
        public DeviceViewModel DeviceViewModel => SimpleIoc.Default.GetInstance<DeviceViewModel>();
    }
}
