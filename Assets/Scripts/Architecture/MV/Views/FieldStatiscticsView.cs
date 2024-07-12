using Assets.Scripts.Architecture.EventBus;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class FieldStatiscticsView : MonoBehaviour
{
    [SerializeField] private Text _moneyLeft;
    [SerializeField] private Text _allPower;
    [SerializeField] private Text _unitsQuantity;

    [Inject]
    public void Construct(EventBus eventBus)
    {
        eventBus.FieldStatisticChanged.Subscribe(DisplayPowerAndQuantity);
        Debug.Log("FieldStatiscticsView");
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
