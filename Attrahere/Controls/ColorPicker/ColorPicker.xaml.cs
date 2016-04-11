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

namespace Attrahere.Controls.ColorPicker
{
    /// <summary>
    /// Interaction logic for ColorPicker.xaml
    /// </summary>
    public partial class ColorPicker : UserControl
    {
     //   public static readonly DependencyProperty RProperty =
     //DependencyProperty.Register("R", typeof(byte),
     //typeof(ColorPicker), new FrameworkPropertyMetadata(0));

     //   // .NET Property wrapper
     //   public byte R
     //   {
     //       get { return (byte)GetValue(RProperty); }
     //       set {
     //           SetValue(RProperty, value);
     //           Color = Color.FromArgb(255, Convert.ToByte(value), Color.G, Color.B);
     //           canv.Background = new SolidColorBrush(Color);
     //       }
     //   }

        public Color Color { get; private set; }

        public ColorPicker()
        {
            Color = Color.FromArgb(255, 0, 0, 0);
            InitializeComponent();
            tbR.Text = "0";
            tbG.Text = "0";
            tbB.Text = "0";
        }

        public ColorPicker(byte r, byte g, byte b)
        {
            Color = Color.FromArgb(255, r, g, b);
            InitializeComponent();
            tbR.Text = r.ToString();
            tbG.Text = g.ToString();
            tbB.Text = b.ToString();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int n;
            bool isNumeric = int.TryParse((sender as TextBox).Text, out n);
            if (!isNumeric)
            {
                (sender as TextBox).TextChanged -= TextBox_TextChanged;
                (sender as TextBox).Text = "Err";
                (sender as TextBox).TextChanged += TextBox_TextChanged;
            }
            if (n > 255)
            {
                n = 255;
                (sender as TextBox).TextChanged -= TextBox_TextChanged;
                (sender as TextBox).Text = "255";
                (sender as TextBox).TextChanged += TextBox_TextChanged;
            }
            if (n < 0)
            {
                n = 0;
                (sender as TextBox).TextChanged -= TextBox_TextChanged;
                (sender as TextBox).Text = "0";
                (sender as TextBox).TextChanged += TextBox_TextChanged;
            }
            Color = Color.FromArgb(255, Convert.ToByte(n),Color.G, Color.B);
            canv.Background = new SolidColorBrush(Color.FromArgb(Color.A, Color.B, Color.G, Color.R));
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            int n;
            bool isNumeric = int.TryParse((sender as TextBox).Text, out n);
            if (!isNumeric)
            {
                (sender as TextBox).TextChanged -= TextBox_TextChanged_1;
                (sender as TextBox).Text = "Err";
                (sender as TextBox).TextChanged += TextBox_TextChanged_1;
            }
            if (n>255)
            {
                n = 255;
                (sender as TextBox).TextChanged -= TextBox_TextChanged_1;
                (sender as TextBox).Text = "255";
                (sender as TextBox).TextChanged += TextBox_TextChanged_1;
            }
            if (n<0)
            {
                n = 0;
                (sender as TextBox).TextChanged -= TextBox_TextChanged_1;
                (sender as TextBox).Text = "0";
                (sender as TextBox).TextChanged += TextBox_TextChanged_1;
            }
            Color = Color.FromArgb(255, Color.R, Convert.ToByte(n), Color.B);
            canv.Background = new SolidColorBrush(Color.FromArgb(Color.A, Color.B, Color.G, Color.R));
        }

        private void TextBox_TextChanged_2(object sender, TextChangedEventArgs e)
        {
            int n;
            bool isNumeric = int.TryParse((sender as TextBox).Text, out n);
            if (!isNumeric)
            {
                (sender as TextBox).TextChanged -= TextBox_TextChanged_2;
                (sender as TextBox).Text = "Err";
                (sender as TextBox).TextChanged += TextBox_TextChanged_2;
            }
            if (n > 255)
            {
                n = 255;
                (sender as TextBox).TextChanged -= TextBox_TextChanged_2;
                (sender as TextBox).Text = "255";
                (sender as TextBox).TextChanged += TextBox_TextChanged_2;
            }
            if (n < 0)
            {
                n = 0;
                (sender as TextBox).TextChanged -= TextBox_TextChanged_2;
                (sender as TextBox).Text = "0";
                (sender as TextBox).TextChanged += TextBox_TextChanged_2;
            }
            Color = Color.FromArgb(255, Color.R, Color.G, Convert.ToByte(n));
            canv.Background = new SolidColorBrush(Color.FromArgb(Color.A,Color.B,Color.G,Color.R));
        }
    }
}
