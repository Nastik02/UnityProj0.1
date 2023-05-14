using System.Collections;
using UnityEngine;


public class Enemy1Hit : Enemy1State
{
    private enemy1 _enemy;
    public Enemy1Hit(enemy1 enemy)
    {
        _enemy = enemy;
    }
    public override void Enter()
    {
        _enemy.Hit2();
        base.Enter();
    }
    public override void Update()
    {
        /* _enemy.Vhit();*/
        /*if (Vector2.Distance(_enemy.transform.position, _enemy.player.position) >= _enemy.attackarea)
        {
            _enemy.StateMachine.ChangeState(new Enemy1Chasing(_enemy));
        }*/
        
    }
    public override void Exit()
    {
        base.Exit();
    }
}