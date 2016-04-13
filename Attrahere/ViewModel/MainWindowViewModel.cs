using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attrahere.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        // on view items
        public SettingsViewModel SettingsViewModel { get; set; }


        // ctor
        public MainWindowViewModel()
        {
            SettingsViewModel = new SettingsViewModel();
        }



        // INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
    }
}
