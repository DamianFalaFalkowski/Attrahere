using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attrahere.Tools.FractalGenerator
{
    public partial class FractalGenerator
    {
        public interface IFractalMode
        {
            double[,] RateTable { get; }
            bool RateTableAvalible { get; }

            double[,] GenerateRateTable();
        }
    }
}
