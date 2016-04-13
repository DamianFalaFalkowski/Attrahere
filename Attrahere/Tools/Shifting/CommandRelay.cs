using System;

namespace Attrahere.Tools
{
    public abstract partial class Shifting
    {
        public class CommandRelay<T, R, E>
        {
            private readonly Action<T, R, E> _event;
            public CommandRelay(Action<T, R, E> action)
            {
                _event = action as Action<T, R, E>;
            }
            public void Execute(T p1, R p2, E p3)
            {
                this._event(p1, p2, p3);
            }
        }

        public class CommandRelay<T, R> 
        {        
            private readonly Action<T, R> _event;
            public CommandRelay(Action<T, R> action)
            {
                _event = action as Action<T, R>;
            }
            public void Execute(T p1, R p2)
            {
                this._event(p1, p2);
            }
        }

        public class CommandRelay<T>
        {
            private Action<T> _event;
            public CommandRelay(Action<T> action) 
            {        
                _event = action;
            }          
            public void Execute(T t)
            {
                _event((T)t);
            }
        }

        public class CommandRelay
        {
            private readonly Action _event;

            public CommandRelay(Action action) 
            {
                _event = action;
            }
            public void Execute()
            {
                this._event();
            }
        }
    }
}
