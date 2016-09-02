using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Attrahere.Model
{
    [Serializable]
    public class ColorModifier
    {
        public Color[] ColorsTable;

        public ColorModifier(int count)
        {
            ColorsTable = new Color[count];
        }

        public void Edit(int index, Color color)
        {
            ColorsTable[index] = color;
        }
    }
}
