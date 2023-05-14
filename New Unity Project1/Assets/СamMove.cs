using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class СamMove : MonoBehaviour
{
    public float _duration = .8f;
    private Transform _cameraTransform;
    private Vector3 _originalPosition;


    public GameObject player;
    void Start()
    {
        _cameraTransform = GetComponent<Transform>();
        _originalPosition = new Vector3(player.transform.position.x, player.transform.position.y + 2, -10f);
    }
    void LateUpdate()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 2, -10f);
    }
}
        /*if (Input.GetMouseButtonDown(0))
        {
            Shake();
        } }

   /* public void Shake()
    {
        StartCoroutine(_Shake());
    }
    IEnumerator _Shake()
    {

        float x;
        float y;
        float timeLeft = Time.time;

        while ((timeLeft + _duration) > Time.time)
        {
            x = Random.Range(-0.3f, 0.3f);
            y = Random.Range(-0.3f, 0.3f);

            transform.position = new Vector3(player.transform.position.x+x, player.transform.position.y+y, _originalPosition.z);
            

            yield return new WaitForSeconds(0.025f);
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 2, -10f);
        }

        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 2, -10f);

    }
}*/
