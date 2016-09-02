using Attrahere.Model;
using Attrahere.Tools;
using Attrahere.Tools.DataIO;
using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Attrahere.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        // on view items
        public string StatusMessage
        {
            get { return _statusManager.StatusMessage; }
        }
        public SolidColorBrush StatusColor
        {
            get { return _statusManager.StatusColor; }
        }
        public SettingsViewModel SettingsViewModel { get { return _settingsViewModel; }
            private set { _settingsViewModel = value; NotifyPropertyChanged("SettingsViewModel"); } }
        public object MainScrollViewerContent { get { return _mainScrollViewerContent; }
            private set { _mainScrollViewerContent = value; NotifyPropertyChanged("MainScrollViewerContent"); } }

        // privates   
        private StatusManager _statusManager{ get; set; }     
        private SettingsViewModel _settingsViewModel { get; set; }
        private object _mainScrollViewerContent { get; set; }

        // commands definitions
        public Shifting.CommandRelay<object> WiewLoadedCommand;
        public Shifting.CommandRelay<object> SetMainScrollVieverContentCommand;
        public Shifting.CommandRelay<byte[]> RenderFractalCommand;
        public Shifting.CommandRelay OpenFileCommand;
        public Shifting.CommandRelay SaveFileCommand;
        public Shifting.CommandRelay StatusManagerGetBusyCommand;
        public Shifting.CommandRelay StatusManagerGetReadyCommand;

        // ctor
        public MainWindowViewModel()
        {
            WiewLoadedCommand = new Shifting.CommandRelay<object>(WiewLoaded);
            SetMainScrollVieverContentCommand = new Shifting.CommandRelay<object>(SetMainScrollVieverContent);
            RenderFractalCommand = new Shifting.CommandRelay<byte[]>(RenderFractal);
            OpenFileCommand = new Shifting.CommandRelay(OpenFile);
            SaveFileCommand = new Shifting.CommandRelay(SaveFile);
            StatusManagerGetBusyCommand = new Shifting.CommandRelay(StatusManagerGetBusy);
            StatusManagerGetReadyCommand = new Shifting.CommandRelay(StatusManagerGetReady);

            SettingsViewModel = new SettingsViewModel();
            _statusManager = new StatusManager();
        }

        // commands body
        void StatusManagerGetBusy()
        {
            _statusManager.GetBusy();
            NotifyPropertyChanged("StatusMessage");
            NotifyPropertyChanged("StatusColor");
        }

        void StatusManagerGetReady()
        {
            _statusManager.GetReady();
            NotifyPropertyChanged("StatusMessage");
            NotifyPropertyChanged("StatusColor");
        }

        void OpenFile()
        {
            GeneratorSettings loadedSettings = new GeneratorSettings();
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.DefaultExt = App.ExtensionsManager.Extensions[ExtensionsManager.ActualExtensionNo];
            var filter = "";
            for (int i = 1; i < App.ExtensionsManager.Extensions.Count + 1; i++)
            {
                filter += "Attrahere format (*" + App.ExtensionsManager.Extensions[i] + ")|*" + App.ExtensionsManager.Extensions[i] + "|";
            }
            filter = filter.Remove(filter.Length - 1);
            openDialog.Filter = filter;
            if (openDialog.ShowDialog() == true)
                loadedSettings = FractalWriter.LoadData(openDialog.FileName);
            if (loadedSettings != null)
            {
                SettingsViewModel.GenerateFractalFromSettingsCommand.Execute(loadedSettings);
            }
        }

        void SaveFile()
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.DefaultExt = App.ExtensionsManager.Extensions[ExtensionsManager.ActualExtensionNo];
            var filter = "";
            for (int i = 1; i < App.ExtensionsManager.Extensions.Count + 1; i++)
            {
                filter += "Attrahere format (" + App.ExtensionsManager.Extensions[i] + ")|*" + App.ExtensionsManager.Extensions[i] + "|";
            }
            filter = filter.Remove(filter.Length - 1);
            saveDialog.Filter = filter;
            if (saveDialog.ShowDialog() == true)
            {
                FractalWriter.SaveAs(SettingsViewModel.GetGeneratorSettings(), saveDialog.FileName);
            }
        }

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
