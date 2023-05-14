using System.Collections;
using UnityEngine;

public class Enemy1IdoNothing : Enemy1State
{
    private enemy1 _enemy;
    public Enemy1IdoNothing(enemy1 enemy)
    {
        _enemy = enemy;
    }
    public override void Enter()
    {
        base.Enter();
        _enemy.StartDoNothing();
        _enemy.ionpoinf = false;
        if (Vector2.Distance(_enemy.transform.position, _enemy.player.position) < _enemy.stoppingDistance)
        {
            _enemy.StateMachine.ChangeState(new Enemy1Chasing(_enemy));
        }
        if (Vector2.Distance(_enemy.transform.position, _enemy.point.position) != 0)
        {
            _enemy.StateMachine.ChangeState(new Enemy1GoingBack(_enemy));
        }
    }
    public override void Update()
    {
       
    }
    public override void Exit()
    {
        base.Exit();
    }
}