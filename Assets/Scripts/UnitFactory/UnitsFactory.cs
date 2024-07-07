using Assets.Scripts.Architecture.ServiceLocator;
using System.Collections.Generic;
using Units;
using UnityEngine;
using UnityEngine.UI;
public class UnitsFactory : IService
{
    private List<Unit> _unitsOnField;
    private Transform _container;
    private UnitPrefabsConfig _unitPrefabsConfig;
    private IUnitStats _unitStats;


    public UnitsFactory(List<Unit> units, Transform container, IUnitStats unitStats)
    {
        _unitsOnField = units;
        _unitPrefabsConfig = ServiceLocator.Get<UnitPrefabsConfig>();
        _unitStats = unitStats;
        _container = container;
        _unitPrefabsConfig.InitUnitPrefabs();
    }

    public Unit CreateUnit(int ID = 1)
    {
        switch (ID) {
            case 1: return CreateConcreteUnit(1);
            case 2: return CreateConcreteUnit(2);
            case 3: return CreateConcreteUnit(3);
            default: throw new System.Exception($"UnitFactory: hasn't id {ID}");
        }
    }

    public void InitAndSetCostUnit(Unit unit, int unitID)
    {
        InitUnit(unit, unitID);
        GetUnitText(unit, out Text unitTextPower, out Text unitTextCost);
        SetCost(unit, unitTextCost);
        SetPowerAndCostText(unit, unitTextPower, unitTextCost);
    }
    private Unit CreateConcreteUnit(int unitID)
    {
        InstantiateUnit(out Unit unit);
        InitAndSetCostUnit(unit, unitID);

        return unit;
    }

    private void InstantiateUnit(out Unit concreteUnit)
    {
        var prefab = _unitPrefabsConfig.PrefabUnit;
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
        return (_unitsOnField.Count + 1) % 3 == 0;
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
            costText.color = new Color(1, 1, 1);//Get color from Scriptable
        }
        
    }
}
