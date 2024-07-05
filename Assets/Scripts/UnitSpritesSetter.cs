using UnityEngine;

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

public class UnitSpritesSetter
{
    public Sprite SpriteUnit1 { get; private set;}
    public Sprite SpriteUnit2 { get; private set;}
    public Sprite SpriteUnit3 { get; private set;}

    private UnitType _unitSprites;
    //2 Create a new class and inherit it from UnitType
    private UnitsTypeFantasy _fantasySprites;
    private UnitsTypeSoldier _soldiersSprites;

    public UnitSpritesSetter()
    {
        //3 Create instance in constructor
        _fantasySprites = new UnitsTypeFantasy();
        _soldiersSprites = new UnitsTypeSoldier();
    }


    public void SetSprites(UnitsTypes type)
    {
        SelectTypeOfUnits(type);

        SpriteUnit1 = _unitSprites.SpriteUnit1;
        SpriteUnit2 = _unitSprites.SpriteUnit1;
        SpriteUnit3 = _unitSprites.SpriteUnit1;
    }
    private void SelectTypeOfUnits(UnitsTypes type) {

        //4 Adjust switching in SelectTypeOfUnits method
        if (type == UnitsTypes.Fantasy)
            _unitSprites = _fantasySprites;
        if (type == UnitsTypes.Soliders)
            _unitSprites = _soldiersSprites;
    }
}



