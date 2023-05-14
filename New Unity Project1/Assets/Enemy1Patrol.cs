using System.Collections;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;



public class Enemy1Patrol : Enemy1State
{
    private bool canMove;
    private bool moveingRight;
    private enemy1 _enemy;
    public Enemy1Patrol(enemy1 enemy)
    {
        _enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();
    }
    public override void Update()
    {
        _enemy.StartChill();
        if (Vector2.Distance(_enemy.transform.position, _enemy.player.position) < _enemy.stoppingDistance)
        {
            _enemy.StateMachine.ChangeState(new Enemy1Chasing(_enemy));
        }
    }
    public override void Exit()
    {
        _enemy.StopChill();
        base.Exit();
    }
    
    private IEnumerator Chill()
    {

        if (Mathf.Abs(_enemy.transform.position.x) >= Mathf.Abs(_enemy.point.transform.position.x) + Mathf.Abs(_enemy.positionOfPatrol))
        {
            Debug.Log("check1");
            canMove = false;
            _enemy.anim.SetBool("iswalk", canMove);
            yield return new WaitForSeconds(2f);
            moveingRight = false;
            _enemy.sprite.flipX = false;
            canMove = true;
            _enemy.anim.SetBool("iswalk", canMove);
        }
        else if (Mathf.Abs(_enemy.transform.position.x) < Mathf.Abs(_enemy.point.transform.position.x) - Mathf.Abs(_enemy.positionOfPatrol))
        {
            Debug.Log("check2");
            canMove = false;
            _enemy.anim.SetBool("iswalk", canMove);
            yield return new WaitForSeconds(2f);
            moveingRight = true;
            _enemy.sprite.flipX = true;
            canMove = true;
            _enemy.anim.SetBool("iswalk", canMove);
        }
        if (moveingRight && canMove)
        {
            _enemy.transform.position = new Vector2(_enemy.transform.position.x + _enemy.speed * Time.deltaTime, _enemy.transform.position.y);
        }
        if (!moveingRight && canMove)
        {
            _enemy.transform.position = new Vector2(_enemy.transform.position.x - _enemy.speed * Time.deltaTime, _enemy.transform.position.y);
        }
    }
}
   