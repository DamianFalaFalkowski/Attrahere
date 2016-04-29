using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Attrahere.Model
{   
    public class FractalSphere
    {
        public Point ComplexStart { get; private set; }
        public Point ComplexEnd { get; private set; }
        public double Radius { get; private set; }
        
        /// <summary>
        /// to do
        /// </summary>
        /// <param name="radius"></param>
        /// <param name="center"></param>
        public FractalSphere(double radius, Point center)
        {
            Radius = radius;
            ComplexStart = new Point(center.X - Radius, center.Y + radius);
            ComplexEnd = new Point(center.X + radius, center.Y - radius);
        }
    }   
}
