using Attrahere.Tools;
using System;
using System.ComponentModel;
using System.Windows;
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
        private SettingsViewModel _settingsViewModel { get; set; }
        private object _mainScrollViewerContent { get; set; }

        // commands definitions
        public Shifting.CommandRelay<object> WiewLoadedCommand;
        public Shifting.CommandRelay<object> SetMainScrollVieverContentCommand;
        public Shifting.CommandRelay<byte[]> RenderFractalCommand;

        // ctor
        public MainWindowViewModel()
        {
            WiewLoadedCommand = new Shifting.CommandRelay<object>(WiewLoaded);
            SetMainScrollVieverContentCommand = new Shifting.CommandRelay<object>(SetMainScrollVieverContent);
            RenderFractalCommand = new Shifting.CommandRelay<byte[]>(RenderFractal);

            SettingsViewModel = new SettingsViewModel();
        }

        // commands body
        void SetMainScrollVieverContent(object obj)
        {
            Viewbox vb = new Viewbox();
            vb.Child = obj as FrameworkElement;
            //(obj as FrameworkElement).HorizontalAlignment = HorizontalAlignment.Stretch;
            MainScrollViewerContent = vb;
        }

        void RenderFractal(byte[] bytes)
        {

        }

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
