using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleUwpApp.ViewModels
{
    public class ApplicationViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        private bool _isPaneOpen = true;
        public bool IsPaneOpen
        {
            get
            {
                return _isPaneOpen;
            }
            set
            {
                if (value != _isPaneOpen)
                {
                    _isPaneOpen = value;
                    RaisePropertyChanged("IsPaneOpen");
                }
            }
        }

        public Boolean MainPageSelected
        {
            get { return _navigationService.CurrentPageKey == "MainPage"; }
            set
            {
                if (value)
                {
                    _navigationService.NavigateTo("MainPage");
                }
            }
        }

        public Boolean OtherPageSelected
        {
            get { return _navigationService.CurrentPageKey == "OtherPage"; }
            set
            {
                if (value)
                {
                    _navigationService.NavigateTo("OtherPage");
                }
            }
        }

        // Commands
        public RelayCommand TogglePane { get; set; }
        public RelayCommand Navigate { get; set; }

        public ApplicationViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            // Wire Commands
            TogglePane = new RelayCommand(TogglePaneExecute);
        }

        private void TogglePaneExecute()
        {
            IsPaneOpen = !IsPaneOpen;
        }
    }
}
