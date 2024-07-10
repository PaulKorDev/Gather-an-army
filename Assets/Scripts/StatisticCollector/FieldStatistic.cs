using Assets.Scripts.Architecture.EventBus;
using Assets.Scripts.Architecture.ServiceLocator;
using System.Collections.Generic;
using Units;

public class FieldStatistic
{
    private int _allPower = 0;
    private int _quantity = 0;

    private List<Unit> unitsOnField;

    public FieldStatistic()
    {
        unitsOnField = ServiceLocator.Get<UnitObjectPool>().GetAllActiveObjects();
        //ServiceLocator.Get<EventBus>().UnitsQuantityChanged.Subscribe(UpdateBalance);
        ServiceLocator.Get<EventBus>().UnitsQuantityChanged.Subscribe(UpdateAllPowerAndQuantity);
    }

    private void UpdateBalance()
    {

    }
    private void UpdateAllPowerAndQuantity()
    {
        UpdateAllPower();
        UpdateQuantity();

        ServiceLocator.Get<EventBus>().FieldStatisticChanged.Trigger(_allPower, _quantity);
    }
    private void UpdateAllPower()
    {
        _allPower = 0;

        foreach (var unit in unitsOnField) {
            _allPower += unit.GetPower();
        }
    }
    private void UpdateQuantity()
    {
        _quantity = unitsOnField.Count;
    }
}
