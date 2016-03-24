using Attrahere.Model;
using Attrahere.Tools;
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
        private Mandelbrot Mandel;

        public static WriteableBitmap wBitmap;

        public MainWindow()
        {
            InitializeComponent();

            
        }

        private void InitBitmap(int width, int height, PixelFormat format)
        {
            wBitmap = new WriteableBitmap(
                width, height, 100, 100,
                format, null);            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // promien na którym będzie rysowany fraktal
            double radius = Convert.ToDouble(Radius_TB.Text);
            // maksymalna ilość iteracji
            int iterCount = Convert.ToInt32(Iter_TB.Text);
            Rectangle area = new Rectangle()
            {
                // szerokość obszaru do narysowania
                Width = Convert.ToDouble(Width_TB.Text),
                // wysokość obszaru do narysowania
                Height = Convert.ToDouble(Height_TB.Text)
            };
            // format zapisu kolorów
            PixelFormat format = PixelFormats.Bgr32;
            Point center = new Point(Convert.ToDouble(centerX_TB.Text), Convert.ToDouble(centerY_TB.Text));

            double radiusmultiplayer = Convert.ToDouble(RadiusMultiplayer_TB.Text);

            GeneratorSettings GeneratorSettings =
                new GeneratorSettings(area, radius, iterCount, format, radiusmultiplayer,center);

            InitBitmap((int)GeneratorSettings.Area.Width, (int)GeneratorSettings.Area.Height, format);

            Mandel = new Mandelbrot(GeneratorSettings);

            byte[] arr = Mandel.GenerateArray();

            wBitmap.WritePixels(
                new Int32Rect(0, 0, wBitmap.PixelWidth,
                wBitmap.PixelHeight), arr, wBitmap.PixelWidth * ((wBitmap.Format.BitsPerPixel + 7) / 8), 0);

            Image fractalImage = new Image() { Width = wBitmap.Width, Height = wBitmap.Height, Source = wBitmap };
            fractalImage.MouseMove += FractalImage_MouseMove;
            fractalImage.MouseDown += FractalImage_MouseDown;         
            sView.Content = fractalImage;
        }

        private void FractalImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Point cover = e.GetPosition(sender as FrameworkElement);
            FractalSphere fs = Mandel.ReturnFractalSphere();
            centerX_TB.Text = (fs.ComplexStart.Y +
                (4  * cover.Y )/ 650)
                .ToString();
            centerY_TB.Text = (fs.ComplexStart.X +
                (4 * cover.X) / 650 )
                .ToString();
        }

        private void FractalImage_MouseMove(object sender, MouseEventArgs e)
        {
            Point cover = e.GetPosition(sender as FrameworkElement);
            FractalSphere fs = Mandel.ReturnFractalSphere();
            coverx.Text =
                (fs.ComplexStart.X +
                (4 * cover.X) / (sender as FrameworkElement).ActualWidth)
                .ToString();
            covery.Text = 
                (fs.ComplexStart.Y +
                (4  * cover.Y )/ (sender as FrameworkElement).ActualHeight)
                .ToString();
        }
    }
}
