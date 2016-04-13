﻿using Attrahere.Controls.ColorPicker;
using Attrahere.Model;
using Attrahere.Tools;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            set { _imageRealisticHeight = value;
                NotifyPropertyChanged("ImageRealisticWidth");
            }
        }
        public double Dpi { get { return _dpi; }
            set { _dpi = value; NotifyPropertyChanged("Dpi"); }
        }
        public double CenterAtXAxis {
            get { return _centerAtXAxis; }
            set { _centerAtXAxis = value;
                NotifyPropertyChanged("CenterAtXAxis");
                NotifyPropertyChanged("CenterAtYAxis");
            }
        }
        public double CenterAtYAxis {
            get { return _centerAtYAxis; }
            set { _centerAtYAxis = value;
                NotifyPropertyChanged("CenterAtXAxis");
                NotifyPropertyChanged("CenterAtYAxis");
            }
        }
        public bool IsUndoAvalible { get { return App.HistoryStack.IsPreviousAvalible; } }
        public bool IsRedoAvalible { get { return App.HistoryStack.IsNextAvalible; } }
        public ObservableCollection<ColorPickerViewModel> ColorsList { get; private set; }

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
        private PixelFormat _pixelFormat { get; set; }

        // commands definitions
        public Shifting.CommandRelay GenerateFractalCommand;
        public Shifting.CommandRelay<double> ZoomAndGenerateFractalCommand;
        public Shifting.CommandRelay<double, double> SetCenterPointCommand;
        public Shifting.CommandRelay UndoChangesCommand;
        public Shifting.CommandRelay RedoChangesCommand;
        public Shifting.CommandRelay RemoveColorCommand;
        public Shifting.CommandRelay AddColorCommand;

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
            RemoveColorCommand = new Shifting.CommandRelay(RemoveColor);
            AddColorCommand = new Shifting.CommandRelay(AddColor);

            ColorsList = new ObservableCollection<ColorPickerViewModel>() { };
            ColorsList.Add(new ColorPickerViewModel(0, 0, 0));
            ColorsList.Add(new ColorPickerViewModel(255, 255, 255));
            Radius = 2;
            MaximumIteration = 35;
            ImageRealisticHeight = 650;
            ImageRealisticWidth = ImageRealisticHeight;
            Dpi = 100;
            CenterAtXAxis = 0;
            CenterAtYAxis = 0;
            _pixelFormat = PixelFormats.Bgr32;
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
        private void RemoveColor()
        {

        }

        private void AddColor()
        {

        }

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

            GeneratorSettings.ColorModifier = new ColorModifier(ColorsList.Count);
            for (int i = 0; i < ColorsList.Count; i++)
            {
                GeneratorSettings.ColorModifier.Edit(i, ColorsList[i].ColorBrush.Color);
            }

            if (!previous && GeneratorSettings != null)
            {
                App.HistoryStack.Push(GeneratorSettings);
            }
            NotifyPropertyChanged("IsUndoAvalible");
            NotifyPropertyChanged("IsRedoAvalible");

            // stwórz ustawienia generatora


            // zainitializuj bitmapę na którą fraktal będzie zapisywany
            InitBitmap();

            // stwórz klasę mandelbrot na podstawie ustawień
            App.Mandel = new Mandelbrot(GeneratorSettings);

            // wygeneruj tablicę bajtów
            byte[] arr = App.Mandel.GenerateArray();

            // zapisz tablicę bajtów do bitmapy
            App.BitmapPainting.WritePixels(
                new Int32Rect(0, 0, App.BitmapPainting.PixelWidth,
                App.BitmapPainting.PixelHeight), arr, App.BitmapPainting.PixelWidth * 
                ((App.BitmapPainting.Format.BitsPerPixel + 7) / 8), 0);

            // stwórz obraz z bitmapy i dodaj go do scroll viewera
            Image fractalImage = new Image() { Width = App.BitmapPainting.Width,
                Height = App.BitmapPainting.Height, Source = App.BitmapPainting
            };
            fractalImage.MouseMove += FractalImage_MouseMove;
            fractalImage.MouseDown += FractalImage_MouseDown;

            App.MainScrollViewer.Content = fractalImage;
        }     
        private void InitBitmap()
        {
            App.BitmapPainting = new WriteableBitmap(
                Convert.ToInt32(ImageRealisticHeight*(Dpi/100)), 
                Convert.ToInt32(ImageRealisticHeight * (Dpi / 100)), 
                Dpi, Dpi, _pixelFormat, null);
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
