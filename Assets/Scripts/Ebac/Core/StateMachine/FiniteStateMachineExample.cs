using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.StateMachine;

public class FiniteStateMachineExample : MonoBehaviour
{
    public enum ExampleEnum
    {
        State01,
        State02,
        State03
    }

    public StateMachine<ExampleEnum> stateMachine;

    private void Start()
    {
        stateMachine = new StateMachine<ExampleEnum>();
        stateMachine.Init();
        stateMachine.RegisterStates(ExampleEnum.State01,new StateBase());
        stateMachine.RegisterStates(ExampleEnum.State02,new StateBase());
        
        stateMachine.SwitchStates(ExampleEnum.State01);
    }
}
