using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class junnkaiEnemyroot : MonoBehaviour
{
    [SerializeField] GameObject Enemyobj;
    [SerializeField] junnkaiEnemymove2 jem;
    [SerializeField] private GameObject left, right, up, down;      //左、右、上。下のゲームオブジェクト(enemyの子ようし)
    public BoxCollider2D leftBox, rightBox, upBox, downBox;                //左、右、上、下のボックスコライダー

    junnkaidown lefts;              //左判定のスクリプト
    public junnkaidown rights;             //右判定のスクリプト
    junnkaidown ups;                //上判定のスクリプト
    junnkaidown downs;              //下判定のスクリプト

    [SerializeField] private bool wallflg;       //オブジェクトが正面の壁に当たったよっていうフラグ
    [SerializeField] private bool searchflg;    //壁を探していいよっていうフラグ

    //使うかも
    //[SerializeField] Vector3 rote;

    [SerializeField] public float tote;    //回転した後の移動方向

    [SerializeField] private int root;      //回転させる角度


    public float timerg;       //壁を探す時間

    public float timeroot;      //回転させる時間

    int sh = 0;

    public Rigidbody2D rb;

    private int startX;
    private int startY;


    private void Start()
    {
        Enemyobj = GameObject.Find("Enemy3");
        jem = Enemyobj.GetComponent<junnkaiEnemymove2>();

        leftBox = left.GetComponent<BoxCollider2D>();
        rightBox = right.GetComponent<BoxCollider2D>();
        upBox = up.GetComponent<BoxCollider2D>();
        downBox = down.GetComponent<BoxCollider2D>();

        lefts = left.GetComponent<junnkaidown>();
        rights = right.GetComponent<junnkaidown>();
        ups = up.GetComponent<junnkaidown>();
        downs = down.GetComponent<junnkaidown>();

        rb = GetComponent<Rigidbody2D>();

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

        //Transform startTransform = this.transform;             //このスクリプトをアタッチしているオブジェクトのトランスフォームを読み込む
        //Vector2 startpos = startTransform.position;                 //読み込んだトランスフォームのポジションをVector2 posに入れる
        //startX = (int)startpos.x;
        //startY = (int)startpos.y;
    }

    private void FixedUpdate()
    {
        if (wallflg == true)
        {
            jem.timemove = 0.0f;
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

            if (timeroot <= 1.0f)
            {
                jem.timemove = 0.0f;
                timeroot += Time.deltaTime;
            }
            if (timeroot >= 0.3f)
            {

                EnemyRote();
               // rb.rotation += root;
                timeroot = 0.0f;
                searchflg = false;
                //jem.moveflg = true;
            }
        }
    }

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

        rb.rotation += root;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall")|| collision.CompareTag("FireWall"))
        {
            wallflg = true;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("ぶつかったroot");
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
        }
    }
}
