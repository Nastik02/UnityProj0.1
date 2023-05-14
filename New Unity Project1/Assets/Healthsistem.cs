using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthsistem : MonoBehaviour
{
    public int currentHealth = 6;
    private int numberOfLives;
    public Image[] lives;
    public Sprite fulllives;
    public Sprite emptylives;
    
   

    

    public void SetHealth( int health)
    {
        numberOfLives=health;
    }


    void Update()
    {
        if (numberOfLives > currentHealth)
        {
            numberOfLives = currentHealth;
        }
        for (int i = 0; i < lives.Length; i++)
        {
            if (i < numberOfLives)
            {
                lives[i].sprite = fulllives;
            }
            else
            {
                lives[i].sprite = emptylives;
            }
            if (i < currentHealth)
            {
                lives[i].enabled = true;
            }
            else
            {
                lives[i].enabled = false;
            }

        }
    }
}
