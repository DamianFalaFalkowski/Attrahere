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
    }
}
