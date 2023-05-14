using System.Collections;
using UnityEngine;


public class GoatSleep : GoatState
{
    private NewEmenyGoat _goat;
    public GoatSleep(NewEmenyGoat goat)
    {
        _goat = goat;
    }
    public override void Enter()
    {
        base.Enter();
    }
    public override void Update()
    {
        if (Vector2.Distance(_goat.transform.position, _goat.player.position) < 7f)
        {
            _goat.StateMachine.ChangeState(new GoatIdle(_goat));
        }
    }
    public override void Exit()
    {
        base.Exit();
    }
}

    
   



