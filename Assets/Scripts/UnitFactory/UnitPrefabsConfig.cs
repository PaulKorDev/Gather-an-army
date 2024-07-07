using Assets.Scripts.Architecture.ServiceLocator;
using UnityEngine;
using UnityEngine.UI;

//This class manages unit's prefabs: Load from Resources at start, Set image for prefab
public class UnitPrefabsConfig : IService
{
    private GameObject _prefabUnit;

    public GameObject PrefabUnit => _prefabUnit;

    private Sprite _defaultSpriteUnit;

    private UnitSpritesSetter _unitSpritesSetter;
    
    public void UpdateUnitSprites()
    {
        _unitSpritesSetter = ServiceLocator.Get<UnitSpritesSetter>();

        _defaultSpriteUnit = _unitSpritesSetter.SpriteUnit1;
    }

    public void InitUnitPrefabs()
    {
        //Subsribe to reactive property

        UpdateUnitSprites();

        InitUnitPref(ref _prefabUnit, PrefabPaths.UNIT, _defaultSpriteUnit);
    }
    

    private void InitUnitPref(ref GameObject unitPrefab, string prefabPath, Sprite unitSprite)
    {
        LoadPrefab(ref unitPrefab, prefabPath);
        //SetImageToPrefab(out Image unitImageComponent, unitPrefab, unitSprite);
    }

    private void LoadPrefab(ref GameObject prefab, string prefabPath)
    {
        if (prefab != null)
            return;
        prefab = Resources.Load<GameObject>(prefabPath);
        if (prefab == null) throw new System.Exception("UnitPrefab is null. Check path in Resurces.Load or prefab in folder");
    }

    //private void SetImageToPrefab(out Image imageComponent, GameObject prefab, Sprite sprite)
    //{
    //    imageComponent = prefab.GetComponentInChildren<Image>();
    //    if (imageComponent == null) throw new System.Exception("unitImageComponent is null. Check exist component on Prefab");
    //    imageComponent.sprite = sprite;      
    //}

}
