using Assets.Scripts.Architecture.ServiceLocator;

public interface IUnitStats : IService
{
    public int GetPowerOfUnit(int unitID);
    public int GetSpecialCostOfUnit(int unitID);
    public int GetBaseCostOfUnit(int unitID);
}

