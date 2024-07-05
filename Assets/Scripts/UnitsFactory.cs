using System.Collections.Generic;
using Units;
using UnityEngine;
using UnityEngine.UI;
public class UnitsFactory
{
    private List<Unit> _activeUnits;
    private Transform _container;
    private UnitPrefabsConfig _unitPrefabsConfig = new UnitPrefabsConfig();
    private IUnitStats _unitStats;


    public UnitsFactory(List<Unit> units, Transform container, IUnitStats unitStats)
    {
        _unitStats = unitStats;
        _activeUnits = units;
        _container = container;
        _unitPrefabsConfig.InitUnitPrefabs();
    }
    public Unit CreateUnit1()
    {
        var prefab = _unitPrefabsConfig.PrefabUnit1;
        var createdUnit = GameObject.Instantiate(prefab, _container);
        Unit1 concreteUnit = createdUnit.GetComponent<Unit1>();
        return CreateUnit(concreteUnit, concreteUnit, 1);
    }
    public Unit CreateUnit2()
    {
        var prefab = _unitPrefabsConfig.PrefabUnit2;
        var createdUnit = GameObject.Instantiate(prefab, _container);
        Unit2 concreteUnit = createdUnit.GetComponent<Unit2>();
        return CreateUnit(concreteUnit, concreteUnit, 2);
    }
    public Unit CreateUnit3()
    {
        var prefab = _unitPrefabsConfig.PrefabUnit3;
        var createdUnit = GameObject.Instantiate(prefab, _container);
        Unit3 concreteUnit = createdUnit.GetComponent<Unit3>();
        return CreateUnit(concreteUnit, concreteUnit, 3);
    }

    private Unit CreateUnit(Unit unit, IConcreteUnit concreteUnit, int unitID)
    {
        InitUnit(concreteUnit, unitID);
        GameObject unitGO = unit.gameObject;
        Text[] unitTexts = unitGO.GetComponentsInChildren<Text>(true);
        Text unitTextPower = unitTexts[0];
        Text unitTextCost = unitTexts[1];
        SetCost(unit, unitTextCost);
        unitTextCost.text = unit.GetCost().ToString();
        unitTextPower.text = unit.GetPower().ToString();
        _activeUnits.Add(unit);
        return unit;
    }
    private void InitUnit(IConcreteUnit concreteUnit, int idUnit) => concreteUnit.Init(_unitStats.GetPowerOfUnit(idUnit), _unitStats.GetSpecialCostOfUnit(idUnit), _unitStats.GetBaseCostOfUnit(idUnit));
    private bool IsThird()
    {
        return (_activeUnits.Count + 1) % 3 == 0;
    }

    private void SetCost(Unit unit, Text costText)
    {
        if (IsThird())
        {
            unit.SetSpecialCost();
            costText.color = new Color(141f/255f, 131f/255f, 1);//new Color(141,131,255); //Get color from Scriptable
        }
        else
        {
            unit.SetBaseCost();
        }
        
    }

}
