using UnityEngine.Events;

namespace Assets.Scripts.Architecture.EventBus
{

    public class EventBus
    {
        public UnityEvent UnitsOrderChanged { get; } = new();

        public void TrigerUnitsOrderChanged() => UnitsOrderChanged?.Invoke();

    }
}
