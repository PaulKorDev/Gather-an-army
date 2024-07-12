using Units;
using Assets.Scripts.Architecture.ObjectPool;
using Assets.Scripts.Architecture.ServiceLocator;
using Zenject;
using UnityEngine;

public class UnitObjectPool
{
    private static int _preload = 12;
    private static bool _autoExpand = true;
    private static int _poolLimit = 24;

    private UnitsFactory _unitsFactory;
    private UnitsUpdater _unitsUpdater;

    private ObjectPool<Unit> _objectPool;

    public UnitObjectPool(GameplayReactive reactive, UnitsFactory unitsFactory, UnitsUpdater unitsUpdater) 
    {
        _unitsFactory = unitsFactory;
        _unitsUpdater = unitsUpdater;

        _objectPool = new ObjectPool<Unit>(reactive.ActiveUnits, FactoryMethod, GetEffect, ReturnEffect, _preload, _autoExpand, _poolLimit);
        
        Debug.Log("UnitObjectPool");
    }
  
    #region Constructor methods
    private Unit FactoryMethod()
    {
        var createdUnit = _unitsFactory.CreateUnit();
        return createdUnit;
    }
    private void ReturnEffect(Unit obj)
    {
        obj.gameObject.SetActive(false);
    }
    private void GetEffect(Unit unit, int id) {
        _unitsUpdater.SetImageToUnit(unit, id);
        _unitsFactory.InitAndSetCostUnit(unit, id);
        unit.gameObject.transform.SetAsLastSibling();
        unit.gameObject.SetActive(true);

    }
    #endregion

    public void GetObject(int ID)
    {
        _objectPool.GetObject(ID);
    }
    public void ReturnAllActiveObjects()
    {
        _objectPool.ReturnAllActiveObjects();
    }
    public void ReturnObject(Unit unit)
    {
        _objectPool.ReturnObject(unit);
    }
    



}

