using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Text;

namespace BabyMobile.ViewModels
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<AuthViewModel>();
            SimpleIoc.Default.Register<RegisterViewModel>();
            SimpleIoc.Default.Register<MainNavigationViewModel>();
            SimpleIoc.Default.Register<UserViewModel>();
            //SimpleIoc.Default.Register<DeviceViewModel>();
        }

        public AuthViewModel AuthViewModel => SimpleIoc.Default.GetInstance<AuthViewModel>();
        public MainNavigationViewModel MainNavigationViewModel => SimpleIoc.Default.GetInstance<MainNavigationViewModel>();
        public RegisterViewModel RegistrationViewModel => SimpleIoc.Default.GetInstance<RegisterViewModel>();
        public UserViewModel UserViewModel => SimpleIoc.Default.GetInstance<UserViewModel>();

        //public DeviceViewModel DeviceViewModel => SimpleIoc.Default.GetInstance<DeviceViewModel>();
    }
}
