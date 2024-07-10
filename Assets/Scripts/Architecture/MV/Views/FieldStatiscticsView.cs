using Assets.Scripts.Architecture.EventBus;
using Assets.Scripts.Architecture.ServiceLocator;
using UnityEngine;
using UnityEngine.UI;

public class FieldStatiscticsView : MonoBehaviour
{
    [SerializeField] private Text _moneyLeft;
    [SerializeField] private Text _allPower;
    [SerializeField] private Text _unitsQuantity;

    public void Init()
    {
        ServiceLocator.Get<EventBus>().FieldStatisticChanged.Subscribe(DisplayPowerAndQuantity);
    }

    private void DisplayPowerAndQuantity(int power, int quantity)
    {
        _allPower.text = power.ToString();
        _unitsQuantity.text = quantity.ToString();
    }

    private void DisplayMoneyLeft(int money)
    {
        _moneyLeft.text = money.ToString();
    }
}
