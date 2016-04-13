using Attrahere.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attrahere.Tools.FractalGenerator
{
    public static partial class FractalGenerator
    {
        public static IFractalMode SelectedMode { get; private set; }
        public static GeneratorSettings Settings { get; private set; }
        public static double[,] RateTable {
            get { return RateTableAvalible ? SelectedMode.RateTable : null; } }
        public static bool RateTableAvalible {
            get { return SelectedMode.RateTableAvalible; } }
        

        public static void Generate(GeneratorSettings settings)
        {
            Settings = settings;
            _generate();
        }

        public static void Generate()
        {
            _generate();
        }

        public static void ChangeSettings(GeneratorSettings settings)
        {
            Settings = settings;
        }

        public static void ChangeMode(IFractalMode mode)
        {
            SelectedMode = mode;
        }

        private static void _generate()
        {
            if (SelectedMode.GenerateRateTable())
            {
                // code if generated
            }
            else
            {
                // code if generation failed
            }
        }

        

        
    }
}
