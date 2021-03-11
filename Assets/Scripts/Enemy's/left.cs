using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class left : MonoBehaviour
{
    [SerializeField] GameObject GM;
    [SerializeField] enemyhanntei hn;
    [SerializeField] EnemyMove Emv;
    [SerializeField] BoxCollider2D BC2;
    public bool sflg;

    private void Start()
    {
        GM = GameObject.Find("Enemy");
        hn = GM.GetComponent<enemyhanntei>();
        Emv = GM.GetComponent<EnemyMove>();
        BC2 = GetComponent<BoxCollider2D>();
        BC2.size = new Vector2(hn.ixl, 0.8f);
        sflg = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Emv.rflg == false && Emv.rflg == false && Emv.uflg == false && Emv.dflg == false)
            {
                Emv.sx = 1;
                Emv.lflg = true;
                Emv.playerhh = true;
                Debug.Log("left");
            }
        }
    }
}
