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

       public FractalSphere(double radius, Point center)
       {
           ComplexStart = new Point(-radius+center.X, -radius+center.Y);
           ComplexEnd = new Point(radius + center.X, radius+center.Y);
       }
   }   
}
