using System.Collections;
using UnityEngine;


public class GoatPrepare : GoatState
{
    private NewEmenyGoat _goat;
    public GoatPrepare(NewEmenyGoat goat)
    {
        _goat = goat;
    }
    public override void Enter()
    {
        _goat.animator.CrossFade("goatpreparefprattack", 1f);
        base.Enter();
    }
    public override void Update()
    {
        if (Vector2.Distance(_goat.transform.position, _goat.player.position) < 4f)
        {
            _goat.StateMachine.ChangeState(new GoatRun(_goat));
        }
    }
    public override void Exit()
    {
        base.Exit();
    }
}
