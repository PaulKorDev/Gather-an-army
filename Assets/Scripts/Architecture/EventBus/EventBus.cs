using Assets.Scripts.Architecture.ServiceLocator;
using UnityEngine.Events;

namespace Assets.Scripts.Architecture.EventBus
{

    public class EventBus : IService
    {
        public UnityEvent UnitsOrderChanged { get; } = new();
        public void TrigerUnitsOrderChanged() => UnitsOrderChanged?.Invoke();

        public UnityEvent<UnitsTypes> UnitsTypeChanged { get; } = new();
        public void TrigerUnitsTypeChanged(UnitsTypes unitType) => UnitsTypeChanged?.Invoke(unitType);

    }
}
