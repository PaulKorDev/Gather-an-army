using Assets.Scripts.Architecture.ServiceLocator;
using System.Collections.Generic;
using Units;
using UnityEngine;
using UnityEngine.UI;
public class UnitsFactory : IService
{
    private List<Unit> _activeUnits;
    private Transform _container;
    private UnitPrefabsConfig _unitPrefabsConfig;
    private IUnitStats _unitStats;


    public UnitsFactory(List<Unit> units, Transform container, IUnitStats unitStats)
    {
        _unitPrefabsConfig = ServiceLocator.Get<UnitPrefabsConfig>();
        _unitStats = unitStats;
        _activeUnits = units;
        _container = container;
        _unitPrefabsConfig.InitUnitPrefabs();
    }

    public List<Unit> GetSpawnedUnitList() { return _activeUnits; }

    public Unit CreateUnit1()
    {
        var prefab = _unitPrefabsConfig.PrefabUnit1;
        return CreateUnit(prefab, 1);
    }
    public Unit CreateUnit2()
    {
        var prefab = _unitPrefabsConfig.PrefabUnit2;
        return CreateUnit(prefab, 2);
    }
    public Unit CreateUnit3()
    {
        var prefab = _unitPrefabsConfig.PrefabUnit3;
        return CreateUnit(prefab, 3);
    }

    private Unit CreateUnit(GameObject prefab, int unitID)
    {
        InstantiateUnit(prefab, out Unit unit);
        InitUnit(unit, unitID);
        GetUnitText(unit, out Text unitTextPower, out Text unitTextCost);
        SetCost(unit, unitTextCost);
        SetPowerAndCostText(unit, unitTextPower, unitTextCost);
        AddUnitToActiveList(unit);

        return unit;
    }

    private void AddUnitToActiveList(Unit unit) => _activeUnits.Add(unit);

    private void InstantiateUnit(GameObject prefab, out Unit concreteUnit)
    {
        var createdUnit = GameObject.Instantiate(prefab, _container);
        concreteUnit = createdUnit.GetComponent<Unit>();
    }

    private void SetPowerAndCostText(Unit unit, Text textPower, Text textCost) {
        textCost.text = unit.GetCost().ToString();
        textPower.text = unit.GetPower().ToString();
    }
    private void GetUnitText(Unit unit, out Text unitTextPower, out Text unitTextCost)
    {
        Text[] unitTexts = unit.gameObject.GetComponentsInChildren<Text>(true);
        unitTextPower = unitTexts[0];
        unitTextCost = unitTexts[1];
    }
    private void InitUnit(Unit concreteUnit, int idUnit) => concreteUnit.Init(_unitStats.GetPowerOfUnit(idUnit), _unitStats.GetSpecialCostOfUnit(idUnit), _unitStats.GetBaseCostOfUnit(idUnit), idUnit);
    private bool IsThird()
    {
        return (_activeUnits.Count + 1) % 3 == 0;
    }
    private void SetCost(Unit unit, Text costText)
    {
        if (IsThird())
        {
            unit.SetSpecialCost();
            costText.color = new Color(141f/255f, 131f/255f, 1);//Get color from Scriptable
        }
        else
        {
            unit.SetBaseCost();
        }
        
    }
}
