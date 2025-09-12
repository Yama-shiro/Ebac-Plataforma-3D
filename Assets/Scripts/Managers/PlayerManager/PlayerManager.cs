using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Singleton;
using Ebac.StateMachine;

public class PlayerManager : Singleton<PlayerManager>
{
    public enum PlayerStates
    {
        Idle,
        Walk,
        Jump
    }
    public StateMachine<PlayerStates> stateMachine;

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        stateMachine = new StateMachine<PlayerStates>();
        stateMachine.Init();
        stateMachine.RegisterStates(PlayerStates.Idle,new PlayerStates_Idle());
        stateMachine.RegisterStates(PlayerStates.Walk,new PlayerStates_Walk());
        stateMachine.RegisterStates(PlayerStates.Jump,new PlayerStates_Jump());

        stateMachine.SwitchStates(PlayerStates.Idle);
    }
}
