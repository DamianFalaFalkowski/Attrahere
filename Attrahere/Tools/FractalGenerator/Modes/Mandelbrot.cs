using Attrahere.Model;
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
        public class Mandelbrot : ModeBase, IFractalMode
        {
            public double[,] RateTable { get; private set; }
            public bool RateTableAvalible { get { return RateTable == null ? false : true; } }

            private readonly GeneratorSettings _settings = FractalGenerator.Settings;

            public Mandelbrot() : base("MandelbrotSeries")
            { }

            public bool GenerateRateTable()
            {
                RateTable = new double[(int)_settings.Area.Width, (int)_settings.Area.Width];
                // iteruj po osi y 
                for (int i = (int)_settings.Area.Width - 1; i >= 0; i--)
                {
                    // iteruj po osi x
                    for (int j = 0; j < (int)Settings.Area.Height; j++)
                    {
                        // stwórz rzeczywisty punkt który aktualnie jest rozpatrywany
                        Point actualXY = Metadata.RealisticPoint.GetRealisticPoint(j, i);
                        var rate = Metadata.PointGrowthSpeedRate.CountPointGrowthSpeedRate
                            (actualXY, Settings.MaxIterationCount);
                        RateTable[j, i] = rate;
                    }
                }
                return true;
            }

           
        }
    }
}
