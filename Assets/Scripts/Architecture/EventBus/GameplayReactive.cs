
using Assets.Scripts.Architecture.Reactive;
using Assets.Scripts.Architecture.ServiceLocator;
using System.Collections.Generic;
using Units;

public class GameplayReactive : IService
{
    public ReactiveList<Unit> ActiveUnits { get; set; }
    public GameplayReactive(List<Unit> activeUnits)
    {
        ActiveUnits = activeUnits.ToReactiveList();
    }
}

