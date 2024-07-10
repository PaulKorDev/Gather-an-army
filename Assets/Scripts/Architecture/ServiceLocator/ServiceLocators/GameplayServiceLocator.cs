using Assets.Scripts.Architecture.EventBus;
using Assets.Scripts.Architecture.ObjectPool;
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
    private UnitSpritesSetter _unitSpritesSetter;
    private GameplayPresenter _gameplayPresenter;
    private UnitsUpdater _unitsUpater;
    private UnitObjectPool _unitObjectPool;
    private List<Unit> _spawnedUnits = new List<Unit>();

    public void RegisterAllServices()
    {
        RegisterUnitStats();
        RegisterUnitSpritesSetter();
        RegisterUnitsUpdater();
        RegisterUnitFactory();
        RegisterObjectPool();
        RegisterGameplayPresenter();
        RegisterButtonView();   
    }
    private void OnDestroy()
    {
        try
        {
            ServiceLocator.Unregister(_unitStats);
            ServiceLocator.Unregister(_unitSpritesSetter);
            ServiceLocator.Unregister(_unitsUpater);
            ServiceLocator.Unregister(_unitsFactory);
            ServiceLocator.Unregister(_unitObjectPool);
            ServiceLocator.Unregister(_gameplayPresenter);
            ServiceLocator.Unregister(_buttonView);

        } catch
        {
            Debug.Log("Unregister error OnDestroy GameplayServiceLocator");
        }
    }

    #region Register methods
    private void RegisterUnitStats()
    {
        _unitStats = new UnitStatsHardCode();
        ServiceLocator.Register(_unitStats);
    }
    private void RegisterUnitSpritesSetter()
    {
        _unitSpritesSetter = new UnitSpritesSetter();
        ServiceLocator.Register(_unitSpritesSetter);
    }

    private void RegisterUnitsUpdater()
    {
        _unitsUpater = new UnitsUpdater(_spawnedUnits);
        ServiceLocator.Register(_unitsUpater);
    }
    private void RegisterUnitFactory()
    {
        _unitsFactory = new UnitsFactory(_containerForUnits, _unitStats);
        ServiceLocator.Register(_unitsFactory);
    }
    private void RegisterObjectPool()
    {
        _unitObjectPool = new UnitObjectPool(_spawnedUnits);
        ServiceLocator.Register(_unitObjectPool);
    }
    private void RegisterGameplayPresenter()
    {
        _gameplayPresenter = new GameplayPresenter();
        ServiceLocator.Register(_gameplayPresenter);
    }
    private void RegisterButtonView() => ServiceLocator.Register(_buttonView);
    #endregion
}
