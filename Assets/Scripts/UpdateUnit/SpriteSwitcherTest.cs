using Assets.Scripts.Architecture.ServiceLocator;
using UnityEngine;

public class SpriteSwitcherTest : MonoBehaviour
{
    [SerializeField] private UnitsTypes _unitType;

    private void OnValidate()
    {
        ServiceLocator.Get<UnitSpritesSetter>().InitSprites(_unitType);
    }

}
