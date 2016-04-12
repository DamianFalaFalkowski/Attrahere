using Attrahere.Model;
using Attrahere.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Attrahere.ViewModel
{
    public class SettingsViewModel : INotifyPropertyChanged
    {
        // on view items
        public double Radius {
            get { return _radius; }
            set { _radius = value;
                NotifyPropertyChanged("Radius");
            }
        }
        public uint MaximumIteration {
            get { return _maximumIteration; }
            set { _maximumIteration = value;
                NotifyPropertyChanged("MaximumIteration");
            }
        }
        public double ImageRealisticHeight {
            get { return _imageRealisticHeight; }
            set { _imageRealisticHeight = value;
                NotifyPropertyChanged("ImageRealisticHeight");
            }
        }
        public double ImageRealisticWidth {
            get { return _imageRealisticWidth; }
            set { _imageRealisticWidth = value;
                NotifyPropertyChanged("ImageRealisticWidth");
            }
        }
        public double Dpi { get { return _dpi; }
            set {
                double oldValue = _dpi;
                _dpi = value;
                ImageRealisticHeight = (_imageRealisticHeight * (oldValue / 100)) 
                    / (_dpi / 100);
                ImageRealisticWidth = (_imageRealisticWidth * (oldValue / 100)) 
                    / (_dpi / 100);
                NotifyPropertyChanged("Dpi");
            }
        }
        public double CenterAtXAxis {
            get { return _centerAtXAxis; }
            set { _centerAtXAxis = value; NotifyPropertyChanged("CenterAtXAxis"); }
        }
        public double CenterAtYAxis {
            get { return _centerAtYAxis; }
            set { _centerAtYAxis = value; NotifyPropertyChanged("CenterAtYAxis"); }
        }
        public bool IsUndoAvalible { get { return App.HistoryStack.IsPreviousAvalible; } }
        public bool IsRedoAvalible { get { return App.HistoryStack.IsNextAvalible; } }

        // privates
        private double _radius { get; set; }
        private uint _maximumIteration { get; set; }
        private double _imageRealisticWidth {
            get { return _imageRealisticHeight; }
            set { _imageRealisticHeight = value; } }
        private double _imageRealisticHeight { get; set; }
        private double _dpi { get; set; }
        private double _centerAtXAxis { get; set; }
        private double _centerAtYAxis { get; set; }

        // commands definitions
        public Shifting.CommandRelay GenerateFractalCommand;
        public Shifting.CommandRelay<double> ZoomAndGenerateFractalCommand;
        public Shifting.CommandRelay<double, double> SetCenterPointCommand;
        public Shifting.CommandRelay UndoChangesCommand;
        public Shifting.CommandRelay RedoChangesCommand;

        //ctors
        public SettingsViewModel()
        {
            GenerateFractalCommand = 
                new Shifting.CommandRelay(GenerateFractal);
            ZoomAndGenerateFractalCommand = 
                new Shifting.CommandRelay<double>(ZoomAndGenerateFractal);
            SetCenterPointCommand = 
                new Shifting.CommandRelay<double, double>(SetCenterPoint);
            UndoChangesCommand = new Shifting.CommandRelay(UndoChanges);
            RedoChangesCommand = new Shifting.CommandRelay(RedoChanges);

            Radius = 2;
            MaximumIteration = 35;
            ImageRealisticHeight = 650;
            ImageRealisticWidth = _imageRealisticHeight;
            Dpi = 100;
            CenterAtXAxis = 0;
            CenterAtYAxis = 0;
        }

        // commands body
        void UndoChanges()
        {
            GeneratorSettings sett = App.HistoryStack.PopPrevious();
            Radius = sett.Radius;
            MaximumIteration = sett.MaxIterationCount;
            ImageRealisticWidth = sett.Area.Width;
            CenterAtXAxis = sett.Center.X;
            CenterAtXAxis = sett.Center.Y;

            Generate(true);
            NotifyPropertyChanged("IsUndoAvalible");
            NotifyPropertyChanged("IsRedoAvalible");
        }

        void RedoChanges()
        {
            GeneratorSettings sett = App.HistoryStack.PopNext();
            Radius = sett.Radius;
            MaximumIteration = sett.MaxIterationCount;
            ImageRealisticWidth = sett.Area.Width;
            CenterAtXAxis = sett.Center.X;
            CenterAtXAxis = sett.Center.Y;

            Generate(false);
            NotifyPropertyChanged("IsUndoAvalible");
            NotifyPropertyChanged("IsRedoAvalible");
        }

        void GenerateFractal()
        {
            Generate(false);
        }

        void ZoomAndGenerateFractal(double zoomLevel)
        {
            Radius = Radius / 2;
            Generate(false);
        }

        void SetCenterPoint(double x, double y)
        {

        }

        // summary methods
        private void Generate(bool previous)
        {
            Rectangle area = new Rectangle()
            {
                // szerokość obszaru do narysowania
                Width = Convert.ToInt32(ImageRealisticWidth*(Dpi/100)),
                // wysokość obszaru do narysowania
                Height = Convert.ToInt32(ImageRealisticWidth * (Dpi / 100))
            };
            // format zapisu kolorów
            PixelFormat format = PixelFormats.Bgr32;
            // środek generowanej grafiki
            Point center = new Point(CenterAtXAxis, CenterAtYAxis);

            GeneratorSettings GeneratorSettings =
                new GeneratorSettings(area, Radius, MaximumIteration, format, center);

            // !!!!!!!!!!!!! KOLORY !!!!!!!
            //GeneratorSettings.ColorModifier = new ColorModifier(ColorsBox.Children.Count);
            //for (int i = 0; i < ColorsBox.Children.Count; i++)
            //{
            //    //GeneratorSettings.ColorModifier.Edit(i, (ColorsBox.Children[i] as ColorPicker).Color);
            //}

            if (!previous && GeneratorSettings != null)
            {
                App.HistoryStack.Push(GeneratorSettings);
            }
            NotifyPropertyChanged("IsUndoAvalible");
            NotifyPropertyChanged("IsRedoAvalible");

            // stwórz ustawienia generatora


            // zainitializuj bitmapę na którą fraktal będzie zapisywany
            InitBitmap((int)GeneratorSettings.Area.Width, 
                (int)GeneratorSettings.Area.Width, format, Dpi);

            // stwórz klasę mandelbrot na podstawie ustawień
            App.Mandel = new Mandelbrot(GeneratorSettings);

            // wygeneruj tablicę bajtów
            byte[] arr = App.Mandel.GenerateArray();

            // zapisz tablicę bajtów do bitmapy
            App.wBitmap.WritePixels(
                new Int32Rect(0, 0, App.wBitmap.PixelWidth,
                App.wBitmap.PixelHeight), arr, App.wBitmap.PixelWidth * 
                ((App.wBitmap.Format.BitsPerPixel + 7) / 8), 0);

            // stwórz obraz z bitmapy i dodaj go do scroll viewera
            Image fractalImage = new Image() { Width = App.wBitmap.Width,
                Height = App.wBitmap.Height, Source = App.wBitmap };
            fractalImage.MouseMove += FractalImage_MouseMove;
            fractalImage.MouseDown += FractalImage_MouseDown;
            //sView.Content = fractalImage;
        }
        
        private void InitBitmap(int width, int height, PixelFormat format, double dpi)
        {
            App.wBitmap = new WriteableBitmap(
                width, height, dpi, dpi,
                format, null);
        }

        private void FractalImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Point cover = e.GetPosition(sender as FrameworkElement);
            Point p = App.Mandel.GetRealisticPoint(
                (int)cover.X, (int)(sender as FrameworkElement).Height - 
                (int)cover.Y, Dpi);
            CenterAtXAxis = p.X;
            CenterAtYAxis = p.Y;
        }

        private void FractalImage_MouseMove(object sender, MouseEventArgs e)
        {
            Point cover = e.GetPosition(sender as FrameworkElement);
            Point p = App.Mandel.GetRealisticPoint(
                (int)cover.X, (int)(sender as FrameworkElement).Height - 
                (int)cover.Y, Dpi);
            //covery.Text = p.Y.ToString();
            //coverx.Text = p.X.ToString();
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
