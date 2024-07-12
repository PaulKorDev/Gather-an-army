using Zenject;
using UnityEngine;
using Assets.Scripts.Architecture.EventBus;

public class GameplayInstaller : MonoInstaller
{
    [SerializeField] private ContainerForUnits _containerForUnits;
    [SerializeField] private ButtonsView _buttonsView;
    [SerializeField] private FieldStatiscticsView _fieldStatsView;

    public override void InstallBindings()
    {
        Container.Bind<EventBus>().FromNew().AsSingle().NonLazy();
        Container.Bind<GameplayReactive>().FromNew().AsSingle().NonLazy();
        Container.Bind<FieldStatistic>().FromNew().AsSingle().NonLazy();
        Container.Bind<GameplayPresenter>().FromNew().AsSingle();
        Container.Bind<UnitSpritesSetter>().FromNew().AsSingle();
        Container.Bind<UnitsUpdater>().FromNew().AsSingle();
        Container.BindInterfacesAndSelfTo<UnitStatsHardCode>().AsSingle();
        Container.Bind<ContainerForUnits>().FromInstance(_containerForUnits).AsSingle().NonLazy();
        Container.Bind<UnitsFactory>().FromNew().AsSingle();
        Container.Bind<UnitObjectPool>().FromNew().AsSingle();
        Container.Bind<ButtonsView>().FromInstance(_buttonsView).AsSingle();
        Container.Bind<FieldStatiscticsView>().FromInstance(_fieldStatsView).AsSingle();
        

    }
}