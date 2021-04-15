using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class junnkaidown : MonoBehaviour
{
    public GameObject main;


    public int i = 0;

    public bool flg;

    private void Start()
    {
        //main=GameObject.Find("Enemy2");
        main = transform.parent.gameObject;
        flg = false;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Enemy")
        {
            flg = true;
            //i += 1;
            //Debug.Log(i);
            //jm.sh += 1;
        }
    }
}
