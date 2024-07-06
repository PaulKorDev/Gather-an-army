using Assets.Scripts.Architecture.ServiceLocator;
using System.Collections.Generic;
using Units;
using UnityEngine;

public class GameplayServiceLocator : MonoBehaviour
{
    [SerializeField] private Transform _containerForUnits;
    [SerializeField] private ButtonsView _buttonView;

    private IUnitStats _unitStats;
    private UnitsFactory _unitsFactory;
    private GameplayPresenter _gameplayPresenter;
    private List<Unit> _spawnedUnits = new List<Unit>();

    public void Init()
    {
        ServiceLocator.Register(_buttonView);

        _unitStats = new UnitStatsHardCode();
        ServiceLocator.Register(_unitStats);

        _unitsFactory = new UnitsFactory(_spawnedUnits, _containerForUnits, _unitStats);
        ServiceLocator.Register(_unitsFactory);

        _gameplayPresenter = new GameplayPresenter();
        ServiceLocator.Register(_gameplayPresenter);

    }
    private void OnDestroy()
    {
        try
        {
            ServiceLocator.Unregister(_unitStats);
            ServiceLocator.Unregister(_unitsFactory);
            ServiceLocator.Unregister(_gameplayPresenter);
            ServiceLocator.Unregister(_buttonView);

        } catch
        {
            Debug.Log("Unregister error OnDestroy GameplayServiceLocator");
        }
    }
}
