using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Attrahere.Model
{
    [Serializable]
    public class SerializableColor
    {
        public SerializableColor()
        {}
        public SerializableColor(Color c)
        {
            R = c.R;
            G = c.G;
            B = c.B;
        }
        public SerializableColor(byte r,byte g, byte b)
        {
            R = r;
            G = g;
            B = b;
        }
        public byte R { get; set; }
        public byte G { get; set; }
        public byte B { get; set; }
        public static Color ReturnColor(SerializableColor c)
        {
            return Color.FromRgb(c.R, c.G, c.B);
        }
    }
}
