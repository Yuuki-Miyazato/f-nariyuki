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

    public AudioClip sound01;      //SE用変数

    public GameObject effect;

    [SerializeField] private float RespownTime = 0.0f;
    [SerializeField] private bool Respownflg;
    [SerializeField] private bool RespownDEffectflg;
    [SerializeField] public GameObject Respowneffect;

    [SerializeField] public Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
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


        if (Respownflg == true)
        {
            RespownTime += 0.02f;

            if (RespownTime > 1.0 && RespownDEffectflg == true)
            {
                GameObject Reffect = Instantiate(Respowneffect, new Vector2(startX, startY), Quaternion.identity);
                Reffect.name = "Ghost R effect";
                RespownDEffectflg = false;
            }
            if (RespownTime > 3.0)
            {
                GameObject DDestroy = GameObject.Find("Ghost D effect");
                GameObject RDestory = GameObject.Find("Ghost R effect");
                Destroy(DDestroy);
                Destroy(RDestory);
                pos.x = startX;
                pos.y = startY;
                Respownflg = false;
                RespownTime = 0.0f;
                my.transform.position = new Vector2(startX, startY);

            }
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
            anim.SetBool("ueflg", false);
            anim.SetBool("sitaflg", false);
            anim.SetBool("migiflg", true);
            anim.SetBool("hidariflg", false);
        }
        //上向いてたら
        else if (jer.tote == 90 || jer.tote == -270)
        {
            //enemy.sprite = usiro;
            Enemy.sprite = usiro;
            pos.y += 3f / 1f * Time.deltaTime;
            my.transform.position = pos;
            anim.SetBool("ueflg", true);
            anim.SetBool("sitaflg", false);
            anim.SetBool("migiflg", false);
            anim.SetBool("hidariflg", false);
        }
        //左向いてたら
        else if (jer.tote == 180 || jer.tote == -180)
        {
            //enemy.sprite = hidari;
            Enemy.sprite = hidari;
            pos.x -= 3f / 1f * Time.deltaTime;
            my.transform.position = pos;
            anim.SetBool("ueflg", false);
            anim.SetBool("sitaflg", false);
            anim.SetBool("migiflg", false);
            anim.SetBool("hidariflg", true);
        }
        //下向いてたら
        else if (jer.tote == 270 || jer.tote == -90)
        {
            //enemy.sprite = mae;
            Enemy.sprite = mae;
            pos.y -= 3f / 1f * Time.deltaTime;
            my.transform.position = pos;
            anim.SetBool("ueflg", false);
            anim.SetBool("sitaflg", true);
            anim.SetBool("migiflg", false);
            anim.SetBool("hidariflg", false);
        }

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(sound01, transform.position);           //SE再生

            timemove = 0.0f;
            moveflg = false;

            GameObject Deffect = Instantiate(effect, this.transform.position, Quaternion.identity);
            Deffect.name = "Ghost D effect";
            pos.x = 100000;
            pos.y = 100000;
            my.transform.position = new Vector2(pos.x, pos.y);
            RespownDEffectflg = true;
            Respownflg = true;
            // Debug.Log("音");
            //Debug.Log("ぶつかった");
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
