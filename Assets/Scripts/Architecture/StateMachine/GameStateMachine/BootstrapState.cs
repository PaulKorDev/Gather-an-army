using Assets.Scripts.Architecture.StateMachine;
using UnityEngine;

public class BootstrapState : BaseGameState
{
    public BootstrapState(StateMachine<BaseGameState> stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        Debug.Log("Entered to BootstrapState");
    }

    public override void UpdateLogic()
    {
        
    }
}