using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attrahere.Tools.FractalGenerator.Modes
{
    public partial class FractalGenerator
    {
        protected class ModeBase
        {
            public string Name { get; private set; }

            public ModeBase(string name)
            {
                Name = name;
            }
        }
    }
}
