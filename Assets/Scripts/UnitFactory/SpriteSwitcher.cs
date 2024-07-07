using Assets.Scripts.Architecture.EventBus;
using Assets.Scripts.Architecture.ServiceLocator;
using System.Collections.Generic;
using Units;
using UnityEngine.UI;

public class SpriteSwitcher
{
    private UnitSpritesSetter _spritesSetter;

    public SpriteSwitcher()
    {
        _spritesSetter = ServiceLocator.Get<UnitSpritesSetter>();
        
    }

    public void UpdateAllSprites(UnitsTypes type)
    {
        UpdateUnitPrefab(type);
        UpdateUnitSpawnButton(type);
        UpdateUnitsSpritesOnField(type);
    }

    public void SetImageToUnit(Unit unit, int id)
    {
        unit.GetComponentInChildren<Image>().sprite = ServiceLocator.Get<UnitSpritesSetter>().GetSpriteOfUnit(id);
    }

    #region UpdateAllSprites methods
    private void UpdateUnitPrefab(UnitsTypes type)
    {
        _spritesSetter.InitSprites(type);
        ServiceLocator.Get<UnitPrefabsConfig>().InitUnitPrefabs();
    }
    private void UpdateUnitSpawnButton(UnitsTypes type)
    {
        _spritesSetter.InitSprites(type);
        ServiceLocator.Get<ButtonsView>().UpdateUnitButtonSprites();

    }
    private void UpdateUnitsSpritesOnField(UnitsTypes type)
    {
        _spritesSetter.InitSprites(type);
        List<Unit> unitsOnField = ServiceLocator.Get<UnitObjectPool>().GetAllActiveObjects();
        foreach (Unit unit in unitsOnField) { 
            int id = unit.GetID();
            SetImageToUnit(unit, id);
        }
    }
    #endregion
}
