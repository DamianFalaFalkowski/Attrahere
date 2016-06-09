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
            if (iterationRate > 1)
            {
                return Colors.Black;
            }
            if (iterationRate == 1)
            {
                iterationRate = iterationRate - 0.000001;
            }
            int iloscKolorow = Settings.ColorModifier.ColorsTable.Count();

            double dlugoscPrzedzialu = 1 / (double)(iloscKolorow - 1);

            int przedzial = (int)Math.Floor(iterationRate / dlugoscPrzedzialu);

            double Amin = dlugoscPrzedzialu * przedzial;

            double Amax = dlugoscPrzedzialu * przedzial + 1;

            double procent = (iterationRate - Amin) / dlugoscPrzedzialu;
            if (procent > 1)
            {
                throw new NotImplementedException("procent nie może być większy od 1");
            }

            if (procent == 0 && przedzial == 0)
            {
                return Color.FromArgb(255, 255, 255, 255);
            }

            byte R = (byte)(Settings.ColorModifier.ColorsTable[przedzial].R -
                ((Settings.ColorModifier.ColorsTable[przedzial].R - Settings.ColorModifier.ColorsTable[przedzial + 1].R) * procent));

            byte G = (byte)(Settings.ColorModifier.ColorsTable[przedzial].G -
                ((Settings.ColorModifier.ColorsTable[przedzial].G - Settings.ColorModifier.ColorsTable[przedzial + 1].G) * procent));

            byte B = (byte)(Settings.ColorModifier.ColorsTable[przedzial].B -
                ((Settings.ColorModifier.ColorsTable[przedzial].B - Settings.ColorModifier.ColorsTable[przedzial + 1].B) * procent));

            // nie wiem czemu zamienia kolory, dlatego tutaj daję odwrotnie niż teoretycznei być powinno
            return Color.FromRgb(B, G, R);
        }
    }
}
