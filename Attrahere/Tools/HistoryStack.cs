using Attrahere.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attrahere.Tools
{
    public class HistoryStack
    {
        public bool IsPreviousAvalible { get { return PreviousNodes.Count > 0 ? true : false; } private set { } }
        public bool IsNextAvalible { get { return NextNodes.Count > 0 ? true : false; } private set { } }

        private Stack<GeneratorSettings> PreviousNodes;
        private Stack<GeneratorSettings> NextNodes;
        private GeneratorSettings Actual;

        public HistoryStack()
        {
            PreviousNodes = new Stack<GeneratorSettings>() { };
            NextNodes = new Stack<GeneratorSettings>() { };          
        }

        public void Push(GeneratorSettings item)
        {
            if (Actual==null)
            {
                Actual = item;
            }
            else
            {                               
                if (!Compare(Actual, item))
                {
                    PreviousNodes.Push(Actual);
                    Actual = item;
                    NextNodes.Clear();
                }
            }          
        }

        public GeneratorSettings PopPrevious()
        {
            if (IsPreviousAvalible)
            {
                var item = PreviousNodes.Pop();
                NextNodes.Push(Actual);
                Actual = item;
                return item;
            }
            return null;
        }

        public GeneratorSettings PopNext()
        {
            if (IsNextAvalible)
            {
                var item = NextNodes.Pop();
                PreviousNodes.Push(Actual);
                Actual = item;
                return item;
            }
            return null;
        }

        private bool Compare(GeneratorSettings set, GeneratorSettings set2)
        {
            if ((set.Area.Width == set2.Area.Width)  &&
                (set.Center.X == set2.Center.X) &&
                (set.Center.Y == set2.Center.Y) &&
                (set.MaxIterationCount == set2.MaxIterationCount) &&
                (set.PixelFormat == set2.PixelFormat) &&
                (set.Radius == set2.Radius) )
            {
                return true;
            }
            return false;
        }
    }
}
