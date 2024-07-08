using System;
using System.Collections.Generic;

namespace Assets.Scripts.Architecture.EventBus
{
    public class CustomEvent
    {
        protected Dictionary<Action, ListenerWithPriority> _listeners = new();

        public void Subscribe(Action listener, int priority = 0)
        {
            Action key = listener;
            _listeners.Add(key, new ListenerWithPriority(listener, priority));
        }
        public void Unsubscribe(Action listener)
        {
            Action key = listener;
            _listeners.Remove(key);
        }
        public void Trigger()
        {
            foreach (var listener in _listeners) {
                listener.Value.Listener.Invoke();
            }
        }
    }
}
