using Attrahere.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Attrahere.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        // on view items
        public SettingsViewModel SettingsViewModel { get { return _settingsViewModel; }
            private set { _settingsViewModel = value; NotifyPropertyChanged("SettingsViewModel"); } }
        public object MainScrollViewerContent { get { return _mainScrollViewerContent; }
            private set { _mainScrollViewerContent = value; NotifyPropertyChanged("MainScrollViewerContent"); } }

        // privates
        public SettingsViewModel _settingsViewModel { get; private set; }
        public object _mainScrollViewerContent { get; private set; }

        // commands definitions
        public Shifting.CommandRelay<object> WiewLoadedCommand;

        // ctor
        public MainWindowViewModel()
        {            
            SettingsViewModel = new SettingsViewModel();
        }

        // commands body
        void WiewLoaded(object sender)
        {
            App.MainWindow = sender as MainWindow;
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
