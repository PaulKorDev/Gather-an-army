﻿using Units;
using Assets.Scripts.Architecture.ObjectPool;
using Assets.Scripts.Architecture.ServiceLocator;
using UnityEngine.UI;
using System.Collections.Generic;
public class UnitObjectPool : ObjectPool<Unit>, IService
{
    private static int _preload = 12;
    private static bool _autoExpand = true;
    private static int _poolLimit = 24;

    public UnitObjectPool(List<Unit> activeUnitsList) : base(activeUnitsList, FactoryMethod, GetEffect, ReturnEffect, _preload, _autoExpand, _poolLimit)
    {
    }

    private static Unit FactoryMethod()
    {
        var createdUnit = ServiceLocator.Get<UnitsFactory>().CreateUnit();
        return createdUnit;
    }
    private static void GetEffect(Unit unit, int id) {
        unit.GetComponentInChildren<Image>().sprite = ServiceLocator.Get<UnitSpritesSetter>().GetSpriteOfUnit(id);
        ServiceLocator.Get<UnitsFactory>().InitAndSetCostUnit(unit, id);
        unit.gameObject.SetActive(true);
    }
    private static void ReturnEffect(Unit obj)
    {
        obj.gameObject.SetActive(false);
    }
}

