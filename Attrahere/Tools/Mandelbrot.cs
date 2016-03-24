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
        protected class WeirdDraft
        {
            private int burrerIndex;

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
                Parent = p;
                Sphere = new FractalSphere(Parent.Settings.Radius, Parent.Settings.Center);
                Delta = Parent.Counter.CountDelta(Parent.Settings.Radius);
                OnePixelDistanceOnAxisX =
                    Parent.Counter.CountOneStepDistance(Parent.Settings.Radius, Parent.Settings.Area.Width);
                OnePixelDistanceOnAxisY =
                    Parent.Counter.CountOneStepDistance(Parent.Settings.Radius, Parent.Settings.Area.Height);
                this.ImageInBytes = new byte[Parent.Counter.CountHowManyBytesINeed(
                (int)Parent.Settings.Area.Width,
                (int)Parent.Settings.Area.Height,
                Parent.Settings.PixelFormat)];
                this.burrerIndex = 0;
            }

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
            Magican = new ColoursMagican(new ColoursMagican.ColoursMagicanSettings());       
        }

        public byte[] GenerateArray()
        {           
            for (int i = 0; i < Settings.Area.Width; i++)
            {
                for (int j = 0; j < Settings.Area.Height; j++)
                {
                    var rate = Counter.CountPointGrowthSpeedRate(
                        new Point(
                            Draft.Sphere.ComplexStart.X + i * Draft.OnePixelDistanceOnAxisX,
                        Draft.Sphere.ComplexStart.Y + j * Draft.OnePixelDistanceOnAxisY), 
                        Settings.MaxIterationCount, Settings.Radius, Settings.RadiusScale);
                    //Debug.Write(rate + "   ");
                    if (rate>1)
                    {
                        Draft.AddNewPixelToArray(Colors.Black);
                    }
                    else
                    {
                        Draft.AddNewPixelToArray(
                        Magican.GetColor(rate));
                    }                  
                }
            }
            return Draft.ImageInBytes;
        }              
    }
}
