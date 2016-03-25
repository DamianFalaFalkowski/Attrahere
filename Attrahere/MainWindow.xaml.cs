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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Generate();
        }

        private void InitBitmap(int width, int height, PixelFormat format)
        {
            wBitmap = new WriteableBitmap(
                width, height, 100, 100,
                format, null);
        }

        private void FractalImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Point cover = e.GetPosition(sender as FrameworkElement);
            Point p = Mandel.GetRealisticPoint((int)cover.X, (int)(sender as FrameworkElement).Height - (int)cover.Y);
            centerX_TB.Text = p.X.ToString();
            centerY_TB.Text = p.Y.ToString();
        }

        private void FractalImage_MouseMove(object sender, MouseEventArgs e)
        {
            Point cover = e.GetPosition(sender as FrameworkElement);
            Point p = Mandel.GetRealisticPoint((int)cover.X, (int)(sender as FrameworkElement).Height - (int)cover.Y);
            covery.Text = p.Y.ToString();
            coverx.Text = p.X.ToString();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Radius_TB.Text = (Convert.ToDouble(Radius_TB.Text) / 2).ToString();
            Generate();
        }

        private void Generate()
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
                Height = Convert.ToDouble(Width_TB.Text)
            };
            // format zapisu kolorów
            PixelFormat format = PixelFormats.Bgr32;
            // środek generowanej grafiki
            Point center = new Point(Convert.ToDouble(centerX_TB.Text), Convert.ToDouble(centerY_TB.Text));

            // stwórz ustawienia generatora
            GeneratorSettings GeneratorSettings =
                new GeneratorSettings(area, radius, iterCount, format, center);

            // zainitializuj bitmapę na którą fraktal będzie zapisywany
            InitBitmap((int)GeneratorSettings.Area.Width, (int)GeneratorSettings.Area.Width, format);

            // stwórz klasę mandelbrot na podstawie ustawień
            Mandel = new Mandelbrot(GeneratorSettings);

            // wygeneruj tablicę bajtów
            byte[] arr = Mandel.GenerateArray();

            // zapisz tablicę bajtów do bitmapy
            wBitmap.WritePixels(
                new Int32Rect(0, 0, wBitmap.PixelWidth,
                wBitmap.PixelHeight), arr, wBitmap.PixelWidth * ((wBitmap.Format.BitsPerPixel + 7) / 8), 0);

            // stwórz obraz z bitmapy i dodaj go do scroll viewera
            Image fractalImage = new Image() { Width = wBitmap.Width, Height = wBitmap.Height, Source = wBitmap };
            fractalImage.MouseMove += FractalImage_MouseMove;
            fractalImage.MouseDown += FractalImage_MouseDown;
            sView.Content = fractalImage;
        }
    }
}
