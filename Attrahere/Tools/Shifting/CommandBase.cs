using System;
using System.Linq;
namespace Attrahere.Tools
{
    abstract partial class Shifting
    {
        public abstract class CommandBase
        {
            private UInt16 _parametersCount;

            public CommandBase(UInt16 parametersCount)
            {
                _parametersCount = parametersCount;
            }

            /// <summary>
            /// Sprawdza czy ilość parametrów jest poprawna
            /// </summary>
            /// <param name="parameters">parametry</param>
            //protected void Validate(RelayParams parameters)
            //{
            //    if (parameters==null || parameters.Params==null)
            //    {
            //        parameters = new RelayParams();
            //    }
            //    if (parameters.Params.Count() != _parametersCount)
            //    {
            //        throw new WrongCommandRelayParamsCountExeption();
            //    }                
            //}

          

            protected Action<object> Convert<T>(Action<T> myActionT)
            {
                if (myActionT == null) return null;
                else return new Action<object>(o => myActionT((T)o));
            }
        }
    }
}
