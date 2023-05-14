using System.Collections;
using System.Drawing;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Enemy1GoingBack : Enemy1State
{
    private enemy1 _enemy;
    public Enemy1GoingBack(enemy1 enemy)
    {
        _enemy = enemy;
    }
    public override void Enter()
    {
        base.Enter();
    }
    public override void Update()
    {
        _enemy.Goback();
        if (Vector2.Distance(_enemy.transform.position, _enemy.point.position) == 0)
        {
            _enemy.StateMachine.ChangeState(new Enemy1Patrol(_enemy));
        }
        if (Vector2.Distance(_enemy.transform.position, _enemy.player.position) < _enemy.stoppingDistance)
        {
            _enemy.StateMachine.ChangeState(new Enemy1Chasing(_enemy));
        }
    }
    public override void Exit()
    {
        base.Exit();
    }
}
    