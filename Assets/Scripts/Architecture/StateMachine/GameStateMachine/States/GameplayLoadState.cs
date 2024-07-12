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

    private void MoveToNextState() => _stateMachine.EnterToState<GameplayState>();
}