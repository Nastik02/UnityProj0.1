using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grasedestroy : MonoBehaviour, IDamageable
{
    private int lives = 1;
    public GameObject effect;
    public void ApplyDamage(int _damage)
    {
        Instantiate(effect, transform.position, Quaternion.identity);   
        lives = lives - _damage;
        if (lives <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        Destroy(this.gameObject);
    }
}
