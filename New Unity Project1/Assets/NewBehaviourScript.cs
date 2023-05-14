using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField] private Transform hero;
    private Vector3 pos;
    private void Awake()
    {
        if (!hero)
            hero = FindObjectOfType<hero>().transform;
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
