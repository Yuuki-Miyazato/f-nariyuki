using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class EnemyMove : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    public float moveTime = 0.1f;
    private PlayerController script;
    private GameObject Player;
    private Rigidbody rb;
    private int startX;
    private int startY;

    private int migi = 0;
    private int hidari = 0;
    private int mae = 0;
    private int ushiro = 0;

    private float step_time = 0;

    public SpriteRenderer Enemy;
    public Sprite Smae;
    public Sprite Smigi;
    public Sprite Shidari;
    public Sprite Susiro;

    public AudioClip sound01;      //SE用変数

    public GameObject effect;
    [SerializeField] private float RespownTime = 0.0f;
    [SerializeField] private bool Respownflg;
    [SerializeField] private bool RespownDEffectflg;
    [SerializeField] public GameObject Respowneffect;

    void Start()
    {
        Player = GameObject.Find("Player");                     //Playerという名前のオブジェクトを探しPlayerに入れる
        script = Player.GetComponent<PlayerController>();       //PlayerControllerというスクリプトの情報をscriptにいれる
        Transform startTransform = this.transform;             //このスクリプトをアタッチしているオブジェクトのトランスフォームを読み込む
        Vector2 startpos = startTransform.position;                 //読み込んだトランスフォームのポジションをVector2 posに入れる
        startX = (int)startpos.x;
        startY = (int)startpos.y;
    }
    void Update()
    {
        Transform myTransform = this.transform;             //このスクリプトをアタッチしているオブジェクトのトランスフォームを読み込む
        Vector2 pos = myTransform.position;                 //読み込んだトランスフォームのポジションをVector2 posに入れる

        //script.px(プレイヤーのx座標)よりpos.x(敵のx座標)が小さい場合、尚且つ敵のy座標とプレイヤーのy座標が同じ場合敵を右に進める
        if (script.px > pos.x && pos.y == script.py && mae == 0 && migi == 0 && ushiro == 0 && hidari == 0)
        {
            step_time += Time.deltaTime;
            if (step_time >= 1.0f)
            {
                migi = 1;
            }
        }
        else if (script.px < pos.x && pos.y == script.py && migi == 0 && ushiro == 0 && mae == 0 && hidari == 0)
        {
            step_time += Time.deltaTime;
            if (step_time >= 1.0f)
            {
                hidari = 1;
            }
        }
        else if (script.py > pos.y && pos.x == script.px && migi == 0 && ushiro == 0 && hidari == 0 && mae == 0)
        {
            step_time += Time.deltaTime;
            if (step_time >= 1.0f)
            {
                mae = 1;
            }
        }
        else if (script.py < pos.y && pos.x == script.px && migi == 0 && hidari == 0 && mae == 0 && ushiro == 0)
        {
            step_time += Time.deltaTime;
            if (step_time >= 1.0f)
            {
                ushiro = 1;
            }
        }
        if (migi == 1)
        {
            step_time = 0;
            Enemy.sprite = Smigi;
            pos.x += 1f / moveTime * Time.deltaTime;
            myTransform.position = pos;
        }
        else if (hidari == 1)
        {
            step_time = 0;
            Enemy.sprite = Shidari;
            pos.x -= 1f / moveTime * Time.deltaTime;
            myTransform.position = pos;
        }
        else if (mae == 1)
        {
            step_time = 0;
            Enemy.sprite = Susiro;
            pos.y += 1f / moveTime * Time.deltaTime;
            myTransform.position = pos;
        }
        else if (ushiro == 1)
        {
            step_time = 0;
            Enemy.sprite = Smae;
            pos.y -= 1f / moveTime * Time.deltaTime;
            myTransform.position = pos;
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
            if (RespownTime > 2.5)
            {
                GameObject DDestroy = GameObject.Find("Ghost D effect");
                GameObject RDestory = GameObject.Find("Ghost R effect");
                Destroy(DDestroy);
                Destroy(RDestory);
                pos.x = startX;
                pos.y = startY;
                Respownflg = false;
                RespownTime = 0.0f;
                this.transform.position = new Vector2(startX, startY);

            }
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Vector2 pos = new Vector2(this.transform.position.x, this.transform.position.y);
            AudioSource.PlayClipAtPoint(sound01, transform.position);
            migi = 0;
            hidari = 0;
            mae = 0;
            ushiro = 0;

            GameObject Deffect = Instantiate(effect, this.transform.position, Quaternion.identity);
            Deffect.name = "Ghost D effect";
            pos.x = 100000;
            pos.y = 100000;
            this.transform.position = new Vector2(pos.x, pos.y);
            RespownDEffectflg = true;
            Respownflg = true;

            //this.transform.position = new Vector2(startX, startY);            //プレイヤーに当たればvoid startで読み込んだ最初の位置に戻る
        }
        if (collision.gameObject.tag == "Wall")
        {
            Transform myTransform = this.transform;             //このスクリプトをアタッチしているオブジェクトのトランスフォームを読み込む
            Vector2 pos = myTransform.position;                 //読み込んだトランスフォームのポジションをVector2 posに入れる

            if (migi == 1)
            {
                this.transform.position = new Vector2(Mathf.Floor(pos.x), pos.y);
                migi = 0;
                hidari = 0;
                mae = 0;
                ushiro = 0;
            }
            if (hidari == 1)
            {
                this.transform.position = new Vector2(Mathf.Ceil(pos.x), pos.y);
                migi = 0;
                hidari = 0;
                mae = 0;
                ushiro = 0;
            }
            if (mae == 1)
            {
                this.transform.position = new Vector2(pos.x, Mathf.Floor(pos.y));
                migi = 0;
                hidari = 0;
                mae = 0;
                ushiro = 0;
            }
            if (ushiro == 1)
            {
                this.transform.position = new Vector2(pos.x, Mathf.Ceil(pos.y));
                migi = 0;
                hidari = 0;
                mae = 0;
                ushiro = 0;
            }
        }
    }
}
