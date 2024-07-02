using System.Collections.Generic;
using Units;
public class UnitsFactory
{
    private List<Unit> _activeUnits;
    public UnitsFactory(List<Unit> units)
    {
        _activeUnits = units;
    }
    public Unit CreateUnit1()
    {
        Unit unit = new Unit1(10,11,12); //TODO: Init from IUnitStates
        SetCost(unit);
        _activeUnits.Add(unit);
        return unit;
    }
    public Unit CreateUnit2()
    {
        Unit unit = new Unit2(21,22,23); //TODO: Init from IUnitStates
        SetCost(unit);
        _activeUnits.Add(unit);
        return unit;

    }
    public Unit CreateUnit3()
    {
        Unit unit = new Unit3(31,32,33); //TODO: Init from IUnitStates
        SetCost(unit);
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
