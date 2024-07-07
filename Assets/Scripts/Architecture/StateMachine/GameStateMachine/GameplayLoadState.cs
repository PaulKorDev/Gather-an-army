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

        GameplayServiceLocator gamplayServiceLocator = GameObject.FindAnyObjectByType<GameplayServiceLocator>();
        gamplayServiceLocator.RegisterAllServices();

        
        ServiceLocator.Get<ButtonsView>().Init();

        GameObject.Find("UI").AddComponent<SpriteSwitcherTest>();

        _stateMachine.EnterToState<GameplayState>();

        ServiceLocator.Get<UILoadingScreenView>().HideLoadingScreen();
    }

}