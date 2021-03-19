using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class junnkaiEnemyMove : MonoBehaviour
{
    [SerializeField] private GameObject left, right, up, down;      //左、右、上。下のゲームオブジェクト(enemyの子ようし)
    BoxCollider2D leftBox, rightBox, upBox, downBox;                //左、右、上、下のボックスコライダー

    junnkaidown lefts;              //左判定のスクリプト
    junnkaidown rights;             //右判定のスクリプト
    junnkaidown ups;                //上判定のスクリプト
    junnkaidown downs;              //下判定のスクリプト

   [SerializeField] private bool wallflg;       //オブジェクトが正面の壁に当たったよっていうフラグ
    [SerializeField] private bool searchflg;    //壁を探していいよっていうフラグ
    [SerializeField] private bool moveflg;      //動かしていいよっていうフラグ

    [SerializeField]Transform my;           //自分(object)の事
    [SerializeField]Vector2 pos;            //オブジェクトのposision
   // [SerializeField] Quaternion rote;

    //使うかも
    //[SerializeField] Vector3 rote;

    [SerializeField] public float tote;    //回転した後の移動方向

    [SerializeField] private int root;      //回転させる角度

    //[SerializeField] private Quaternion r;

    public  float timerg;       //壁を探す時間

    public float timeroot;      //回転させる時間

    public float timemove;      //動かす時間

    //public SpriteRenderer enemy;
    //public Sprite mae;
    //public Sprite migi;
    //public Sprite hidari;
    //public Sprite usiro;

    int sh = 0;

    //public Vector2 pos;

    Rigidbody2D rb;

    private void Start()
    {
        leftBox = left.GetComponent<BoxCollider2D>();
        rightBox = right.GetComponent<BoxCollider2D>();
        upBox = up.GetComponent<BoxCollider2D>();
        downBox = down.GetComponent<BoxCollider2D>();

        lefts = left.GetComponent<junnkaidown>();
        rights = right.GetComponent<junnkaidown>();
        ups = up.GetComponent<junnkaidown>();
        downs = down.GetComponent<junnkaidown>();

        rb = GetComponent<Rigidbody2D>();

        my = this.transform;
        pos = my.position;

        leftBox.enabled = false;
        upBox.enabled = false;
        downBox.enabled = false;

        lefts.enabled = false;
        ups.enabled = false;
        downs.enabled = false;

        wallflg = false;
        searchflg = false;

        root = 0;
        timerg = 0.0f;
        timeroot = 0.0f;
        timemove = 0.0f;

    }

    private void FixedUpdate()
    {
        // pos.x -= 1f / 1f * Time.deltaTime;
        // transform.position = pos;

        if (wallflg == true)
        {
            //timerg = 0.0f;
            timemove = 0.0f;
            search();
            if (timerg <= 1.0f)
            {
                timerg += Time.deltaTime;
            }
            if (timerg >= 0.1f)
            {
                timerg = 0.0f;
                searchflg = true;
                wallflg = false;
            }          
        }

        if (searchflg == true)
        {
            timemove = 0.0f;
            if (timeroot <= 1.0f)
            {
                timeroot += Time.deltaTime;
            }
            if (timeroot >= 1f)
            {

                EnemyRote();
                rb.rotation += root;
                timeroot = 0.0f;
                searchflg = false;

            }
        }


        if (timemove <= 1.0f)
        {
            timemove += Time.deltaTime;
        }
        if (timemove >= 1f)
        {
            rights.enabled = true;
            rightBox.enabled = true;
            //transform.rotation = Quaternion.Euler(0, 0, 90);
            //timemove = 0.0f;
             EnemyMove();
        }

    }


    //上下左右の壁を探す
    private void search()
    {
        //右のflgがオンかつsh=0だったら
        if (rights.flg == true && sh == 0)
        {
            sh += 1;
            rightBox.enabled = false;
            rights.enabled = false;
            upBox.enabled = true;
            ups.enabled = true;
        }
        //上のflgがオンかつsh=1だったら
        else if (ups.flg == true && sh == 1)
        {
            sh += 1;
            upBox.enabled = false;
            ups.enabled = false;
            downBox.enabled = true;
            downs.enabled = true;
        }   
        //下のフラグがオンかつsh=2だったら
        else if (downs.flg == true && sh == 2)
        {
            sh += 1;
            downBox.enabled = false;
            downs.enabled = false;
        }
        //Debug.Log(sh);
    }

    //敵の向きを回転させる
    private void EnemyRote()
    {
        //判定を全部falseにする
        rightBox.enabled = false;
        leftBox.enabled = false;
        upBox.enabled = false;
        downBox.enabled = false;

        rights.enabled = false;
        lefts.enabled = false;
        ups.enabled = false;
        downs.enabled = false;

        ups.flg = false;
        downs.flg = false;
        rights.flg = false;
        lefts.flg = false;
        //sh=0は正直いらないと思う
        if (sh == 0)
        {
            //root = 90;
            // Debug.Log("90");
        }
        //sh=1だったら90度回転
        else if (sh == 1)
        {
            root = 90;
        }
        //sh=2だったら270度回転
        else if (sh == 2)
        {
            root = 270;
        }
        //sh=3だったら180度回転
        else if (sh == 3)
        {
            root = 180;
        }
        //Debug.Log(root);
        sh = 0;

        //rb.rotation += root;
        
    }

    //敵の動き
    private void EnemyMove()
    {
        //使うかも
        // r = my.transform.rotation;
        // rote = my.transform.localEulerAngles;
        if (rb.rotation >= 360) {
            rb.rotation = rb.rotation - 360;
        }
        tote = rb.rotation;
        //使うかも
        //tote = my.transform.localEulerAngles.z;
        //if (tote != 0 && tote != 90 && tote != 180 && tote != 270)
        //{
        //    tote = 0.0f;
        //}
        if (tote < 0 && tote > 360)
        {
            tote = 0.0f;
        }
        //使うかも
        //if (rote.z >= 360)
        //{
        //    rote.z = rote.z - 360;
        //    //rote = rote.z;
        //    //rote.z = 0;
        //    Debug.Log("oo");
        //}

        //if (tote >= 0 && tote < 90 || tote <= -360 && tote > -270) 
        //{
        //    pos.x += 1f / 1f * Time.deltaTime;
        //    my.transform.position = pos;
        //}
        ////上向いてたら
        //else if (tote == 90 || tote == -270)
        //{
        //    pos.y += 1f / 1f * Time.deltaTime;
        //    my.transform.position = pos;
        //}
        ////左向いてたら
        //else if (tote == 180 || tote == -180)
        //{
        //    pos.x -= 1f / 1f * Time.deltaTime;
        //    my.transform.position = pos;
        //}
        ////下向いてたら
        //else if (tote == 270 || tote == -90)
        //{
        //    pos.y -= 1f / 1f * Time.deltaTime;
        //    my.transform.position = pos;
        //}
        //左向いてたら
        if (tote == 0 || tote == -360)
        {
            //enemy.sprite = hidari;
            pos.x += 1f / 1f * Time.deltaTime;
            my.transform.position = pos;
        }
        //上向いてたら
        else if (tote == 90 || tote == -270)
        {
            //enemy.sprite = usiro;
            pos.y += 1f / 1f * Time.deltaTime;
            my.transform.position = pos;
        }
        //左向いてたら
        else if (tote == 180 || tote == -180)
        {
            //enemy.sprite = hidari;
            pos.x -= 1f / 1f * Time.deltaTime;
            my.transform.position = pos;
        }
        //下向いてたら
        else if (tote == 270 || tote == -90)
        {
            //enemy.sprite = mae;
            pos.y -= 1f / 1f * Time.deltaTime;
            my.transform.position = pos;
        }

        //もしかしたら使うかも
        //if (rote.z == 0 || rote.z == -360)
        //{
        //    pos.x += 1f / 1f * Time.deltaTime;
        //    my.transform.position = pos;
        //}
        //else if (rote.z == 90 || rote.z == -270)
        //{
        //    pos.y += 1f / 1f * Time.deltaTime;
        //    my.transform.position = pos;
        //}
        //else if (rote.z == 180 || rote.z == -180)
        //{
        //    pos.x -= 1f / 1f * Time.deltaTime;
        //    my.transform.position = pos;
        //}
        //else if (rote.z == 270 || rote.z == -90)
        //{
        //    pos.y -= 1f / 1f * Time.deltaTime;
        //    my.transform.position = pos;
        //}
    }

    //壁に当たったか判定
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            wallflg = true;
        }
    }
}
