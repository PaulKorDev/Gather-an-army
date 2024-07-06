using Assets.Scripts.Architecture.ServiceLocator;
using UnityEngine;

public class SpriteSwitcherTest : MonoBehaviour
{
    [SerializeField] private UnitsTypes _unitType;

    SpriteSwither _spriteSwither; 

    private void OnValidate()
    {
        if (_spriteSwither == null)
            _spriteSwither = new SpriteSwither();
        _spriteSwither.UpdateSprites(_unitType);
    }

}
