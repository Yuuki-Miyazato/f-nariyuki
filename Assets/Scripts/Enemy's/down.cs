using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class down : MonoBehaviour
{
    [SerializeField] GameObject Enemy;
    [SerializeField] enemyhanntei hn;
    [SerializeField] EnemyMove Emv;
    [SerializeField] BoxCollider2D BC2;
    public bool sflg;

    private void Start()
    {
        Enemy = GameObject.Find("Enemy");
        hn = Enemy.GetComponent<enemyhanntei>();
        Emv = Enemy.GetComponent<EnemyMove>();
        BC2 = GetComponent<BoxCollider2D>();
        BC2.size = new Vector2(0.8f, hn.iyd);
        sflg = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Emv.rflg == false && Emv.rflg == false && Emv.uflg == false && Emv.dflg == false)
            {
                Emv.sy = 1;
                Emv.dflg = true;
                Emv.playerhh = true;
                Debug.Log("down");
            }
        }
    }


}
