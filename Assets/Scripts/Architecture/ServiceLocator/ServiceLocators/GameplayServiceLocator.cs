using Assets.Scripts.Architecture.ServiceLocator;
using System.Collections.Generic;
using Units;
using UnityEngine;

public class GameplayServiceLocator : MonoBehaviour
{
    [SerializeField] private Transform _containerForUnits;
    [SerializeField] private ButtonsView _buttonsView;

    private IUnitStats _unitStats;
    private UnitsFactory _unitsFactory;
    private List<Unit> _activeUnits = new List<Unit>();

    public void Init()
    {
        _unitStats = new UnitStatsHardCode();
        ServiceLocator.Register(_unitStats);

        _unitsFactory = new UnitsFactory(_activeUnits, _containerForUnits, _unitStats);

        _buttonsView.Init(_unitsFactory);
    }
    private void OnDestroy()
    {
        try
        {
            ServiceLocator.Unregister(_unitStats);

        } catch
        {
            Debug.Log("Unregister error: unitStats");
        }
    }
}
