﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Attrahere.Model
{
    public class GeneratorSettings
    {
        public Point Center { get; set; }

        public PixelFormat PixelFormat { get; set; }

        public double Dpi { get; set; }

        public Rectangle Area { get; set; }

        public double Radius { get; set; }

        public uint MaxIterationCount { get; set; }

        public ColorModifier ColorModifier { get; set; }

        public GeneratorSettings()
        { }

        public GeneratorSettings(Rectangle area, double radius, double dpi, 
            uint iterationCount, PixelFormat pixelFormat, Point center)
        {
            this.Area = area;
            this.Radius = radius;
            this.Dpi = dpi;
            this.MaxIterationCount = iterationCount;
            this.PixelFormat = pixelFormat;
            this.Center = center;
        }

        public void EditColor(int index, Color color)
        {
            ColorModifier.Edit(index, color);
        }
                
        public void InitColorTable(int size, List<Color> colors)
        {
            ColorModifier = new ColorModifier(size);
            for (int i = 0; i < size; i++)
            {
                ColorModifier.Edit(i, colors[i]);
            }
        }

    }   
}
