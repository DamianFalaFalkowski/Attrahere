using System;

namespace Attrahere.Tools
{
    abstract partial class Shifting
    {
        [Serializable()]
        public class WrongCommandRelayParamsCountExeption : System.Exception
        {
            public WrongCommandRelayParamsCountExeption()
            { AddHelpInfo(); }

            public WrongCommandRelayParamsCountExeption(string message)
            : base(message)
            { AddHelpInfo(); }

            public WrongCommandRelayParamsCountExeption(string message, Exception inner)
            : base(message, inner)
            { AddHelpInfo(); }

            protected WrongCommandRelayParamsCountExeption(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
            { AddHelpInfo(); }

            private void AddHelpInfo()
            {
                this.HelpLink = "You have used a wrong number of parameters for used CommandRelay.";
            }
        }
    }
}
