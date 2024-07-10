﻿using System;
using UnityEngine;

namespace Assets.Scripts.Architecture.ReactiveProperty
{
    public class ReactiveProperty<T>
    {
        public event Action<T> OnChanged;

        private T _value;

        public ReactiveProperty(){ }
        public ReactiveProperty(T defaultValue)
        {
            Value = defaultValue;
        }
        public T Value
        {
            get { return _value; }
            set
            {
                _value = value;
                Debug.Log("Now value is " + _value);
                OnChanged?.Invoke(_value);
            }
        }
    }
}
