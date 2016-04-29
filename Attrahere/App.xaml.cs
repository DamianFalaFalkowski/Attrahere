using Attrahere.Model;
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
        public static MainWindow MainWindow;

        public static Mandelbrot Mandel;
        public static HistoryStack HistoryStack;
        public static WriteableBitmap BitmapPainting;
        
        

        public App()
        {
            //var sett = new GeneratorSettings(MainWindow
            //Mandel = new Mandelbrot();
            HistoryStack = new HistoryStack();
        }

        
    }
}
