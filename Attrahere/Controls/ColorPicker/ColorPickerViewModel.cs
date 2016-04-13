using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;

namespace Attrahere.Controls.ColorPicker
{
    public class ColorPickerViewModel : DependencyObject, INotifyPropertyChanged
    {
        // on view items
        public byte R
        {
            get { return _r; }
            set { _r = value; NotifyPropertyChanged("ColorBrush"); NotifyPropertyChanged("R"); }
        }
        public byte G
        {
            get { return _g; }
            set { _g = value; NotifyPropertyChanged("ColorBrush"); NotifyPropertyChanged("G"); }
        }
        public byte B
        {
            get { return _b; }
            set { _b = value; NotifyPropertyChanged("ColorBrush"); NotifyPropertyChanged("B"); }
        }
        public SolidColorBrush ColorBrush
        {
            get { return new SolidColorBrush(System.Windows.Media.Color.FromRgb(_r, _g, _b)); }
        }        

        // privates
        private byte _r { get; set; }
        private byte _g { get; set; }
        private byte _b { get; set; }

        // ctors
        public ColorPickerViewModel()
        {
            R = 0;
            G = 0;
            B = 0;
        }
        public ColorPickerViewModel(byte r, byte g, byte b)
        {
            R = r;
            G = g;
            B = b;
        }

        // INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
    }
}
