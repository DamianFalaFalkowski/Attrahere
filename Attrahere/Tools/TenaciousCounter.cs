using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Attrahere.Tools
{
    public class TenaciousCounter
    {
        public double CountDelta(double Radius)
        {
            return 2 * Radius;
        }

        public double CountOneStepDistance(double radius, double ImageSize)        
        {
            return 2*radius / ImageSize;
        }

        public int CountHowManyBytesINeed(int PixelWidth, int PixelHeight, PixelFormat format)
        {
            var step = PixelWidth * ((format.BitsPerPixel + 7) / 8);
            return step * PixelHeight;
        }

        public double CountPointGrowthSpeedRate(Point ComplexPoint, int MaximumIterationCount, double MaximumRadius, double Radiusscale)
        {
            double a = ComplexPoint.X;
            double b = ComplexPoint.Y;         
            double rmax = MaximumRadius;
            // iolość iteracji do przejscia
            int maxIndex = MaximumIterationCount;
            // aktualny index
            int index = 0;
            // promień - czesc rzeczywista
            double za = 0;
            // promien - czesc urojona
            double zb = 0;
            while (true)
            {
                if (index > maxIndex)
                {
                    return 1.1;
                }
                var za0 = za;
                var zb0 = zb;
                za = (za0 * za0) - (zb0 * zb0) + b;
                zb = (2 * za0 * zb0 + a);
                //double modz = (za * za) + Math.Sqrt((za * za) + (zb * zb));
                double modz = (za * za) + (zb * zb);
                if (modz * Radiusscale > 4)
                {
                    return (double)index / (double)maxIndex;
                }
                index++;
            }
        }

        /// <summary>
        /// Class for complex numbers x = x.real + i*x.imaginary
        /// </summary>
        public class complex_t
        {
            public double real;
            public double imaginary;

            //calculate squared modus of given complex c
            public double complexModSq()
            {
                return (real * real + imaginary * imaginary);
            }
        }
    }
}
