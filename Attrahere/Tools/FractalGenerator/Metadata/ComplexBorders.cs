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
            public static class ComplexBorders
            {
                private static Point LeftTop { get;  set; }
                //private static Point LeftBottom { get;  set; }
                //private static Point RightTop { get;  set; }
                private static Point RightBottom { get;  set; }

                private static double _lastRadius = -1;
                private static Point _lastRealisticCentre = new Point(-123, -321);

                public static Point GetLeftTop()
                {
                    double realisticRadius = (FractalGenerator.Settings.Area.Width / 2) * Metadata.RealisticPixelSize.GetRealisticPixelSize();
                    // FractalGenerator.Settings.Radius
                    if ((_lastRadius != realisticRadius &&
                        _lastRealisticCentre.X != FractalGenerator.Settings.Center.X &&
                        _lastRealisticCentre.Y != FractalGenerator.Settings.Center.Y) || 
                        (_lastRadius==-1 && _lastRealisticCentre.X==-123 && 
                        _lastRealisticCentre.Y==-321))
                    {
                        LeftTop = new Point(FractalGenerator.Settings.Center.X - realisticRadius,
                            FractalGenerator.Settings.Center.Y + realisticRadius);
                        RightBottom = new Point(FractalGenerator.Settings.Center.X + realisticRadius,
                            FractalGenerator.Settings.Center.Y - realisticRadius);
                    }
                    return LeftTop;                 
                }

                public static Point GetRightBottom()
                {
                    double realisticRadius = (FractalGenerator.Settings.Area.Width / 2) * Metadata.RealisticPixelSize.GetRealisticPixelSize();
                    // FractalGenerator.Settings.Radius

                    if ((_lastRadius != realisticRadius &&
                        _lastRealisticCentre.X != FractalGenerator.Settings.Center.X &&
                        _lastRealisticCentre.Y != FractalGenerator.Settings.Center.Y) ||
                        (_lastRadius == -1 && _lastRealisticCentre.X == -123 &&
                        _lastRealisticCentre.Y == -321))
                    {
                        LeftTop = new Point(FractalGenerator.Settings.Center.X - realisticRadius,
                            FractalGenerator.Settings.Center.Y + realisticRadius);
                        RightBottom = new Point(FractalGenerator.Settings.Center.X + realisticRadius,
                            FractalGenerator.Settings.Center.Y - realisticRadius);
                    }
                    return RightBottom;
                }
            }
        }
    }
}
