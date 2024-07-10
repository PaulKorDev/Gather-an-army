using System;

namespace Assets.Scripts.Architecture.Reactive
{
    public class ReactiveProperty<T>
    {
<<<<<<< Updated upstream:Assets/Scripts/Architecture/ReactiveProperty/ReactiveProperty.cs
        public ReactiveProperty(T defaultValue)
        {
            Value = defaultValue;
        }
        public event Action<T> OnChanged;

        private T _value;

=======
        public event Action<T> OnChanged;

        private T _value;
>>>>>>> Stashed changes:Assets/Scripts/Architecture/Reactive/ReactiveProperty.cs
        public T Value
        {
            get { return _value; }
            set
            {
                _value = value;
                OnChanged?.Invoke(_value);
            }
        }
        public ReactiveProperty(T defaultValue)
        {
            Value = defaultValue;
        }
    }
}
