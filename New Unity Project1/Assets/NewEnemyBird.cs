using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NewEnemyBird : NewMechEnemy
{
    override protected void Die()
    {
        base.Die();
        Resurrect();
    }

    private void Resurrect()
    {
        // RESURRECT CODE
        health++;
    }

    // Start is called before the first frame  update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
