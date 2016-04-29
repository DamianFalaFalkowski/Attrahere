using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Attrahere.Tools.FractalGenerator
{
    public static partial class FractalGenerator
    {
        public abstract partial class Metadata
        {
            public static class PointGrowthSpeedRate
            {
                public static double CountPointGrowthSpeedRate
                    (Point ComplexPoint, uint MaximumIterationCount)
                {
                    // częsc rzeczywista rozpatrywanego punktu
                    double a = ComplexPoint.X;
                    // część urojona rozpatrywanego punktu
                    double b = ComplexPoint.Y;
                    // iolość iteracji do przejscia
                    uint maxIndex = MaximumIterationCount;
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
                        za = (za0 * za0) - (zb0 * zb0) + a;
                        zb = (2 * za0 * zb0 + b);
                        double modz = (za * za) + (zb * zb);
                        if (modz > 4)
                        {
                            return (double)index / (double)maxIndex;
                        }
                        index++;
                    }
                }
            }         
        }
    }
}
