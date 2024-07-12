using Assets.Scripts.Architecture.EventBus;
using Assets.Scripts.Architecture.ServiceLocator;
using System.Collections.Generic;
using System.Threading.Tasks;
using Units;
using UnityEngine;
using UnityEngine.UI;

public class UnitsUpdater : IService
{
    private List<Unit> _activePool;
    private UnitSpritesSetter _spriteSetter;
    public UnitsUpdater(GameplayReactive reactive, EventBus eventBus, UnitSpritesSetter spritesSetter)
    {
        _spriteSetter = spritesSetter;
        _activePool = reactive.ActiveUnits.GetUsualList();
        reactive.ActiveUnits.OnListChanged += UpdateOrderUnitsOnField;
        eventBus.UnitsTypeChanged.Subscribe(UpdateUnitsSpritesOnField);
        Debug.Log("UnitsUpdater");
    }

    #region Methods for update order on field
    private async void UpdateOrderUnitsOnField(List<Unit> activePool)
    {
        Debug.Log("UpdateOrderUnitsOnField");
        await SortActiveObjectOnField(activePool);
        await UpdateCostOfUnitsOnField(activePool);
    }
    private Task SortActiveObjectOnField(List<Unit> activeUnits)
    {
        foreach (Unit unit in activeUnits)
        {
            unit.transform.SetAsLastSibling();
        }
        return Task.CompletedTask;
    }
    private Task UpdateCostOfUnitsOnField(List<Unit> activeUnits)
    {
        for (int i = 0; i < activeUnits.Count; i++)
        {
            UpdateCostAndSetText(activeUnits[i], i + 1);
        }
        return Task.CompletedTask;
    }
    #endregion

    #region Methods for update cost and set cost to text
    public void UpdateCostAndSetText(Unit unit, int oridnalNum = -1)
    {
        GetUnitText(unit, out Text unitTextPower, out Text unitTextCost);
        SetCost(unit, unitTextCost, IsThird(oridnalNum));
        SetPowerAndCostText(unit, unitTextPower, unitTextCost);
    }
    private void GetUnitText(Unit unit, out Text unitTextPower, out Text unitTextCost)
    {
        Text[] unitTexts = unit.gameObject.GetComponentsInChildren<Text>(true);
        unitTextPower = unitTexts[0];
        unitTextCost = unitTexts[1];
    }
    private void SetPowerAndCostText(Unit unit, Text textPower, Text textCost)
    {
        textCost.text = unit.GetCost().ToString();
        textPower.text = unit.GetPower().ToString();
    }

    #region SetCost
    private void SetCost(Unit unit, Text costText, bool isSetSpecialCost)
    {
        if (isSetSpecialCost)
        {
            unit.SetSpecialCost();
            costText.color = new Color(141f / 255f, 131f / 255f, 1);//Get color from Scriptable
        }
        else
        {
            unit.SetBaseCost();
            costText.color = new Color(1, 1, 1);//Get color from Scriptable
        }

    }
    private bool IsThird(int ordinalNum)
    {
        if (ordinalNum == -1)
            return IsThird();
        else
            return (ordinalNum) % 3 == 0;
    }
    private bool IsThird()
    {
        return (_activePool.Count + 1) % 3 == 0;
    }
    #endregion
    #endregion

    #region method for update sprite for unit
    public void SetImageToUnit(Unit unit, int id)
    {
        unit.GetComponentInChildren<Image>().sprite = _spriteSetter.GetSpriteOfUnit(id);
    }

    private void UpdateUnitsSpritesOnField()
    {
        foreach (Unit unit in _activePool)
        {
            int id = unit.GetID();
            SetImageToUnit(unit, id);
        }
    }
    #endregion
}
