using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attrahere.Tools.FractalGenerator
{
    public partial class FractalGenerator
    {
        protected class Mandelbrot : ModeBase, IFractalMode
        {
            public double[,] RateTable { get; private set; }
            public bool RateTableAvalible { get { return RateTable == null ? false : true; } }

            public Mandelbrot() : base("MandelbrotSeries")
            {

            }

            public bool GenerateRateTable()
            {
                return false;
            }
        }
    }
}
