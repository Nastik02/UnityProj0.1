using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GoatStateMachine
{
    public GoatState CurrentState { get; set; }

    public void Initialize(GoatState startState)
    {
        CurrentState = startState;
        CurrentState.Enter();
    }

    public void ChangeState(GoatState newState)
    {
        CurrentState.Exit();
        CurrentState = newState;
        CurrentState.Enter();

    }
}