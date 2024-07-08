using System;

namespace Assets.Scripts.Architecture.EventBus
{
    public class ListenerWithPriority
    {
        public readonly Action Listener;
        public readonly int Priority;

        public ListenerWithPriority(Action listener, int priority)
        {
            Listener = listener;
            Priority = priority;
        }
    }
    public class ListenerWithPriority<T1>
    {
        public readonly Action<T1> Listener;
        public readonly int Priority;

        public ListenerWithPriority(Action<T1> listener, int priority)
        {
            Listener = listener;
            Priority = priority;
        }
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