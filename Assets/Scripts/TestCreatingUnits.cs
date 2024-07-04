using System;
using System.Collections.Generic;
using Units;
using UnityEngine;
using UnityEngine.UI;

public class TestCreatingUnits : MonoBehaviour
{
    [SerializeField] private Button _buttClearUnitsField;
    [SerializeField] private Button _buttSpawnUnit1;
    [SerializeField] private Button _buttSpawnUnit2;
    [SerializeField] private Button _buttSpawnUnit3;
    [SerializeField] private Transform _container;
    private List<Unit> _spawnedUnits = new List<Unit>();
    private UnitsFactory _unitsFactory;
    private int _allUnitsCount;

    private void Awake()
    {
        _unitsFactory = new UnitsFactory(_spawnedUnits, _container);

        _buttClearUnitsField.onClick.AddListener(ClearUnitsField);
        _buttSpawnUnit1.onClick.AddListener(() => SpawnUnit(1));
        _buttSpawnUnit2.onClick.AddListener(() => SpawnUnit(2));
        _buttSpawnUnit3.onClick.AddListener(() => SpawnUnit(3));
    }

    private void SpawnUnit(int id)
    {
        switch (id)
        {
            case 1: _unitsFactory.CreateUnit1(); break;
            case 2: _unitsFactory.CreateUnit2(); break;
            case 3: _unitsFactory.CreateUnit3(); break;
        }
        _allUnitsCount = _spawnedUnits.Count;
        Debug.Log(String.Concat("Units on field: ", _allUnitsCount));
    }
    private void ClearUnitsField()
    {
        _spawnedUnits.Clear();
        _allUnitsCount = _spawnedUnits.Count;
        Debug.Log(String.Concat("Units on field: ", _allUnitsCount));
    }


}
