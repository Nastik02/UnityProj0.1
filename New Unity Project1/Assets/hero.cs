using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEditor.U2D.Path;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class hero : MonoBehaviour
{

    [SerializeField] private float speed = 3f;
    [SerializeField] private float jumpForce = 10500f;
    [SerializeField] private int lives = 3;
    [SerializeField] private int damage = 1;

    private bool canhit = true;
    private bool canDash = true;
    private bool isDashing;
    private bool canMove = true;
    private float dashindPower = 10f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 2f;
    private float hitTime = 0.2f;
    public float attackRange = 0.9f;
    public LayerMask enemyLayers;
    private bool isfallhit = false;

    


    private bool isGrounded = false;

    public Animator animator;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    public Transform attackPoint;
    public GameObject effectApplyDamage;

    public static hero Instance { get; set; }

    private void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        //GameObject livessystem = GameObject.FindGameObjectWithTag("lives");
        //livessystem.SendMessage("SetHealth", lives);
    }
    
    public void ApplyDamage1(int _damage)
    {
        if (lives > 1)
        {
            animator.SetTrigger("applydamage");
        }
        Instantiate(effectApplyDamage, new Vector3(transform.position.x,transform.position.y+0.5f,transform.position.z), Quaternion.identity);
        Debug.Log("i have" + lives);
        lives -= _damage;
        GameObject livessystem = GameObject.FindGameObjectWithTag("lives");
        livessystem.SendMessage("SetHealth", lives);
        //Thread.Sleep(200);

        if (lives <= 0)
        {
            StartCoroutine(Die1());
        }
    }
    public IEnumerator Die1()
    {
        animator.SetTrigger("death");
        canhit = false;
        canMove = false;
        canDash = false;
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    private void Return()
    {
        SceneManager.LoadScene(2);
    }
    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        if (sprite.flipX)
        {
            rb.velocity = new Vector2(-transform.localScale.x * dashindPower, 0f);
        }
        else
        {
            rb.velocity = new Vector2(transform.localScale.x * dashindPower, 0f);
        }
        
        yield return new WaitForSeconds(dashingTime);
        rb.gravityScale = originalGravity;
        isDashing= false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash= true;

    }
    
    private IEnumerator FallHit()
    {
        isfallhit = true;
        while (!isGrounded)
        {
            isfallhit = true;
            rb.gravityScale = 15f;
            Debug.Log("1");
            yield return new WaitForFixedUpdate();

        }

        if (isGrounded)
        {
            Debug.Log("ionground");
            isfallhit = false;
            canMove = false;
            animator.SetTrigger("onground");
            yield return new WaitForSeconds(2f);
            canMove = true;
            rb.gravityScale = 6;
        }
      

    }
    void OnDrawGizmosSelected()
    {
        if (attackPoint == null){
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }


    private IEnumerator Hit()
    {
        canhit = false;
        canMove= false;
        animator.SetTrigger("hit");
        yield return new WaitForSeconds(hitTime);
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange,enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            if(enemy.TryGetComponent(out IDamageable damageable))
            {
                damageable.ApplyDamage(damage);
            }
        }
       
        canhit= true;
        canMove= true;
    }
    private void CheckGround()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 0.3f);
        isGrounded = collider.Length > 1;
        animator.SetBool("isjumping", !isGrounded);
        animator.SetFloat("velocity", rb.velocity.y);
    }
    private void FixedUpdate()
    {
        CheckGround();
        animator.SetBool("isdashing", isDashing);
        animator.SetBool("isfallhit", isfallhit);

    }


    private void Run()
    {
        Vector3 dir = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
        sprite.flipX = Input.GetAxis("Horizontal") < 0.0f;
        
        
    }
    private void Update()
    {
        if (Input.GetButton("Horizontal") && canMove)
            Run();
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            Jump();
        }
        
        animator.SetFloat("speed", Mathf.Abs(Input.GetAxisRaw("Horizontal") * speed));
        if(Input.GetMouseButtonDown(1) && canDash ) {
            StartCoroutine(Dash());
        }
        if (Input.GetMouseButtonDown(0) && canhit)
        {
            StartCoroutine(Hit());
        }
        if(Input.GetMouseButtonDown(0)&& !isGrounded)
        {
            StartCoroutine(FallHit());
        }

        if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("0");
            Return();
        }

    }

    private void Jump()
    {
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }

}
