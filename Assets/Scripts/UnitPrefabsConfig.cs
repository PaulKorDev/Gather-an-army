using UnityEngine;
using UnityEngine.UI;

public class UnitPrefabsConfig 
{
    public GameObject PrefabUnit1 { get; private set; }
    public GameObject PrefabUnit2 { get; private set; }
    public GameObject PrefabUnit3 { get; private set; }
    public void InitUnitPrefabs()
    {
        InitUnit1Pref();
        InitUnit2Pref();
        InitUnit3Pref();
    }
    private void InitUnit1Pref()
    {
        PrefabUnit1 = Resources.Load<GameObject>(PrefabPaths.UNIT_1);
        Sprite spriteUnit1 = Resources.Load<Sprite>("Units/Sprites/Fantasy/knight_128x128");
        if (PrefabUnit1 != null && spriteUnit1 != null)
        {
            Image unit1ImageComponent = PrefabUnit1.GetComponentInChildren<Image>();
            if (unit1ImageComponent != null)
            {
                unit1ImageComponent.sprite = spriteUnit1;
            }
            
        }
    }
    private void InitUnit2Pref()
    {
        PrefabUnit2 = Resources.Load<GameObject>(PrefabPaths.UNIT_2);
        Sprite spriteUnit2 = Resources.Load<Sprite>("Units/Sprites/Fantasy/mage_128x128");
        if (PrefabUnit2 != null && spriteUnit2 != null)
        {
            Image unit2ImageComponent = PrefabUnit2.GetComponentInChildren<Image>();
            if (unit2ImageComponent != null)
            {
                unit2ImageComponent.sprite = spriteUnit2;
            }

        }
    }
    private void InitUnit3Pref()
    {
        PrefabUnit3 = Resources.Load<GameObject>(PrefabPaths.UNIT_3);
        Sprite spriteUnit3 = Resources.Load<Sprite>("Units/Sprites/Fantasy/archer_128x128");
        if (PrefabUnit3 != null && spriteUnit3 != null)
        {
            Image unit3ImageComponent = PrefabUnit3.GetComponentInChildren<Image>();
            if (unit3ImageComponent != null)
            {
                unit3ImageComponent.sprite = spriteUnit3;
            }

        }
    }
}
