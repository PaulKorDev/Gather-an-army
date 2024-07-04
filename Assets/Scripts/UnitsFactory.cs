using System.Collections.Generic;
using Units;
using UnityEngine;
public class UnitsFactory
{
    private List<Unit> _activeUnits;
    private Transform _container;
    private UnitPrefabsConfig _unitPrefabsConfig = new UnitPrefabsConfig();

    public UnitsFactory(List<Unit> units, Transform container)
    {
        _activeUnits = units;
        _container = container;
        _unitPrefabsConfig.InitUnitPrefabs();
    }
    public Unit CreateUnit1()
    {
        Unit unit = _unitPrefabsConfig.PrefabUnit1.GetComponent<Unit1>();
        SetCost(unit);
        GameObject.Instantiate(unit, _container);
        _activeUnits.Add(unit);
        return unit;
    }
    public Unit CreateUnit2()
    {
        Unit unit = _unitPrefabsConfig.PrefabUnit2.GetComponent<Unit2>();
        SetCost(unit);
        GameObject.Instantiate(unit, _container);
        _activeUnits.Add(unit);
        return unit;

    }
    public Unit CreateUnit3()
    {
        Unit unit = _unitPrefabsConfig.PrefabUnit3.GetComponent<Unit3>();
        SetCost(unit);
        GameObject.Instantiate(unit, _container);
        _activeUnits.Add(unit);
        return unit;

    }

    private bool IsThird()
    {
        return (_activeUnits.Count + 1) % 3 == 0;
    }

    private void SetCost(Unit unit)
    {
        if (IsThird())
            unit.SetSpecialCost();
        else
            unit.SetBaseCost();
    }

}
