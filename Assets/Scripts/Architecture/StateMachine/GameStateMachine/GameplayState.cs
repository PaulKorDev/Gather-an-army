using Assets.Scripts.Architecture.StateMachine;

public class GameplayState : BaseGameState
{
    public GameplayState(StateMachine<BaseGameState> stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
    }

    public override void UpdateLogic()
    {
    }
}