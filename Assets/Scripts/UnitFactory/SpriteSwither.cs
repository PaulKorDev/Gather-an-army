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

    public void UpdateSprites(UnitsTypes type)
    {
        _spritesSetter.InitSprites(type);
        UpdateUnitPrefab(type);
        UpdateUnitSpawnButton(type);
        UpdateUnitsOnField(type);
    }

    private void UpdateUnitPrefab(UnitsTypes type) => ServiceLocator.Get<UnitPrefabsConfig>().InitUnitPrefabs();

    private void UpdateUnitSpawnButton(UnitsTypes type) => ServiceLocator.Get<ButtonsView>().UpdateUnitButtonSprites();


    private void UpdateUnitsOnField(UnitsTypes type)
    {
        List<Unit> unitsOnField = ServiceLocator.Get<UnitsFactory>().GetSpawnedUnitList();
        foreach (Unit unit in unitsOnField) { 
            int id = unit.ID;
            unit.GetComponentInChildren<Image>().sprite = _spritesSetter.GetSpriteOfUnit(id);
        }
    }

}
