using Assets.Scripts.Architecture.ServiceLocator;
using UnityEngine;

public class SpriteSwitcherTest : MonoBehaviour
{
    [SerializeField] private UnitsTypes _unitType;

    SpriteSwitcher _spriteSwitcher; 

    private void OnValidate()
    {
        if (_spriteSwitcher == null)
            _spriteSwitcher = new SpriteSwitcher();
        _spriteSwitcher.UpdateAllSprites(_unitType);
    }

}
