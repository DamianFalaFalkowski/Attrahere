using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Attrahere.Controls.ColorPicker
{
    public class ColorPickerViewModel : INotifyPropertyChanged
    {
        // on view items
        public byte R
        {
            get { return _r; }
            set { _r = value; NotifyPropertyChanged("Color"); NotifyPropertyChanged("R"); }
        }
        public byte G
        {
            get { return _g; }
            set { _g = value; NotifyPropertyChanged("Color"); NotifyPropertyChanged("G"); }
        }
        public byte B
        {
            get { return _b; }
            set { _b = value; NotifyPropertyChanged("Color"); NotifyPropertyChanged("B"); }
        }
        public SolidColorBrush Color
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
