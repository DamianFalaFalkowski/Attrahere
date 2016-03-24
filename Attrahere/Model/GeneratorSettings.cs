using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Attrahere.Model
{
    public class GeneratorSettings
    {
        public Point Center { get; set; }

        public double RadiusScale { get; set; }

        public PixelFormat PixelFormat { get; set; }

        public Rectangle Area { get; set; }

        public double Radius { get; set; }

        public int MaxIterationCount { get; set; }

        public GeneratorSettings(Rectangle area, double radius, 
            int iterationCount, PixelFormat pixelFormat, 
            double radiusmulti, Point center)
        {
            this.Area = area;
            this.Radius = radius;
            this.MaxIterationCount = iterationCount;
            this.PixelFormat = pixelFormat;
            this.RadiusScale = radiusmulti;
            this.Center = center;
        }
    }   
}
