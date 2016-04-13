using Attrahere.Tools;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Attrahere
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Mandelbrot Mandel;
        public static HistoryStack HistoryStack;
        public static WriteableBitmap BitmapPainting;
        public static ScrollViewer MainScrollViewer;

        public App()
        {
            HistoryStack = new HistoryStack();
        
            //ColorsBox.Children.Add(new ColorPicker(0, 0, 0));
            //ColorsBox.Children.Add(new ColorPicker(255, 255, 255));
        }

        
    }
}
