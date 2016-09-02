using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attrahere.Tools
{
    public class ExtensionsManager
    {
        public const int ActualExtensionNo = 1;
        public ExtensionsManager()
        {
            _extensions = new Dictionary<int, string>() { };
            _extensions.Add(1, ".att1");
        }
        public Dictionary<int, string> Extensions { get { return _extensions; } }
        private readonly Dictionary<int, string> _extensions;
    }
}
