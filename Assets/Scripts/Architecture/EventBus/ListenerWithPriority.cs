using System;

namespace Assets.Scripts.Architecture.EventBus
{
    //Here is many repeats but I hope it's not too critical
    public abstract class BaseListenerWithPriority<T>
    {
        public readonly T Listener;
        public readonly int Priority;

        protected BaseListenerWithPriority(T listener, int priority)
        {
            Listener = listener;
            Priority = priority;
        }
    }
    public class ListenerWithPriority : BaseListenerWithPriority<Action>
    {
        public ListenerWithPriority(Action listener, int priority) : base(listener, priority){}
    }
    public class ListenerWithPriority<T1> : BaseListenerWithPriority<Action<T1>>
    {
        public ListenerWithPriority(Action<T1> listener, int priority) : base(listener, priority){}
    }
    public class ListenerWithPriority<T1, T2> 
    {
        public readonly Action<T1, T2> Listener;
        public readonly int Priority;

        public ListenerWithPriority(Action<T1, T2> listener, int priority)
        {
            Listener = listener;
            Priority = priority;
        }
    }
    public class ListenerWithPriority<T1,T2,T3>
    {
        public readonly Action<T1, T2, T3> Listener;
        public readonly int Priority;

        public ListenerWithPriority(Action<T1, T2, T3> listener, int priority)
        {
            Listener = listener;
            Priority = priority;
        }
    }
    public class ListenerWithPriority<T1, T2, T3,T4>
    {
        public readonly Action<T1, T2, T3, T4> Listener;
        public readonly int Priority;

        public ListenerWithPriority(Action<T1, T2, T3, T4> listener, int priority)
        {
            Listener = listener;
            Priority = priority;
        }
    }
}