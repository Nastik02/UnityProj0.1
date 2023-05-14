using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;

public class enemy1 : MonoBehaviour, IDamageable
{
    public float speed = 2f;
    [SerializeField] private int lives = 8;
    [SerializeField] private float hittime = 0.5f;
    private int damage = 1;
    public float timeWaiting = 0.5f;
    public GameObject effect;
    public GameObject loot;
    private bool waitingForHit = false;
    private bool canMove = true;
    public Animator anim;
    public Transform attackpoint;
    public float attackrange = 0.5f;
    public LayerMask enemyLayers;
    public SpriteRenderer sprite;
    public Transform player;
    public float positionOfPatrol=5f;
    public Transform point;
    private static bool moveingRight=true;
    public float stoppingDistance=4f;
    public float attackarea = 2f;
    public Enemy1StateMachine StateMachine;
    private Enemy1Chasing chase;
    private Enemy1Patrol patrol;

    public bool ionpoinf = true;
    bool chill = true;
    bool angry = false;
    bool goBack = false;
    //private float enemy1positionx=transform.position.x;

    private void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StateMachine= new Enemy1StateMachine();
        StateMachine.Initialize(new Enemy1Patrol(this));
    }
    private void Start()
    {
        sprite.flipX = true;
        anim.SetBool("iswalk", canMove);
    }
    private void Update()
    {
        StateMachine.CurrentState.Update();
        
        /*if (Vector2.Distance(transform.position, point.position) < positionOfPatrol)
        {
            chill = true;
        }*/
        /*if (Vector2.Distance(transform.position, player.position) < stoppingDistance)
        {
            angry=true;
            chill = false;
            goBack = false;
           
            
        }

        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            angry = false;
            goBack = true;

        }
        if (Vector2.Distance(transform.position, point.position) < positionOfPatrol)
        {
            goBack = false;
            chill = true;
        }*/

        /*if (Vector2.Distance(transform.position, point.position) < positionOfPatrol&& ionpoinf)
        {
            StateMachine.ChangeState(new Enemy1Patrol(this));
        }
        if(Vector2.Distance(transform.position, player.position) < stoppingDistance)
        {
            StateMachine.ChangeState(new Enemy1Chasing(this));
        }
        if (Vector2.Distance(transform.position, player.position) > stoppingDistance && Vector2.Distance(transform.position, point.position) > positionOfPatrol)
        {
            StateMachine.ChangeState(new Enemy1IdoNothing(this));
        }
        if (Vector2.Distance(transform.position, point.position) > positionOfPatrol)
        {
            StateMachine.ChangeState(new Enemy1GoingBack(this));
        }*/

        /* if (angry == true)
         {
             Angry();
         }

         if (goBack == true)
         {
             Goback();
         }
         if (chill == false)
         {
             StopCoroutine("Chill");
         }
         if(Vector2.Distance(transform.position, player.position) < attackarea)
         {
             angry = false;
             chill = false;
             goBack = false;
             canMove = false;
             StopCoroutine("Chill");
             StartCoroutine(HitEnemy());
         }*/


        /*if (Vector2.Distance(transform.position, point.position) <= positionOfPatrol)
        {
            Chill();
        }*/
    }

    public void StartChill()
    {
        StartCoroutine(Chill());
    }
    public void StopChill()
    {
         StopCoroutine("Chill");

    }
    public void StartDoNothing()
    {
        StartCoroutine(DoNothing());
    }
    private IEnumerator Chill()
    {
        
        if(Mathf.Abs(transform.position.x) > Mathf.Abs(point.position.x) + Mathf.Abs(positionOfPatrol))
        {
            canMove = false;
            anim.SetBool("iswalk", canMove);
            yield return new WaitForSeconds(2f);
            moveingRight = false;
            sprite.flipX = false;
            canMove = true;
            anim.SetBool("iswalk", canMove);
        }
        else if (Mathf.Abs(transform.position.x) < Mathf.Abs(point.position.x) - Mathf.Abs(positionOfPatrol))
        {
            canMove = false;
            anim.SetBool("iswalk", canMove);
            yield return new WaitForSeconds(2f);
            moveingRight = true;
            sprite.flipX = true;
            canMove = true;
            anim.SetBool("iswalk", canMove);
        }
        if (moveingRight && canMove)
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        }
        if(!moveingRight&& canMove)
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        }
    }

    public void Angry()
    {

        canMove = true;
        anim.SetBool("iswalk", canMove);
        if (transform.position.x<player.transform.position.x){
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
        }
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }
    private IEnumerator DoNothing()
    {
        canMove= false;
        yield return new WaitForSeconds(2f);
        canMove= true;
    }
    public void Goback()
    {
        canMove = true;
        anim.SetBool("iswalk", canMove);
        if (transform.position.x < point.transform.position.x)
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
        }
        transform.position = Vector2.MoveTowards(transform.position, point.position, speed * Time.deltaTime);
    }



    public void ApplyDamage(int _damage)
    {
       
        Instantiate(effect, transform.position, Quaternion.identity);
        Debug.Log("i have" + lives);
        Debug.Log("i apply" + _damage);
        lives = lives - _damage;
        Debug.Log("now i have" + lives);
        if (lives <= 0) {
            Die();
        }
    }
    private void Die() {
        Instantiate(loot, new Vector3(transform.position.x,transform.position.y +1, transform.position.z), Quaternion.identity);
        Destroy(this.gameObject);
    }


    public void Vhit()
    {
        StartCoroutine(HitEnemy());
    }
    public bool ihit=false;
    private IEnumerator HitEnemy()
    {
        //ihit = true;
        /*Debug.Log("iwillhit");
        waitingForHit = true;
        anim.SetBool("isprepareforhit", waitingForHit);
        yield return new WaitForSeconds(timeWaiting);
        waitingForHit = false;*/
        anim.CrossFade("enemywaitingforhit", 2f);
        /*anim.SetBool("isprepareforhit", waitingForHit);*/

        anim.SetTrigger("hit");
        yield return new WaitForSeconds(hittime);
        //ihit = false;
        /*Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackpoint.position, attackrange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy.gameObject.CompareTag("Player"))
            {
                GameObject hero = GameObject.FindGameObjectWithTag("Player");
                hero.SendMessage("ApplyDamage1", damage);
            }
        }*/


    }

    // Start is called before the first frame update
    
    void FixedUpdate()
    {
        //anim.SetBool("iswalk", canMove);
    }
    // Update is called once per frame
    public void Hit2()
    {
        anim.SetTrigger("hit");
    }
}
