using Assets.Scripts.Architecture.EntryPoint;
using Assets.Scripts.Architecture.ServiceLocator;
using Assets.Scripts.Architecture.StateMachine;
using System.Collections;
using UnityEngine;

public class BootstrapState : BaseGameState
{
    
    public BootstrapState(StateMachine<BaseGameState> stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        //Here register all general services
        BootstrapServiceLocator bootstrapServiceLocator = new BootstrapServiceLocator();
        bootstrapServiceLocator.RegisterAllServices();

        _stateMachine.EnterToState<GameplayLoadState>();

    }

}