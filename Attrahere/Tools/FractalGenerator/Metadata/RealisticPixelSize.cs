using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attrahere.Tools.FractalGenerator
{
    public static partial class FractalGenerator
    {
        public abstract partial class Metadata
        {
            public static class RealisticPixelSize
            {
                private static double _lastRadius = -1;
                private static double _lastImageSize = -1;
                private static double _oneStepDistance = -1;

                public static double GetRealisticPixelSize(int pixelX, int pixelY)
                {
                    return CountOneStepDistance(FractalGenerator.Settings.Radius, FractalGenerator.Settings.Area.Width);
                }

                private static double CountOneStepDistance(double radius, double ImageSize)
                {
                    if (_lastRadius!=radius && _lastImageSize!=ImageSize || _oneStepDistance==-1)
                    {
                        _oneStepDistance = (2 * radius) / ImageSize;
                    }
                    return _oneStepDistance;
                }
            }
        }
    }
}
