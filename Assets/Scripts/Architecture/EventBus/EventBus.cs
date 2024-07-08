using Assets.Scripts.Architecture.ServiceLocator;
using System.Collections.Generic;
using UnityEngine.Events;

namespace Assets.Scripts.Architecture.EventBus
{

    public class EventBus : IService
    {
        #region Units order changed
        public CustomEvent UnitsOrderChanged { get; } = new();
        public void TrigerUnitsOrderChanged() => UnitsOrderChanged?.Trigger();
        #endregion

        #region Units quantity changed
        public CustomEvent UnitsQuantityChanged { get; } = new();
        public void TrigerUnitsQuantityChanged() => UnitsQuantityChanged?.Trigger();
        #endregion

        #region Units type changed
        public CustomEvent UnitsTypeChanged { get; } = new();
        public void TrigerUnitsTypeChanged() => UnitsTypeChanged?.Trigger();
        #endregion

    }

}
