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
            public static class RealisticPoint
            {
                public static Point GetRealisticPoint(int pixelX, int pixelY)
                {                  
                    return new Point(
                           ComplexBorders.GetLeftTop().X + (pixelX * RealisticPixelSize.GetRealisticPixelSize()),
                           ComplexBorders.GetLeftTop().Y - ((FractalGenerator.Settings.Area.Height - pixelY) * RealisticPixelSize.GetRealisticPixelSize()));
                }
            }
        }
    }
}
