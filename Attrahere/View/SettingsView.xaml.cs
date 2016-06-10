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
            InitializeComponent();
        }

        private void self_Loaded(object sender, RoutedEventArgs e)
        {
            VM = DataContext as SettingsViewModel;
        }

        private void Generate_Click(object sender, RoutedEventArgs e)
        {
            VM.GenerateFractalCommand.Execute();
        }

        private void GenerateWithSaving_Click(object sender, RoutedEventArgs e)
        {
            VM.GenerateWithSavingCommand.Execute();
        }

        private void ZoomX2_Click(object sender, RoutedEventArgs e)
        {
            VM.ZoomAndGenerateFractalCommand.Execute(2);
        }

        private void ZoomX4_Click(object sender, RoutedEventArgs e)
        {
            VM.ZoomAndGenerateFractalCommand.Execute(4);
        }

        private void ZoomX05_Click(object sender, RoutedEventArgs e)
        {
            VM.ZoomAndGenerateFractalCommand.Execute(0.5);
        }

        private void ZoomX025_Click(object sender, RoutedEventArgs e)
        {
            VM.ZoomAndGenerateFractalCommand.Execute(0.25);
        }

        private void Button_Undo_Click(object sender, RoutedEventArgs e)
        {
            VM.UndoChangesCommand.Execute();
        }

        private void Button_Redo_Click(object sender, RoutedEventArgs e)
        {
            VM.RedoChangesCommand.Execute();
        }       

        private void Button_RemoveColor_Click(object sender, RoutedEventArgs e)
        {
            VM.RemoveColorCommand.Execute();
        }

        private void Button_AddColor_Click(object sender, RoutedEventArgs e)
        {
            VM.AddColorCommand.Execute();
        }

        
    }
}
