using Assets.Scripts.Architecture.ServiceLocator;
using System.Collections.Generic;
using System;
using UnityEngine.Events;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Architecture.EventBus
{

    //public class EventBus : IService
    //{
    //    #region Units order changed
    //    public UnityEvent UnitsOrderChanged { get; } = new();
    //    public void TrigerUnitsOrderChanged() => UnitsOrderChanged?.Invoke();
    //    #endregion

    //    #region Units quantity changed
    //    public UnityEvent UnitsQuantityChanged { get; } = new();
    //    public void TrigerUnitsQuantityChanged() => UnitsQuantityChanged?.Invoke();
    //    #endregion

    //    #region Units type changed
    //    public UnityEvent UnitsTypeChanged { get; } = new();
    //    public void TrigerUnitsTypeChanged() => UnitsTypeChanged?.Invoke();
    //    #endregion

    //}
    public class EventBus : IService
    {
        private Dictionary<string, List<CallbackWithPriority>> _signalCallbacks = new Dictionary<string, List<CallbackWithPriority>>();

<<<<<<< Updated upstream
        public UnityEvent<UnitsTypes> UnitsTypeChanged { get; } = new();
        public void TrigerUnitsTypeChanged(UnitsTypes unitType) => UnitsTypeChanged?.Invoke(unitType);
=======
        public void Subscribe<T>(Action<T> callback, int priority = 0)
        {
            string key = typeof(T).Name;
            if (_signalCallbacks.ContainsKey(key))
            {
                _signalCallbacks[key].Add(new CallbackWithPriority(priority, callback));
            }
            else
            {
                _signalCallbacks.Add(key, new List<CallbackWithPriority>() { new(priority, callback) });
            }
>>>>>>> Stashed changes

            _signalCallbacks[key] = _signalCallbacks[key].OrderByDescending(x => x.Priority).ToList();
        }

        public void Invoke<T>(T signal)
        {
            string key = typeof(T).Name;
            if (_signalCallbacks.ContainsKey(key))
            {
                foreach (var obj in _signalCallbacks[key])
                {
                    var callback = obj.Callback as Action<T>;
                    callback?.Invoke(signal);
                }
            }
        }

        public void Unsubscribe<T>(Action<T> callback)
        {
            string key = typeof(T).Name;
            if (_signalCallbacks.ContainsKey(key))
            {
                var callbackToDelete = _signalCallbacks[key].FirstOrDefault(x => x.Callback.Equals(callback));
                if (callbackToDelete != null)
                {
                    _signalCallbacks[key].Remove(callbackToDelete);
                }
            }
            else
            {
                Debug.LogErrorFormat($"Trying to unsubscribe for not existing key! {key} ");
            }
        }
    }
}
