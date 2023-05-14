using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NewEmenyGoat : NewMechEnemy
{
    private float speed = 6;
    private float lives = 9;
    public Animator animator;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    public Transform player;
    public GoatStateMachine StateMachine;
    private bool isrun = false;
    

    void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StateMachine = new GoatStateMachine();
        StateMachine.Initialize(new GoatSleep(this));
        rb = GetComponent<Rigidbody2D>();
    }
    
    
    void Update()
    {
        //sprite.flipX = rb.velocity.x < 0f;

        StateMachine.CurrentState.Update();
    }
    private void FixedUpdate()
    {
        animator.SetFloat("speed", Mathf.Abs(rb.velocity.x));
    }
    public void WakeUp()
    {
        animator.SetTrigger("wakeup");
    }

    public void Run()
    {
        
        if(transform.position.x < player.transform.position.x)
        {
            transform.position = Vector2.MoveTowards(transform.position, transform.position - new Vector3(6,0,0), speed * Time.deltaTime);
        }
        if (transform.position.x > player.transform.position.x)
        {
            transform.position = Vector2.MoveTowards(transform.position, transform.position + new Vector3(6, 0, 0), speed * Time.deltaTime);
        }
    }
}