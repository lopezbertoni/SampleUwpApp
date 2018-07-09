using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using SampleUwpApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleUwpApp.ViewModels
{
    public class ViewModelLocator
    {
        public const string MainPageKey = "MainPage";
        public const string OtherPageKey = "OtherPage";

        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            var nav = new PageNavigationService();
            // nav.Configure(MainPageKey, typeof(ApplicationViewModel));
            nav.Configure(MainPageKey, typeof(MainPage));
            nav.Configure(OtherPageKey, typeof(OtherPage));

            SimpleIoc.Default.Register<ApplicationViewModel>();
            SimpleIoc.Default.Register<MainPageViewModel>();
            SimpleIoc.Default.Register<OtherPageViewModel>();
            SimpleIoc.Default.Register<INavigationService>(() => nav);
        }

        public ApplicationViewModel Application
        {
            get { return ServiceLocator.Current.GetInstance<ApplicationViewModel>(); }
        }

        public MainPageViewModel MainPage
        {
            get { return ServiceLocator.Current.GetInstance<MainPageViewModel>(); }
        }

        public OtherPageViewModel OtherPage
        {
            get { return ServiceLocator.Current.GetInstance<OtherPageViewModel>(); }
        }
    }
}
