using Assets.Scripts.Architecture.EntryPoint;
using Assets.Scripts.Architecture.ServiceLocator;
using Assets.Scripts.Architecture.StateMachine;

public class GameplayLoadState : BaseGameState
{
    public GameplayLoadState(StateMachine<BaseGameState> stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        ServiceLocator.Get<UILoadingScreenView>().ShowLoadingScreen();

        ServiceLocator.Get<Coroutine>().StartCoroutine(SceneLoader.LoadScene(Scenes.GAMEPLAY));
        _stateMachine.EnterToState<GameplayState>();

        ServiceLocator.Get<UILoadingScreenView>().HideLoadingScreen(); 

    }
    public override void UpdateLogic()
    {
    }
}