using Assets.Scripts.Architecture.ServiceLocator;
using System.Collections.Generic;
using Units;
using UnityEngine;

namespace Assets.Scripts.Architecture.EventBus
{

    public class EventBus : IService
    {
        public EventBus()
        {
            Debug.Log("EVENT BUS");
        }
        public CustomEvent UnitsQuantityChanged { get; } = new();
        public CustomEvent UnitsTypeChanged { get; } = new();
        public CustomEvent<int, int> FieldStatisticChanged { get; } = new();
    }

}
