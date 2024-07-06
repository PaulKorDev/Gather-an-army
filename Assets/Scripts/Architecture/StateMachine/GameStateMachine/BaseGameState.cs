using Assets.Scripts.Architecture.StateMachine;

public abstract class BaseGameState : IState, ILogicState
{
    protected StateMachine<BaseGameState> _stateMachine;
    public BaseGameState(StateMachine<BaseGameState> stateMachine)
    {
        _stateMachine = stateMachine;
    }

    public abstract void Enter();

    public abstract void UpdateLogic();
}
