using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Attrahere.Model.Extensions
{
    [Serializable]
    public class IOData_Att1
    {
        public IOData_Att1(GeneratorSettings settings)
        {
            this.X = settings.Center.X;
            this.Y = settings.Center.Y;
            this.PixelFormat = settings.PixelFormat;
            this.Dpi = settings.Dpi;
            this.Width = settings.Area.Width;
            this.Height = settings.Area.Height;
            this.Radius = settings.Radius;
            this.MaxIterationCount = settings.MaxIterationCount;
            this.Colors = new SerializableColor[settings.ColorModifier.ColorsTable.Count()];
            for (int i = 0; i < settings.ColorModifier.ColorsTable.Count(); i++)
            {
                Colors[i] = new SerializableColor(settings.ColorModifier.ColorsTable[i]);
            }
        }

        public double X { get; set; }
        public double Y { get; set; }
        public PixelFormat PixelFormat { get; set; }
        public double Dpi { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Radius { get; set; }
        public uint MaxIterationCount { get; set; }
        public Model.SerializableColor[] Colors { get; set; }

        public GeneratorSettings ReturnSettings()
        {
            var sett = new GeneratorSettings(new Rectangle() { Width = this.Width, Height = this.Height }, this.Radius, this.Dpi, this.MaxIterationCount, this.PixelFormat, new System.Windows.Point(this.X, this.Y));
            sett.ColorModifier = new ColorModifier(this.Colors.Count());
            for (int i = 0; i < this.Colors.Count(); i++)
            {
                sett.ColorModifier.Edit(i, Color.FromRgb(this.Colors[i].R, this.Colors[i].G, this.Colors[i].B));
            }
            return sett;
        }
    }
}
