using Assets.Scripts.Architecture.EventBus;
using Assets.Scripts.Architecture.ServiceLocator;
using UnityEngine;

public class SpriteSwitcherTest : MonoBehaviour
{
    [SerializeField] private UnitsTypes _unitType;

    private void OnValidate()
    {
        ServiceLocator.Get<EventBus>().TrigerUnitsTypeChanged(_unitType);
    }

}
