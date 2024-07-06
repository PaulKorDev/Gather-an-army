using Assets.Scripts.Architecture.ServiceLocator;
using UnityEngine;
using UnityEngine.UI;

//This class manages unit's prefabs: Load from Resources at start, Set image for prefab
public class UnitPrefabsConfig : IService
{
    private GameObject _prefabUnit1;
    private GameObject _prefabUnit2;
    private GameObject _prefabUnit3;

    public GameObject PrefabUnit1 => _prefabUnit1;
    public GameObject PrefabUnit2 => _prefabUnit2;
    public GameObject PrefabUnit3 => _prefabUnit3;

    private Sprite _spriteUnit1;
    private Sprite _spriteUnit2;
    private Sprite _spriteUnit3;

    private UnitSpritesSetter _unitSpritesSetter;
    
    public void UpdateUnitSprites()
    {
        _unitSpritesSetter = ServiceLocator.Get<UnitSpritesSetter>();

        _spriteUnit1 = _unitSpritesSetter.SpriteUnit1;
        _spriteUnit2 = _unitSpritesSetter.SpriteUnit2;
        _spriteUnit3 = _unitSpritesSetter.SpriteUnit3;
    }

    public void InitUnitPrefabs()
    {
        //Subsribe to reactive property

        UpdateUnitSprites();

        InitUnit1Pref();
        InitUnit2Pref();
        InitUnit3Pref();
    }
    
    private void InitUnit1Pref() => InitUnitPref(ref _prefabUnit1, PrefabPaths.UNIT_1, _spriteUnit1);
    private void InitUnit2Pref() => InitUnitPref(ref _prefabUnit2, PrefabPaths.UNIT_2, _spriteUnit2);
    private void InitUnit3Pref() => InitUnitPref(ref _prefabUnit3, PrefabPaths.UNIT_3, _spriteUnit3);

    private void InitUnitPref(ref GameObject unitPrefab, string prefabPath, Sprite unitSprite)
    {
        LoadPrefab(ref unitPrefab, prefabPath);
        SetImageToPrefab(out Image unitImageComponent, unitPrefab, unitSprite);
    }

    private void LoadPrefab(ref GameObject prefab, string prefabPath)
    {
        if (prefab != null)
            return;
        prefab = Resources.Load<GameObject>(prefabPath);
        if (prefab == null) throw new System.Exception("UnitPrefab is null. Check path in Resurces.Load or prefab in folder");
    }

    private void SetImageToPrefab(out Image imageComponent, GameObject prefab, Sprite sprite)
    {
        imageComponent = prefab.GetComponentInChildren<Image>();
        if (imageComponent == null) throw new System.Exception("unitImageComponent is null. Check exist component on Prefab");
        imageComponent.sprite = sprite;      
    }

}
