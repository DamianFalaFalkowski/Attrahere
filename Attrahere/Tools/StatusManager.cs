using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Attrahere.Tools
{
    public class StatusManager
    {
        public StatusManager()
        {
            _statusMessage = "Ready";
            _statusColor = Color.FromArgb(255, 55, 212, 55);
        }

        public string StatusMessage
        {
            get { return _statusMessage; }
        }
        private string _statusMessage { get; set; }

        public SolidColorBrush StatusColor
        {
            get { return new SolidColorBrush(_statusColor); }
        }

        private Color _statusColor { get; set; }

        public void GetBusy()
        {
            _statusMessage = "Busy...";
            _statusColor = Colors.Yellow;
        }

        public void GetReady()
        {
            _statusMessage = "Ready";
            _statusColor = Color.FromArgb(255, 55, 212, 55);
        }

        public void Error()
        {
            _statusMessage = "Error!";
            _statusColor = Colors.Red;
        }

        public void Warning()
        {
            _statusMessage = "Warning";
            _statusColor = Colors.Orange;
        }
    }
}
