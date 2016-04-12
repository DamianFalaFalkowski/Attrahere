using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attrahere.Tools
{
    public abstract partial class Shifting
    {
        public class RelayParams
        {
            public object[] Params;

            public RelayParams()
            {
                Params = new object[0] { };
            }

            public RelayParams(object parameter)
            {
                Params = new object[1] { parameter };
            }

            public RelayParams(object parameter, object parameter2)
            {
                Params = new object[2] { parameter, parameter2 };
            }

            public RelayParams(object parameter, object parameter2, object parameter3)
            {
                Params = new object[3] { parameter, parameter2, parameter3 };
            }
        }
    }
}
