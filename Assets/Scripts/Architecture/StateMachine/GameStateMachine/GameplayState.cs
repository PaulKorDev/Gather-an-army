using Assets.Scripts.Architecture.StateMachine;

public class GameplayState : BaseGameState
{
    public GameplayState(StateMachine<BaseGameState> stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateLogic()
    {
        throw new System.NotImplementedException();
    }
}