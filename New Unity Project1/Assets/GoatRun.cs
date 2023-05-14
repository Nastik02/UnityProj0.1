using System.Collections;
using UnityEngine;


public class GoatRun : GoatState
{
    private NewEmenyGoat _goat;
    public GoatRun(NewEmenyGoat goat)
    {
        _goat = goat;
    }
    public override void Enter()
    {
        
        base.Enter();
    }
    public override void Update()
    {
        _goat.Run();
        _goat.StateMachine.ChangeState(new GoatIdle(_goat));
    }
    public override void Exit()
    {
        base.Exit();
    }
}
