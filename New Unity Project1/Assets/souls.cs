using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class souls : MonoBehaviour

{

    private float soul = 0;

    public Text soulText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "soul")
        {
            soul++;

            soulText.text = soul.ToString();

            Destroy(collision.gameObject);
           
        }

    }

    

}
