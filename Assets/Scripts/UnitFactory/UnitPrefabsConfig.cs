using UnityEngine;
using UnityEngine.UI;

public class UnitPrefabsConfig 
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
    private UnitsTypes _currentType = 0; //Get from save settings
    
    public void UpdateUnitSprites(UnitsTypes type)
    {
        if (((_spriteUnit1 != null) && (_spriteUnit2 != null) && (_spriteUnit3 != null)) && (type == _currentType))
            return;

        _currentType = type;

        _unitSpritesSetter.SetSprites(_currentType);

        _spriteUnit1 = _unitSpritesSetter.SpriteUnit1;
        _spriteUnit2 = _unitSpritesSetter.SpriteUnit2;
        _spriteUnit3 = _unitSpritesSetter.SpriteUnit3;
    }

    public void InitUnitPrefabs()
    {
        _unitSpritesSetter = new UnitSpritesSetter();

        UpdateUnitSprites(_currentType);

        InitUnit1Pref();
        InitUnit2Pref();
        InitUnit3Pref();
    }
    
    private void InitUnit1Pref() => InitUnitPref(out _prefabUnit1, PrefabPaths.UNIT_1, _spriteUnit1);
    private void InitUnit2Pref() => InitUnitPref(out _prefabUnit2, PrefabPaths.UNIT_2, _spriteUnit2);
    private void InitUnit3Pref() => InitUnitPref(out _prefabUnit3, PrefabPaths.UNIT_3, _spriteUnit3);

    private void InitUnitPref(out GameObject unitPrefab, string prefabPath, Sprite unitSprite)
    {
        LoadPrefab(out unitPrefab, prefabPath);
        SetImageToPrefab(out Image unitImageComponent, unitPrefab, unitSprite);
    }

    private void LoadPrefab(out GameObject prefab, string prefabPath)
    {
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
