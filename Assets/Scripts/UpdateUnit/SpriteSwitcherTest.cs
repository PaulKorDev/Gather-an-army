using UnityEngine;
using Zenject;

public class SpriteSwitcherTest : MonoBehaviour
{
    [SerializeField] private UnitsTypes _unitType;

    private UnitSpritesSetter _unitSpritesSetter;


    private void OnValidate()
    {
        _unitSpritesSetter?.InitSprites(_unitType);
    }

}
