using Attrahere.Tools;
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

namespace Attrahere.View
{
    /// <summary>
    /// Interaction logic for SettingsView.xaml
    /// </summary>
    public partial class SettingsView : UserControl
    {
        private SettingsViewModel VM;

        public SettingsView()
        {
            DataContext = new SettingsViewModel();
            VM = DataContext as SettingsViewModel;
            InitializeComponent();
        }

        private void Generate_Click(object sender, RoutedEventArgs e)
        {
            VM.GenerateFractalCommand.Execute(null);
        }

        private void ZoomX2_Click(object sender, RoutedEventArgs e)
        {
            VM.ZoomAndGenerateFractalCommand.
                Execute(new Shifting.RelayParams(2));
        }

        private void Button_Undo_Click(object sender, RoutedEventArgs e)
        {
            VM.UndoChangesCommand.Execute(null);
        }

        private void Button_Redo_Click(object sender, RoutedEventArgs e)
        {
            VM.RedoChangesCommand.Execute(null);
        }
    }
}
