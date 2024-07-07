using Assets.Scripts.Architecture.ServiceLocator;
using System.Collections.Generic;
using System.Threading.Tasks;
using Units;

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

    public async void DeleteUnitFromField(Unit unit)
    {
        UnitObjectPool pool = ServiceLocator.Get<UnitObjectPool>();
        pool.ReturnObject(unit);
        List<Unit> activePool = pool.GetAllActiveObjects();
        await SortActiveObjectOnField(activePool);
        await UpdateCostOfUnitsOnField(activePool);
        
    }

    private Task SortActiveObjectOnField(List<Unit> activeUnits)
    {
        foreach (Unit unit in activeUnits) { 
            unit.transform.SetAsLastSibling();
        }
        return Task.CompletedTask;
    }
    private Task UpdateCostOfUnitsOnField(List<Unit> activeUnits)
    {
        for (int i = 0; i < activeUnits.Count; i++)
        {
            ServiceLocator.Get<UnitsFactory>().UpdateCostAndSetText(activeUnits[i], i+1);
        }
        return Task.CompletedTask;
    }

}
