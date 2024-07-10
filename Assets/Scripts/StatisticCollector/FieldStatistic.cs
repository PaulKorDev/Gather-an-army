using Assets.Scripts.Architecture.EventBus;
using Assets.Scripts.Architecture.ServiceLocator;
using System.Collections.Generic;
using Units;

public class FieldStatistic
{
    private int _allPower = 0;
    private int _quantity = 0;

    public FieldStatistic()
    {
        
        //ServiceLocator.Get<EventBus>().UnitsQuantityChanged.Subscribe(UpdateBalance);
        ServiceLocator.Get<GameplayReactive>().ActiveUnits.OnListChanged += UpdateAllPowerAndQuantity;
    }

    private void UpdateBalance()
    {

    }
    private void UpdateAllPowerAndQuantity(List<Unit> units)
    {
        UpdateAllPower(units);
        UpdateQuantity(units);

        ServiceLocator.Get<EventBus>().FieldStatisticChanged.Trigger(_allPower, _quantity);
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
