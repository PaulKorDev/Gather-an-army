using Assets.Scripts.Architecture.StateMachine;
using UnityEngine;

public sealed class GameHandler : MonoBehaviour
{
    private StateMachine<BaseGameState> stateMachine;

    public void Init()
    {
        DontDestroyOnLoad(gameObject);
        stateMachine = new StateMachine<BaseGameState>();
        AddStates();
        stateMachine.EnterToState<BootstrapState>();
    }
    private void AddStates()
    {
        stateMachine.AddState(new BootstrapState(stateMachine));
        stateMachine.AddState(new GameplayLoadState(stateMachine));
        stateMachine.AddState(new GameplayState(stateMachine));
        //Add menuState
    }
    //StateMachine
    //GameServiceLocator
}
