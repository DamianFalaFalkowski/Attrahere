using System;

namespace Attrahere.Tools
{
    public abstract partial class Shifting
    {
        public class CommandRelay<T, R, E> : CommandBase, ICommand
        {
            private readonly Action<object, object, object> _event;

            public CommandRelay(Action<T, R, E> action):base(3)
            {
                _event = action as Action<object, object, object>;
            }

            public void Execute(RelayParams p)
            {
                this.Validate(p);
                this._event(p.Params[0], p.Params[1], p.Params[2]);
            }
        }

        public class CommandRelay<T, R> : CommandBase, ICommand
        {        
            private readonly Action<object, object> _event;

            public CommandRelay(Action<T, R> action) : base(2)
            {
                _event = action as Action<object, object>;
            }

            public void Execute(RelayParams p)
            {
                this.Validate(p);
                this._event(p.Params[0], p.Params[1]);
            }
        }

        public class CommandRelay<T> : CommandBase, ICommand
        {
            private readonly Action<object> _event;

            public CommandRelay(Action<T> action) : base(1)
            {
                _event = action as Action<object>;
            }

            public void Execute(RelayParams p)
            {
                this.Validate(p);
                this._event(p.Params[0]);
            }
        }

        public class CommandRelay : CommandBase, ICommand
        {
            private readonly Action _event;

            public CommandRelay(Action action) : base(0)
            {
                _event = action;
            }

            public void Execute(RelayParams p)
            {
                this.Validate(p);
                this._event();
            }
        }
    }
}
