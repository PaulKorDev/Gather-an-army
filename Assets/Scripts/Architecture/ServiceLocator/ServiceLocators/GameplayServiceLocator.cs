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
    private UnitPrefabsConfig _unitsPrefabConfig;
    private UnitSpritesSetter _unitSpritesSetter;
    private GameplayPresenter _gameplayPresenter;
    private UnitObjectPool _unitObjectPool;
    private List<Unit> _spawnedUnits = new List<Unit>();

    public void RegisterAllServices()
    {
        RegisterGameplayPresenter();
        RegisterUnitStats();
        RegisterUnitSpritesSetter();
        RegisterUnitPrefabsConfig();
        RegisterUnitFactory();
        RegisterButtonView();
        RegisterObjectPool();
    }
    private void OnDestroy()
    {
        try
        {
            ServiceLocator.Unregister(_unitStats);
            ServiceLocator.Unregister(_unitsFactory);
            ServiceLocator.Unregister(_gameplayPresenter);
            ServiceLocator.Unregister(_buttonView);
            ServiceLocator.Unregister(_unitSpritesSetter);
            ServiceLocator.Unregister(_unitsPrefabConfig);

        } catch
        {
            Debug.Log("Unregister error OnDestroy GameplayServiceLocator");
        }
    }

    private void RegisterButtonView() => ServiceLocator.Register(_buttonView);
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
    private void RegisterUnitPrefabsConfig()
    {
        _unitsPrefabConfig = new UnitPrefabsConfig();
        ServiceLocator.Register(_unitsPrefabConfig);
    }
    private void RegisterUnitFactory()
    {
        _unitsFactory = new UnitsFactory(_spawnedUnits, _containerForUnits, _unitStats);
        ServiceLocator.Register(_unitsFactory);
    }
    private void RegisterObjectPool()
    {
        _unitObjectPool = new UnitObjectPool();
        ServiceLocator.Register(_unitObjectPool);
    }
    private void RegisterGameplayPresenter()
    {
        _gameplayPresenter = new GameplayPresenter();
        ServiceLocator.Register(_gameplayPresenter);
    }
}
