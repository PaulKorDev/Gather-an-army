using Assets.Scripts.Architecture.EntryPoint;
using Assets.Scripts.Architecture.ServiceLocator;
using Assets.Scripts.Architecture.StateMachine;
using System.Collections;
using UnityEngine;

public class GameplayLoadState : BaseGameState
{
    public GameplayLoadState(StateMachine<BaseGameState> stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        ServiceLocator.Get<UILoadingScreenView>().ShowLoadingScreen();

        ServiceLocator.Get<Coroutine>().StartCoroutine(LoadGamplay());
    }
    

    private IEnumerator LoadGamplay(){

        yield return SceneLoader.LoadScene(Scenes.GAMEPLAY);

        RegisterServicesToServiceLocator();
        new FieldStatistic();
        InitGameplayView();
        //Temporary script
        GameObject.Find("UI").AddComponent<SpriteSwitcherTest>();

        MoveToNextState();

        ServiceLocator.Get<UILoadingScreenView>().HideLoadingScreen();
    }

    private void RegisterServicesToServiceLocator()
    {
        GameplayServiceLocator gamplayServiceLocator = GameObject.FindAnyObjectByType<GameplayServiceLocator>();
        gamplayServiceLocator.RegisterAllServices();
    }
    private void InitGameplayView()
    {
        ServiceLocator.Get<ButtonsView>().Init();
        GameObject.FindFirstObjectByType<FieldStatiscticsView>().Init();
    }
    private void MoveToNextState() => _stateMachine.EnterToState<GameplayState>();
}