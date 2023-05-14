using System.Collections;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;


public class Enemy1Chasing : Enemy1State
{
    private enemy1 _enemy;
    public Enemy1Chasing(enemy1 enemy)
    {
        _enemy = enemy;
    }
    public override void Enter()
    {
        base.Enter();
    }
    public override void Update()
    {
        _enemy.Angry();
        if (Vector2.Distance(_enemy.transform.position, _enemy.player.position) > _enemy.stoppingDistance)
        {
            _enemy.StateMachine.ChangeState(new Enemy1IdoNothing(_enemy));
        }
        if (Vector2.Distance(_enemy.transform.position, _enemy.player.position) <= _enemy.attackarea)
        {
            _enemy.StateMachine.ChangeState(new Enemy1Hit(_enemy));
        }
    }
    public override void Exit()
    {
        base.Exit();
    }
}
    