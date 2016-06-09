using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Attrahere.Tools
{
    //public class TenaciousCounter
    //{
    //    private double _oneStepDistance = -1;
    //    private double _delta = -1;

    //    /// <summary>
    //    /// Oblicz rzeczywistą odległość pomiędzy krańcami generowanego pola
    //    /// </summary>
    //    /// <param name="Radius">Promień fraktala</param>
    //    /// <returns></returns>
    //    public double CountDelta(double Radius)
    //    {
    //        if (_delta == -1)
    //        {
    //            _delta = 2 * Radius;
    //        }
    //        return _delta;
    //    }
      
    //    /// <summary>
    //    /// oblicza odległóść jaką w rzeczywistosci ma jeden pixel
    //    /// </summary>
    //    /// <param name="radius"></param>
    //    /// <param name="ImageSize"></param>
    //    /// <returns></returns>
    //    public double CountOneStepDistance(double radius, double ImageSize)        
    //    {
    //        if (_oneStepDistance==-1)
    //        {
    //            _oneStepDistance = (2 * radius) / ImageSize;
    //        }
    //        return _oneStepDistance;
    //    }

    //    /// <summary>
    //    /// oblicza jak wiele pixeli potrzeba do wygenerowania obrazka o podanych rozmiarach dla konkretnego formatu
    //    /// </summary>
    //    /// <param name="PixelWidth"></param>
    //    /// <param name="PixelHeight"></param>
    //    /// <param name="format"></param>
    //    /// <returns></returns>
    //    public int CountHowManyBytesINeed(int PixelWidth, int PixelHeight, PixelFormat format)
    //    {
    //        var step = PixelWidth * ((format.BitsPerPixel + 7) / 8);
    //        return step * PixelHeight;
    //    }

    //    /// <summary>
    //    /// oblicza stopień szybkości wypadania poza promień
    //    /// </summary>
    //    /// <param name="ComplexPoint"></param>
    //    /// <param name="MaximumIterationCount"></param>
    //    /// <returns></returns>
    //    public double CountPointGrowthSpeedRate(Point ComplexPoint, uint MaximumIterationCount)
    //    {
    //        // częsc rzeczywista rozpatrywanego punktu
    //        double a = ComplexPoint.X;
    //        // część urojona rozpatrywanego punktu
    //        double b = ComplexPoint.Y;
    //        // iolość iteracji do przejscia
    //        uint maxIndex = MaximumIterationCount;
    //        // aktualny index
    //        int index = 0;
    //        // promień - czesc rzeczywista
    //        double za = 0;
    //        // promien - czesc urojona
    //        double zb = 0;
    //        while (true)
    //        {
    //            if (index > maxIndex)
    //            {
    //                return 1.1;
    //            }
    //            var za0 = za;
    //            var zb0 = zb;
    //            za = (za0 * za0) - (zb0 * zb0) + a;
    //            zb = (2 * za0 * zb0 + b);
    //            double modz = (za * za) + (zb * zb);
    //            if (modz > 4)
    //            {
    //                return (double)index / (double)maxIndex;
    //            }
    //            index++;
    //        }
    //    }      
    //}
}
