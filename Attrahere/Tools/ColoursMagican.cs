using Attrahere.Model;
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
            public ColorModifier ColorModifier { get; set; }

            public ColoursMagicanSettings(ColorModifier settings)
            {
                ColorModifier = settings;
            }
        }

        private ColoursMagicanSettings Settings;

        public ColoursMagican(ColoursMagicanSettings settings)
        {
            Settings = settings;
        }

        public Color GetColor(double iterationRate)
        {
            if (iterationRate == 1)
            {
                iterationRate = iterationRate - 0.000001;
            }
            int iloscKolorow = Settings.ColorModifier.ColorsTable.Count();

            double dlugoscPrzedzialu = 1 / (double)(iloscKolorow - 1);

            int przedzial = (int)Math.Floor(iterationRate / dlugoscPrzedzialu);

            double Amin = (przedzial * dlugoscPrzedzialu) - (przedzial * dlugoscPrzedzialu);

            double Amax = 1 - ((iloscKolorow - przedzial + 1) * dlugoscPrzedzialu);

            double procent = (iterationRate - Amin) / (iterationRate - Amax);

            if (procent == 0 && przedzial == 0)
            {
                return Color.FromArgb(255, 255, 255, 255);
            }

            byte R = (byte)(Settings.ColorModifier.ColorsTable[przedzial + 1].R +
                ((Settings.ColorModifier.ColorsTable[przedzial + 1].R - Settings.ColorModifier.ColorsTable[przedzial].R) * procent));

            byte G = (byte)(Settings.ColorModifier.ColorsTable[przedzial + 1].G +
                ((Settings.ColorModifier.ColorsTable[przedzial + 1].G - Settings.ColorModifier.ColorsTable[przedzial].G) * procent));

            byte B = (byte)(Settings.ColorModifier.ColorsTable[przedzial + 1].B +
                ((Settings.ColorModifier.ColorsTable[przedzial + 1].B - Settings.ColorModifier.ColorsTable[przedzial].B) * procent));

            return Color.FromArgb(255, R, G, B);
        }

        //public Color GetColor(double iterationRate)
        //{
        //    if (iterationRate > 1)
        //    {
        //        throw new NotImplementedException();
        //    }
        //    double val = iterationRate * 255 * 15;
        //    byte value = (byte)Math.Floor((decimal)(iterationRate * 255));
        //    byte r = 0;
        //    byte g = 0;
        //    byte b = 0;

        //    //g = (byte)Math.Floor((decimal)(iterationRate * 255));
        //    //b = g;
        //    //r = g;

        //    int countedvalue = (int)val / (int)255;

        //    if (countedvalue == 0)
        //    {
        //        b = (byte)(0);
        //        g = (byte)(130 - 1 / 2 * value);
        //        r = (byte)(120 + val / 2);
        //    }
        //    else if (countedvalue == 1)
        //    {
        //        b = (byte)(130 - 1 / 2 * value);
        //        g = (byte)(120 + 1 / 2 * value);
        //        r = (byte)(0 + value);
        //    }
        //    else if (countedvalue == 2)
        //    {
        //        b = (byte)(0);
        //        g = (byte)(130 - 1 / 2 * value);
        //        r = (byte)(120 + val / 2);
        //    }
        //    else if (countedvalue == 3)
        //    {
        //        b = (byte)(0);
        //        g = (byte)(130 - 1 / 2 * value);
        //        r = (byte)(120 + val / 2);
        //    }
        //    else if (countedvalue == 4)
        //    {
        //        b = (byte)(255 - 1 / 2 * value);
        //        g = (byte)(0 + 1 / 2 * value);
        //        r = (byte)(0);
        //    }
        //    else if (countedvalue == 5)
        //    {
        //        b = (byte)(0);
        //        g = (byte)(255 - 1 / 2 * value);
        //        r = (byte)(0 + val / 2);
        //    }
        //    else if (countedvalue == 6)
        //    {
        //        b = (byte)(130 - 1 / 2 * value);
        //        g = (byte)(120 + 1 / 2 * value);
        //        r = (byte)(0 + value);
        //    }
        //    else if (countedvalue == 7)
        //    {
        //        b = (byte)(0);
        //        g = (byte)(130 - 1 / 2 * value);
        //        r = (byte)(120 + val / 2);
        //    }
        //    else if (countedvalue == 8)
        //    {
        //        b = (byte)(130 - 1 / 2 * value);
        //        g = (byte)(120 + 1 / 2 * value);
        //        r = (byte)(0 + value);
        //    }
        //    else if (countedvalue == 9)
        //    {
        //        b = (byte)(0);
        //        g = (byte)(255 - 1 / 2 * value);
        //        r = (byte)(0 + val / 2);
        //    }
        //    else if (countedvalue == 10)
        //    {
        //        b = (byte)(0);
        //        g = (byte)(130 - 1 / 2 * value);
        //        r = (byte)(120 + val / 2);
        //    }
        //    else if (countedvalue == 11)
        //    {
        //        b = (byte)(0);
        //        g = (byte)(130 - 1 / 2 * value);
        //        r = (byte)(120 + val / 2);
        //    }
        //    else if (countedvalue == 12)
        //    {
        //        b = (byte)(130 - 1 / 2 * value);
        //        g = (byte)(120 + 1 / 2 * value);
        //        r = (byte)(0 + value);
        //    }
        //    else if (countedvalue == 13)
        //    {
        //        b = (byte)(0);
        //        g = (byte)(255 - 1 / 2 * value);
        //        r = (byte)(0 + val / 2);
        //    }
        //    else if (countedvalue == 14)
        //    {
        //        b = (byte)(0);
        //        g = (byte)(130 - 1 / 2 * value);
        //        r = (byte)(120 + val / 2);
        //    }
        //    else if (countedvalue == 15)
        //    {
        //        b = (byte)(0);
        //        g = (byte)(255 - 1 / 2 * value);
        //        r = (byte)(0 + val / 2);
        //    }

        //    return Color.FromArgb(255, r, g, b);
        //}
    }
}
