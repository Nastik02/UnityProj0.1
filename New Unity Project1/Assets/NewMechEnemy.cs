using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NewMechEnemy : MonoBehaviour, IDamageable
{

    protected int health = 1;
    virtual public void ApplyDamage(int _damage)
    {
        health--;
        if (health == 0)
        {
            Die();
        }
        //AfterApplyDamage();
    }

    virtual protected void Die()
    {
        // die animation
    }


   // public abstract void AfterApplyDamage();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
