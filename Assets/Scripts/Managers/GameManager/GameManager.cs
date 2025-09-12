using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Singleton;
using Ebac.StateMachine;

public class GameManager : Singleton<GameManager>
{
    public enum GameStates
    {
        Intro,
        Gameplay,
        Pause, 
        Win, 
        Lose
    }

    public StateMachine<GameStates> stateMachine;

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        stateMachine = new StateMachine<GameStates>();
        stateMachine.Init();
        stateMachine.RegisterStates(GameStates.Intro,new GMStates_Intro());
        stateMachine.RegisterStates(GameStates.Gameplay,new GMStates_Gameplay());
        stateMachine.RegisterStates(GameStates.Pause,new GMStates_Pause());
        stateMachine.RegisterStates(GameStates.Win,new GMStates_Win());
        stateMachine.RegisterStates(GameStates.Lose,new GMStates_Lose());
        
        stateMachine.SwitchStates(GameStates.Intro);
    }
}
