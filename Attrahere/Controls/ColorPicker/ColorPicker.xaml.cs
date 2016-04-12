using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Attrahere.Controls.ColorPicker
{
    /// <summary>
    /// Interaction logic for ColorPicker.xaml
    /// </summary>
    public partial class ColorPicker : UserControl
    {
        // properties
        public byte R {
            get { return VM.R; }
            set { VM.R = value; } }

        public byte G {
            get { return VM.G; }
            set { VM.G = value; }
        }

        public byte B {
            get { return VM.B; }
            set { VM.B = value; }
        }

        // privates
        private ColorPickerViewModel VM;

        // ctors
        public ColorPicker()
        {
            DataContext = new ColorPickerViewModel();
            init();
        }
        public ColorPicker(byte r, byte g, byte b)
        {
            DataContext = new ColorPickerViewModel(r,g,b);
            init();
        }
        private void init()
        {
            VM = DataContext as ColorPickerViewModel;
            InitializeComponent();
        }

        // methods
        public Color GetColor()
        {
            return GetSolidColorBrush().Color;
        }
        public SolidColorBrush GetSolidColorBrush()
        {
            return VM.Color;
        }
    }
}
