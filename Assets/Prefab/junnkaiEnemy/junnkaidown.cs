﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class junnkaidown : MonoBehaviour
{
    public GameObject main;
    
    junnkaiEnemyMove jm;

    public int i = 0;

    public bool flg;

    private void Start()
    {
        //main=GameObject.Find("Enemy2");
        main = transform.parent.gameObject;
        jm = main.GetComponent<junnkaiEnemyMove>();
        flg = false;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            flg = true;
            //i += 1;
            //Debug.Log(i);
            //jm.sh += 1;
        }
    }
}