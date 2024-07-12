using Assets.Scripts.Architecture.ServiceLocator;
using Units;
using UnityEngine;
using Zenject;

public class GameplayPresenter 
{
    [Inject] 
    private UnitObjectPool Pool { get; set; }

    public GameplayPresenter()
    {
        Debug.Log("GameplayPresenter");
    }
    public void CreateUnit(int ID)
    {
        Pool.GetObject(ID);
    }

    public void ClearUnitField()
    {
        Pool.ReturnAllActiveObjects();
    }

    public void DeleteUnitFromField(Unit unit)
    {
        Pool.ReturnObject(unit);
    }

    

}
