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
        UnitsFactory factory = ServiceLocator.Get<UnitsFactory>();
        foreach (var unit in factory.GetSpawnedUnitList())
        {
            GameObject.Destroy(unit.gameObject);
        }
        factory.GetSpawnedUnitList().Clear();
    }
}
