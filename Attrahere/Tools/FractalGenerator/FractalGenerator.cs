using Attrahere.Model;
using Attrahere.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Attrahere.Tools.FractalGenerator
{
    public static partial class FractalGenerator
    {
        public static IFractalMode SelectedMode { get; private set; }
        public static GeneratorSettings Settings { get; private set; }
        private static double[,] RateTable {
            get { return IsRateTableAvalible ? SelectedMode.RateTable : null; } }
        private static bool IsRateTableAvalible {
            get { return SelectedMode.RateTableAvalible; } }
        

        public static byte[] Generate(GeneratorSettings settings)
        {
            Settings = settings;
            return _generate();
        }

        public static byte[] Generate()
        {
            return _generate();
        }

        public static void SetCenterPoint(double X, double Y)
        {
            Settings.Center = new System.Windows.Point(X,X);
        }

        public static System.Windows.Point GetRealisticPoint(double x, double y)
        {
            return Metadata.RealisticPoint.GetRealisticPoint((int)x, (int)y);
        }

        public static void ChangeSettings(GeneratorSettings settings)
        {
            Settings = settings;
        }

        public static void ChangeMode(GeneratorModes mode)
        {
            if (mode == GeneratorModes.MandelbrotSeries)
            {
                SelectedMode = new Mandelbrot();
            }
            else
            {
                throw new NotImplementedException("trzeba dodac obsługę");
            }
        }

        private static byte[] _generate()
        {
            if (SelectedMode.GenerateRateTable())
            {
                return GetBytesTable();
            }
            else
            {
                throw new NotImplementedException("trzeba dodac obsługę");
            }
        }

        private static byte[] GetBytesTable()
        {
            ColoursMagican cm = 
                new ColoursMagican(new ColoursMagican.ColoursMagicanSettings(Settings.ColorModifier));

            ulong index = 0; 
            byte[] bytes = new byte[(int)Settings.Area.Width * (int)Settings.Area.Width * 4];
            for (int i = 0; i < Settings.Area.Width; i++)
            {
                for (int j = 0; j < Settings.Area.Width; j++)
                {
                    Color col = cm.GetColor(
                        Metadata.PointGrowthSpeedRate.CountPointGrowthSpeedRate(FractalGenerator.Metadata.RealisticPoint.GetRealisticPoint(j, i), Settings.MaxIterationCount));
                    bytes[index+3] = 255;
                    bytes[index] = col.R;
                    bytes[index+1] = col.G;
                    bytes[index+2] = col.B;
                    index += 4;
                }
            }
            return bytes;
        }

        public enum GeneratorModes { MandelbrotSeries }  
    }
}
