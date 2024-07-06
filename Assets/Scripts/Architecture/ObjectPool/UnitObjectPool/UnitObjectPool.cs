using Units;
using UnityEngine;
using Assets.Scripts.Architecture.ObjectPool;
public class UnitObjectPool : ObjectPool<Unit>
{
    private static int _preload = 12;
    private static bool _autoExpand = true;
    private static int _poolLimit = 24;
    public UnitObjectPool(Unit prefab, Transform container) : base(() => FactoryMethod(prefab, container), GetEffect, ReturnEffect, _preload, _autoExpand, _poolLimit)
    {
    }

    private static Unit FactoryMethod(Unit prefab, Transform container) => GameObject.Instantiate(prefab, container);
    private static void GetEffect(Unit obj, int id) {
        obj.gameObject.SetActive(true);
    }
    private static void ReturnEffect(Unit obj) => obj.gameObject.SetActive(false);
}

