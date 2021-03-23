using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class junnkaiEnemymove2 : MonoBehaviour
{
    [SerializeField] GameObject Enemyobj;
    [SerializeField] junnkaiEnemyroot jer;
    [SerializeField] public bool moveflg;      //動かしていいよっていうフラグ

    [SerializeField] Transform my;           //自分(object)の事
    [SerializeField] Vector2 pos;            //オブジェクトのposision


    public SpriteRenderer Enemy;
    public Sprite mae;
    public Sprite migi;
    public Sprite hidari;
    public Sprite usiro;

    public float timemove;      //動かす時間
    private int startX;
    private int startY;

    private void Start()
    {
        Enemyobj = GameObject.Find("hanntei");
        jer = Enemyobj.GetComponent<junnkaiEnemyroot>();
        my = this.transform;
        pos = my.position;
        timemove = 0.0f;
        moveflg = false;

        Vector2 startpos = my.position;                 //読み込んだトランスフォームのポジションをVector2 posに入れる
        startX = (int)startpos.x;
        startY = (int)startpos.y;

    }

    private void FixedUpdate()
    {

            if (timemove <= 1.0f)
            {
                timemove += Time.deltaTime;
            }
            if (timemove >= 0.3f)
            {
                jer.rights.enabled = true;
                jer.rightBox.enabled = true;
                //transform.rotation = Quaternion.Euler(0, 0, 90);
                //timemove = 0.0f;
                EnemyMove();
            }
        
    }

    private void EnemyMove()
    {
        //使うかも
        // r = my.transform.rotation;
        // rote = my.transform.localEulerAngles;
        if (jer.rb.rotation >= 360)
        {
            jer.rb.rotation = jer.rb.rotation - 360;
        }
        jer.tote = jer.rb.rotation;

        if (jer.tote < 0 && jer.tote > 360)
        {
            jer.tote = 0.0f;
        }
        //右向いてたら
        if (jer.tote == 0 || jer.tote == -360)
        {
            //enemy.sprite = hidari;
            Enemy.sprite = migi;
            pos.x += 3f / 1f * Time.deltaTime;
            my.transform.position = pos;
        }
        //上向いてたら
        else if (jer.tote == 90 || jer.tote == -270)
        {
            //enemy.sprite = usiro;
            Enemy.sprite = usiro;
            pos.y += 3f / 1f * Time.deltaTime;
            my.transform.position = pos;
        }
        //左向いてたら
        else if (jer.tote == 180 || jer.tote == -180)
        {
            //enemy.sprite = hidari;
            Enemy.sprite = hidari;
            pos.x -= 3f / 1f * Time.deltaTime;
            my.transform.position = pos;
        }
        //下向いてたら
        else if (jer.tote == 270 || jer.tote == -90)
        {
            //enemy.sprite = mae;
            Enemy.sprite = mae;
            pos.y -= 3f / 1f * Time.deltaTime;
            my.transform.position = pos;
        }

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            timemove = 0.0f;
            moveflg = false;
            Debug.Log("ぶつかった");
            pos.x = startX;
            pos.y = startY;
            my.transform.position = new Vector2(startX, startY);
        }
    }
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        this.transform.position = new Vector2(startX, startY);            //プレイヤーに当たればvoid startで読み込んだ最初の位置に戻る
    //    }
    //}
}
