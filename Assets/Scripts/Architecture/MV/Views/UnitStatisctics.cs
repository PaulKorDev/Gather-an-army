using System.Collections.Generic;
using Units;
using UnityEngine;
using UnityEngine.UI;

public class UnitStatisctics : MonoBehaviour
{
    [SerializeField] private Text _moneyLeft;
    [SerializeField] private Text _allPower;
    [SerializeField] private Text _unitsQuantity;

    private void DisplayPowerAndQuantity(int power, List<Unit> unitsOnField)
    {
        _allPower.text = power.ToString();
        _unitsQuantity.text = unitsOnField.Count.ToString();
    }

    private void DisplayMoneyLeft(int money)
    {
        _moneyLeft.text = money.ToString();
    }
}
