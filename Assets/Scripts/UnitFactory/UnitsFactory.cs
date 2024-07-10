using Assets.Scripts.Architecture.ServiceLocator;
using Units;
using UnityEngine;
using UnityEngine.UI;
public class UnitsFactory : IService
{
    private Transform _container;
    private Unit _prefab;
    private IUnitStats _unitStats;

    public UnitsFactory(Transform container, IUnitStats unitStats)
    {

        _unitStats = unitStats;
        _container = container;
        _prefab = Resources.Load<Unit>(PrefabPaths.UNIT);
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
        ServiceLocator.Get<UnitsUpdater>().UpdateCostAndSetText(unit);
    }
    private Unit CreateConcreteUnit(int unitID)
    {
        InstantiateUnit(out Unit unit);
        InitAndSetCostUnit(unit, unitID);
        AddListenerForButton(unit);
        return unit;
    }
    private void InstantiateUnit(out Unit concreteUnit)
    {
        var createdUnit = GameObject.Instantiate(_prefab, _container);
        concreteUnit = createdUnit.GetComponent<Unit>();
    }
    private void AddListenerForButton(Unit unit)
    {
        unit.gameObject.GetComponent<Button>().onClick.AddListener(() => ServiceLocator.Get<GameplayPresenter>().DeleteUnitFromField(unit));
    }
    private void InitUnit(Unit concreteUnit, int idUnit) {
        concreteUnit.Init(_unitStats.GetPowerOfUnit(idUnit), _unitStats.GetSpecialCostOfUnit(idUnit), _unitStats.GetBaseCostOfUnit(idUnit), idUnit);
    }
    



}
