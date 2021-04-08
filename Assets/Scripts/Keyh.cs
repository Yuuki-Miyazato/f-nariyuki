using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyh : MonoBehaviour
{

    public bool keyflg;
    void Start()
    {
        keyflg = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            keyflg = true;
        }
    }
}
