using Assets.Scripts.Architecture.ServiceLocator;
using UnityEngine;

public class GameplayPresenter : IService
{
    public void CreateUnit(int ID)
    {
        UnitsFactory factory = ServiceLocator.Get<UnitsFactory>();
        switch (ID)
        {
            case 1: factory.CreateUnit1(); break;
            case 2: factory.CreateUnit2(); break;
            case 3: factory.CreateUnit3(); break;
        }
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
