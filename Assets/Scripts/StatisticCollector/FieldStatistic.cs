using Assets.Scripts.Architecture.EventBus;
using Assets.Scripts.Architecture.ServiceLocator;
using System.Collections.Generic;
using Units;
using UnityEngine;

public class FieldStatistic
{
    private int _allPower = 0;
    private int _quantity = 0;

    private EventBus _eventBus;

    public FieldStatistic(GameplayReactive reactive, EventBus eventBus)
    {
        _eventBus = eventBus;
        //ServiceLocator.Get<EventBus>().UnitsQuantityChanged.Subscribe(UpdateBalance);
        reactive.ActiveUnits.OnListChanged += UpdateAllPowerAndQuantity;
        Debug.Log("Field stats");
    }

    private void UpdateBalance()
    {

    }
    private void UpdateAllPowerAndQuantity(List<Unit> units)
    {
        Debug.Log("UpdateAllPowerAndQuantity");
        UpdateAllPower(units);
        UpdateQuantity(units);

        _eventBus.FieldStatisticChanged.Trigger(_allPower, _quantity);
    }
    private void UpdateAllPower(List<Unit> units)
    {
        _allPower = 0;

        foreach (var unit in units) {
            _allPower += unit.GetPower();
        }
    }
    private void UpdateQuantity(List<Unit> units)
    {
        _quantity = units.Count;
    }
}
