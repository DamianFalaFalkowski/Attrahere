using Attrahere.Controls.ColorPicker;
using Attrahere.Model;
using Attrahere.Tools;
using Attrahere.Tools.DataIO;
using Attrahere.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Attrahere
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel VM;

        public MainWindow()
        {
            DataContext = new MainWindowViewModel();
            VM = DataContext as MainWindowViewModel;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            (DataContext as MainWindowViewModel).WiewLoadedCommand.Execute(sender);
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            ExportToJPEG.Export(App.BitmapPainting);
        }
    }
}
