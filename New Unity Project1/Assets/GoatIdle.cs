using System.Collections;
using UnityEngine;


public class GoatIdle : GoatState
{
    private NewEmenyGoat _goat;
    public GoatIdle(NewEmenyGoat goat)
    {
        _goat = goat;
    }
    public override void Enter()
    {
        _goat.WakeUp();
        base.Enter();
    }
    public override void Update()
    {
        if (Vector2.Distance(_goat.transform.position, _goat.player.position) < 5f)
        {
            _goat.StateMachine.ChangeState(new GoatPrepare(_goat));
        }
    }
    public override void Exit()
    {
        base.Exit();
    }
}