using Assets.Scripts.Architecture.ServiceLocator;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsView : MonoBehaviour, IService
{
    [SerializeField] private Button _buttClearUnitsField;
    [SerializeField] private Button _buttSpawnUnit1;
    [SerializeField] private Button _buttSpawnUnit2;
    [SerializeField] private Button _buttSpawnUnit3;

    private UnitsFactory _unitsFactory;

    public void Init(UnitsFactory unitsFactory)
    {
        _unitsFactory = unitsFactory;

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
    }
    private void ClearUnitsField()
    {
        
    }


}
