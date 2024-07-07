using Assets.Scripts.Architecture.ServiceLocator;
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
}
