using Assets.Scripts.Architecture.ServiceLocator;
using System.Collections.Generic;
using Units;
using UnityEngine.UI;

public class SpriteSwither
{
    private UnitSpritesSetter _spritesSetter;

    public SpriteSwither()
    {
        _spritesSetter = ServiceLocator.Get<UnitSpritesSetter>();
    }

    public void UpdateAllSprites(UnitsTypes type)
    {
        UpdateUnitPrefab(type);
        UpdateUnitSpawnButton(type);
        UpdateUnitsOnField(type);
    }

    public void UpdateUnitPrefab(UnitsTypes type)
    {
        _spritesSetter.InitSprites(type);
        ServiceLocator.Get<UnitPrefabsConfig>().InitUnitPrefabs();
    }
    public void UpdateUnitSpawnButton(UnitsTypes type)
    {
        _spritesSetter.InitSprites(type);
        ServiceLocator.Get<ButtonsView>().UpdateUnitButtonSprites();

    }
    public void UpdateUnitsOnField(UnitsTypes type)
    {
        _spritesSetter.InitSprites(type);
        List<Unit> unitsOnField = ServiceLocator.Get<UnitObjectPool>().GetAllActiveObjects();
        foreach (Unit unit in unitsOnField) { 
            int id = unit.ID;
            unit.GetComponentInChildren<Image>().sprite = _spritesSetter.GetSpriteOfUnit(id);
        }
        

    }

}
