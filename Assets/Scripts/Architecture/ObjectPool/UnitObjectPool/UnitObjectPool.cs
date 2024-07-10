using Units;
using Assets.Scripts.Architecture.ObjectPool;
using Assets.Scripts.Architecture.ServiceLocator;
using Assets.Scripts.Architecture.EventBus;
using Assets.Scripts.Architecture.Reactive;
public class UnitObjectPool : ObjectPool<Unit>, IService
{
    private static int _preload = 12;
    private static bool _autoExpand = true;
    private static int _poolLimit = 24;

    public UnitObjectPool(ReactiveList<Unit> activeUnitsList) : base(activeUnitsList, FactoryMethod, GetEffect, ReturnEffect, _preload, _autoExpand, _poolLimit) { }
  
    #region Constructor methods
    private static Unit FactoryMethod()
    {
        var createdUnit = ServiceLocator.Get<UnitsFactory>().CreateUnit();
        return createdUnit;
    }
    private static void ReturnEffect(Unit obj)
    {
        obj.gameObject.SetActive(false);
    }
    private static void GetEffect(Unit unit, int id) {
        ServiceLocator.Get<UnitsUpdater>().SetImageToUnit(unit, id);
        ServiceLocator.Get<UnitsFactory>().InitAndSetCostUnit(unit, id);
        unit.gameObject.transform.SetAsLastSibling();
        unit.gameObject.SetActive(true);

    }
    #endregion




}

