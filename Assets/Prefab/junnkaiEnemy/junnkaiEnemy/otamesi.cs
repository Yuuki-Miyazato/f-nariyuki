using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class otamesi : MonoBehaviour
{
    [SerializeField] GameObject Enemyobj;
    [SerializeField] junnkaiEnemyMove jE;
    public SpriteRenderer Enemy;
    public Sprite mae;
    public Sprite migi;
    public Sprite hidari;
    public Sprite usiro;

    private void Start()
    {
        Enemyobj = GameObject.Find("Enemy3");
        jE = Enemyobj.GetComponent<junnkaiEnemyMove>();
    }

    private void FixedUpdate()
    {
        jE = Enemyobj.GetComponent<junnkaiEnemyMove>();
        if (jE.tote == 0 || jE.tote == -360)
        {
            Enemy.sprite = migi;
        }
        else if (jE.tote == 90 || jE.tote == -270)
        {
            Enemy.sprite = usiro;
        }
        else if (jE.tote == 180 || jE.tote == -180)
        {
            Enemy.sprite = hidari;
        }
        else if (jE.tote == 270 || jE.tote == -90)
        {
            Enemy.sprite = mae;
        }
    }
}
