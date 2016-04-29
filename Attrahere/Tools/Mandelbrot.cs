using Attrahere.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Attrahere.Tools
{
    public class Mandelbrot
    {
        /// <summary>
        /// schemat fraktala
        /// </summary>
        protected class WeirdDraft
        {
            // buffor
            private int burrerIndex;

            // obrazek zapisany w tablicy bajtów
            public byte[] ImageInBytes { get; private set; }

            private Mandelbrot Parent;

            // Rzeczywisty badany obrzar. Real to część rzeczywista 
            // liczby zespolonej i odpowiada za współrzędne x.
            // Imaginary to część urojona, i odpowiada za 
            // współrzędne na osi y.
            public FractalSphere Sphere { get; private set; }

            // delta to rzeczywista odległość pomiędzy Start-EndReal i 
            // jednocześnie pomiędzy Start-EndImaginary
            public double Delta;

            // odległość odpowiadająca jednemu pikselowi na wykresie dla osi
            public double OnePixelDistanceOnAxisX { get; private set; }
            public double OnePixelDistanceOnAxisY { get; private set; }



            public WeirdDraft(Mandelbrot p)
            {
                // ustaw rodzica
                Parent = p;
                Sphere = new FractalSphere(Parent.Settings.Radius, Parent.Settings.Center);
                Delta = Parent.Counter.CountDelta(Parent.Settings.Radius);
                OnePixelDistanceOnAxisX =
                    Parent.Counter.CountOneStepDistance(Parent.Settings.Radius, Parent.Settings.Area.Width);
                OnePixelDistanceOnAxisY = OnePixelDistanceOnAxisX;
                this.ImageInBytes = new byte[Parent.Counter.CountHowManyBytesINeed(
                (int)Parent.Settings.Area.Width,
                (int)Parent.Settings.Area.Height,
                Parent.Settings.PixelFormat)];
                this.burrerIndex = 0;
            }

            /// <summary>
            /// Dodawanie pojedynczego pixela do tablicy bitów
            /// </summary>
            /// <param name="color"></param>
            public void AddNewPixelToArray(Color color)
            {
                ImageInBytes[this.burrerIndex] = color.R;
                ImageInBytes[this.burrerIndex+1] = color.G;
                ImageInBytes[this.burrerIndex + 2] = color.B;
                ImageInBytes[this.burrerIndex+3] = 255;
                this.burrerIndex += 4;
            }
        }

        private GeneratorSettings Settings;
        private WeirdDraft Draft;
        private TenaciousCounter Counter;
        private ColoursMagican Magican;

        public double GetXAxisOnePixelRealWidth()
        {
            return Draft.OnePixelDistanceOnAxisX;
        }

        public double GetYAxisOnePixelRealHeight()
        {
            return Draft.OnePixelDistanceOnAxisY;
        }

        public FractalSphere ReturnFractalSphere()
        {
            return Draft.Sphere;
        }

        public double GetActualRadius()
        {
            return Settings.Radius;
        }

        public Mandelbrot(GeneratorSettings settings)
        {
            Settings = settings;
            Counter = new TenaciousCounter();
            Draft = new WeirdDraft(this);
            Magican = new ColoursMagican(new ColoursMagican.ColoursMagicanSettings(settings.ColorModifier));       
        }


        // DONOT REMOVE THIS --------------------------------------------------------------
        /// <summary>
        /// Pobiera rzeczywisty punkt na podstawie pixeli z osi x i y
        /// </summary>
        /// <param name="pixelX"></param>
        /// <param name="pixelY"></param>
        /// <returns></returns>
        public Point GetRealisticPoint(int pixelX,int pixelY)
        {
            return new Point(
                            Draft.Sphere.ComplexStart.X + (pixelX * Draft.OnePixelDistanceOnAxisX),
                            Draft.Sphere.ComplexStart.Y - ((Settings.Area.Height - pixelY) * Draft.OnePixelDistanceOnAxisY));
        }
        public Point GetRealisticPoint(int pixelX, int pixelY, double dpi)
        {
            return new Point(
                            Draft.Sphere.ComplexStart.X + (pixelX*dpi/100 * Draft.OnePixelDistanceOnAxisX),
                            Draft.Sphere.ComplexStart.Y - ((Settings.Area.Height - pixelY*dpi/100) * Draft.OnePixelDistanceOnAxisY));
        }
        //-----------------------------------------------------------------
        /// <summary>
        /// generuje pełną tablicę bajtów dla fraktala z ustawień
        /// </summary>
        /// <returns></returns>


        public byte[] GenerateArray()
        { 
            // iteruj po osi y          
            for (int i = (int)Settings.Area.Width-1; i >= 0; i--)
            {

                //Parallel.For(0, (int)Settings.Area.Height,
                //    x => {
                //        Point actualXY = GetRealisticPoint(i, x);

                //        // Oblicz stopień dążenia do przekroczenia promienia (wartości <0,1>)
                //        var rate = Counter.CountPointGrowthSpeedRate(actualXY, Settings.MaxIterationCount);
                //        if (rate > 1)
                //        {
                //            // jeśli stopień przekracza 1 to dodaj czarny pixel
                //            Draft.AddNewPixelToArray(Colors.Black);
                //        }
                //        else
                //        {
                //            // jeśli stopień mieści się w przedziale, to dodaj obliczony kolor
                //            Draft.AddNewPixelToArray(Magican.GetColor(rate));
                //        }
                //    });

                // iteruj po osi x
                for (int j = 0; j < (int)Settings.Area.Height; j++)
                {
                    // stwórz rzeczywisty punkt który aktualnie jest rozpatrywany
                    Point actualXY = GetRealisticPoint(j, i);

                    // Oblicz stopień dążenia do przekroczenia promienia (wartości <0,1>)
                    var rate = Counter.CountPointGrowthSpeedRate(actualXY, Settings.MaxIterationCount);
                    if (rate > 1)
                    {
                        // jeśli stopień przekracza 1 to dodaj czarny pixel
                        Draft.AddNewPixelToArray(Colors.Black);
                    }
                    else
                    {
                        // jeśli stopień mieści się w przedziale, to dodaj obliczony kolor
                        Draft.AddNewPixelToArray(Magican.GetColor(rate));
                    }
                }
            }
            // zwróć tablicę bitów
            return Draft.ImageInBytes;
        }              
    }
}
