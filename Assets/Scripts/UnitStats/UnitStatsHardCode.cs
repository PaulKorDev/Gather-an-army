using UnityEngine;

public class UnitStatsHardCode : IUnitStats
{
    public int GetBaseCostOfUnit(int unitID)
    {
        switch (unitID) { 
            case 1: return 10;
            case 2: return 20;
            case 3: return 30;
            default: throw new System.Exception($"Hasn't unit with id: {unitID}");
        }
    }

    public int GetPowerOfUnit(int unitID)
    {
        switch (unitID)
        {
            case 1: return 7;
            case 2: return 5;
            case 3: return 3;
            default: throw new System.Exception($"Hasn't unit with id: {unitID}");
        }
    }

    public int GetSpecialCostOfUnit(int unitID)
    {
        switch (unitID)
        {
            case 1: return 15;
            case 2: return 40;
            case 3: return 12;
            default: throw new System.Exception($"Hasn't unit with id: {unitID}");
        }
    }
}
