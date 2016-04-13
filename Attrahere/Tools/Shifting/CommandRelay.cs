using System;

namespace Attrahere.Tools
{
    public abstract partial class Shifting
    {
        public class CommandRelay<T, R, E> : CommandBase
        {
            private readonly Action<T, R, E> _event;

            public CommandRelay(Action<T, R, E> action):base(3)
            {
                _event = action as Action<T, R, E>;
            }

            public void Execute(T p1, R p2, E p3)
            {
                //this.Validate(p1);
                //this.Validate(p2);
                //this.Validate(p3);
                this._event(p1, p2, p3);
            }
        }

        public class CommandRelay<T, R> : CommandBase
        {        
            private readonly Action<T, R> _event;

            public CommandRelay(Action<T, R> action) : base(2)
            {
                _event = action as Action<T, R>;
            }

            public void Execute(T p1, R p2)
            {
                //this.Validate(p1);
                //this.Validate(p2);
                this._event(p1, p2);
            }
        }

        public class CommandRelay<T> : CommandBase
        {
            private Action<T> _event;

            public CommandRelay(Action<T> action) : base(1)
            {        
                _event = action;
            }
           
            public void Execute(T t)
            {
                //this.Validate(t);
                _event((T)t);
            }
        }

        public class CommandRelay : CommandBase
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
