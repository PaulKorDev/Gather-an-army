public class UnitStatsHardCode : IUnitStats
{
    public int GetBasePowerOfUnit(int unitID)
    {
        switch (unitID) { 
            case 1: return 5;
            case 2: return 6;
            case 3: return 7;
            default: throw new System.Exception($"Hasn't unit with id: {unitID}");
        }
    }

    public int GetPowerOfUnit(int unitID)
    {
        switch (unitID)
        {
            case 1: return 88;
            case 2: return 55;
            case 3: return 34;
            default: throw new System.Exception($"Hasn't unit with id: {unitID}");
        }
    }

    public int GetSpecialCostOfUnit(int unitID)
    {
        switch (unitID)
        {
            case 1: return 9;
            case 2: return 7;
            case 3: return 3;
            default: throw new System.Exception($"Hasn't unit with id: {unitID}");
        }
    }
}
