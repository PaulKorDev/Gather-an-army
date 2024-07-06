using Assets.Scripts.Architecture.ServiceLocator;
using UnityEngine;

//This class only init, store and return unit's sprites

/*If you want to add new type of units:
 * 1. Create new type in enum UnitsType
 * 2. Create a new class and inherit it from UnitType, 
 * 3. Create instance in constructor
 * 4. Adjust switching in SelectTypeOfUnits method
*/

public enum UnitsTypes
{
    //1 - Create new type in enum UnitsType
    Fantasy,
    Soliders
}

public class UnitSpritesSetter : IService
{
    public Sprite SpriteUnit1 { get; private set;}
    public Sprite SpriteUnit2 { get; private set;}
    public Sprite SpriteUnit3 { get; private set;}

    private UnitType _unitSprites;
    //2 Create a new class and inherit it from UnitType
    private UnitsTypeFantasy _fantasySprites;
    private UnitsTypeSoldier _soldiersSprites;

    private UnitsTypes _currentType = 0;

    public UnitSpritesSetter()
    {
        //3 Create instance in constructor
        _fantasySprites = new UnitsTypeFantasy();
        _soldiersSprites = new UnitsTypeSoldier();
    }

    public void InitSprites(UnitsTypes type)
    {
        if (_unitSprites != null && type == _currentType)
            return;

        _currentType = type;

        SelectTypeOfUnits(type);

        SpriteUnit1 = _unitSprites.SpriteUnit1;
        SpriteUnit2 = _unitSprites.SpriteUnit2;
        SpriteUnit3 = _unitSprites.SpriteUnit3;
    }

    public Sprite GetSpriteOfUnit(int ID)
    {
        switch (ID)
        {
            case 1: return SpriteUnit1;
            case 2: return SpriteUnit2;
            case 3: return SpriteUnit3;
            default: throw new System.Exception($"GetSpriteOfUnit: hasn't ID {ID}");
        }
    }

    private void SelectTypeOfUnits(UnitsTypes type) {

        //4 Adjust switching in SelectTypeOfUnits method
        if (type == UnitsTypes.Fantasy)
            _unitSprites = _fantasySprites;
        if (type == UnitsTypes.Soliders)
            _unitSprites = _soldiersSprites;
    }
}



