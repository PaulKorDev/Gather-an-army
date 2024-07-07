using Assets.Scripts.Architecture.ServiceLocator;
using Units;
using UnityEngine;

public class GameplayPresenter : IService
{
    public void CreateUnit(int ID)
    {
        UnitObjectPool pool = ServiceLocator.Get<UnitObjectPool>();
        pool.GetObject(ID);
    }

    public void ClearUnitField()
    {
        UnitObjectPool pool = ServiceLocator.Get<UnitObjectPool>();
        pool.ReturnAllActiveObjects();
    }

    public void DeleteUnitFromField(Unit unit)
    {
        UnitObjectPool pool = ServiceLocator.Get<UnitObjectPool>();
    }
}
