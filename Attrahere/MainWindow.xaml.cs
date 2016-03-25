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
        private HistoryStack HistoryStack;

        private Mandelbrot Mandel;

        public static WriteableBitmap wBitmap;

        //GeneratorSettings GeneratorSettings;

        public MainWindow()
        {
            HistoryStack = new HistoryStack();
            InitializeComponent();                     
        }    

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Generate(false);
        }

        private void InitBitmap(int width, int height, PixelFormat format, double dpi)
        {
            wBitmap = new WriteableBitmap(
                width, height, dpi, dpi,
                format, null);
        }

        private void FractalImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Point cover = e.GetPosition(sender as FrameworkElement);
            Point p = Mandel.GetRealisticPoint((int)cover.X, (int)(sender as FrameworkElement).Height - (int)cover.Y, Convert.ToDouble(DPI_TB.Text));
            centerX_TB.Text = p.X.ToString();
            centerY_TB.Text = p.Y.ToString();
        }

        private void FractalImage_MouseMove(object sender, MouseEventArgs e)
        {
            Point cover = e.GetPosition(sender as FrameworkElement);
            Point p = Mandel.GetRealisticPoint((int)cover.X, (int)(sender as FrameworkElement).Height - (int)cover.Y, Convert.ToDouble(DPI_TB.Text));
            covery.Text = p.Y.ToString();
            coverx.Text = p.X.ToString();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Radius_TB.Text = (Convert.ToDouble(Radius_TB.Text) / 2).ToString();
            Generate(false);
        }

        /// <summary>
        /// Generuje fraktal z danych w textboxach
        /// </summary>
        private void Generate(bool previous)
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

            GeneratorSettings GeneratorSettings =
                new GeneratorSettings(area, radius, iterCount, format, center);

            if (!previous  && GeneratorSettings!=null)
            {
                HistoryStack.Push(GeneratorSettings);              
            }
            Button_Redo.IsEnabled = HistoryStack.IsNextAvalible;
            Button_Undo.IsEnabled = HistoryStack.IsPreviousAvalible;

            // stwórz ustawienia generatora


            // zainitializuj bitmapę na którą fraktal będzie zapisywany
            InitBitmap((int)GeneratorSettings.Area.Width, (int)GeneratorSettings.Area.Width, format, Convert.ToDouble(DPI_TB.Text));

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

        private void Button_Undo_Loaded(object sender, RoutedEventArgs e)
        {         
            (sender as Button).IsEnabled = HistoryStack.IsPreviousAvalible;           
        }

        private void Button_Redo_Loaded(object sender, RoutedEventArgs e)
        {
            (sender as Button).IsEnabled = HistoryStack.IsNextAvalible;
        }

        private void Button_Undo_Click(object sender, RoutedEventArgs e)
        {
            GeneratorSettings sett = HistoryStack.PopPrevious();
            Radius_TB.Text = sett.Radius.ToString();
            Iter_TB.Text = sett.MaxIterationCount.ToString();
            Width_TB.Text = sett.Area.Width.ToString();
            centerX_TB.Text = sett.Center.X.ToString();
            centerY_TB.Text = sett.Center.Y.ToString();

            Generate(true);

            Button_Redo.IsEnabled = HistoryStack.IsNextAvalible;
            Button_Undo.IsEnabled = HistoryStack.IsPreviousAvalible;
        }

        private void Button_Redo_Click(object sender, RoutedEventArgs e)
        {
            GeneratorSettings sett = HistoryStack.PopNext();
            Radius_TB.Text = sett.Radius.ToString();
            Iter_TB.Text = sett.MaxIterationCount.ToString();
            Width_TB.Text = sett.Area.Width.ToString();
            centerX_TB.Text = sett.Center.X.ToString();
            centerY_TB.Text = sett.Center.Y.ToString();

            Generate(false);

            Button_Redo.IsEnabled = HistoryStack.IsNextAvalible;
            Button_Undo.IsEnabled = HistoryStack.IsPreviousAvalible;
        }
    }
}
