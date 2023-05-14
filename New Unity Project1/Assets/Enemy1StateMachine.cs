using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy1StateMachine
{
    public Enemy1State CurrentState { get;  set; }

    public void Initialize(Enemy1State startState)
    {
        CurrentState= startState;
        CurrentState.Enter();
    }

    public void ChangeState(Enemy1State newState)
    {
        CurrentState.Exit();
        CurrentState= newState;
        CurrentState.Enter();

    }

}
    
