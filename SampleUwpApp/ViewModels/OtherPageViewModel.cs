using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleUwpApp.ViewModels
{
    public class OtherPageViewModel : ViewModelBase
    {
        private string _text = string.Empty;
        public string TextBlockText
        {
            get
            {
                return _text;
            }
            set
            {
                if (value != _text)
                {
                    _text = value;
                    RaisePropertyChanged("TextBlockText");
                }
            }
        }

        // Commands
        public RelayCommand ChangeText { get; set; }

        public OtherPageViewModel()
        {
            _text = "Hello World!";

            // Wire Commands
            ChangeText = new RelayCommand(ChangeTextExecute);
        }

        private void ChangeTextExecute()
        {
            TextBlockText = $"Loading text from code behind. Other Page";
        }
    }
}
