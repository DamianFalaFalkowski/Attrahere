using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Attrahere.Tools
{
    public class ColoursMagican
    {
        public class ColoursMagicanSettings
        {
            public ColoursMagicanSettings()
            {

            }
        }

        private ColoursMagicanSettings Settings;

        public ColoursMagican(ColoursMagicanSettings settings)
        {
            Settings = settings;
        }

        public Color GetColor(double iterationRate)
        {
            if (iterationRate > 1)
            {
                throw new NotImplementedException();
            }
            double val = iterationRate * 255 * 3;
            byte value = (byte)Math.Floor((decimal)(iterationRate * 255));
            byte r = 0;
            byte g = 0;
            byte b = 0;
            if ((int)val / (int)255 == 0)
            {
                b = (byte)(255 - 1/2*value);
                g = (byte)(0 + 1 / 2 * value);
                r = (byte)(0);
            }
            else if ((int)val / (int)255 == 1)
            {
                b = (byte)(130 - 1 / 2 * value);
                g = (byte)(120+1/2*value);
                r = (byte)(0 + value);
            }
            else if ((int)val / (int)255 == 2)
            {
                b = (byte)(0);
                g = (byte)(255 - 1 / 2 * value);
                r = (byte)(0 + val / 2);
            }
            else if ((int)val / (int)255 == 3)
            {
                b = (byte)(0);
                g = (byte)(130 - 1 / 2 * value);
                r = (byte)(120 + val / 2);
            }

            return Color.FromArgb(255, r, g, b);
        }
    }
}
