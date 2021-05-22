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
    private float startX;
    private float startY;

    private int migi = 0;
    private int hidari = 0;
    private int mae = 0;
    private int ushiro = 0;

    private float step_time = 0;

    public AudioClip sound01;      //SE用変数

    public GameObject effect;
    [SerializeField] private float RespownTime = 0.0f;
    [SerializeField] private bool Respownflg;
    [SerializeField] private bool RespownDEffectflg;
    [SerializeField] public GameObject Respowneffect;

    [SerializeField] public Animator anim;

    [SerializeField] private GameObject goal;
    [SerializeField] private reset3 reset;

    void Start()
    {
        goal=GameObject.FindWithTag("goal");
        reset = goal.GetComponent<reset3>();
        Player = GameObject.Find("Player");                     //Playerという名前のオブジェクトを探しPlayerに入れる
        script = Player.GetComponent<PlayerController>();       //PlayerControllerというスクリプトの情報をscriptにいれる
        Transform startTransform = this.transform;             //このスクリプトをアタッチしているオブジェクトのトランスフォームを読み込む
        Vector2 startpos = startTransform.position;                 //読み込んだトランスフォームのポジションをVector2 posに入れる
        startX = (float)startpos.x;
        startY = (float)startpos.y;
    }
    void Update()
    {
        if (reset.abc == true) { 
        Transform myTransform = this.transform;             //このスクリプトをアタッチしているオブジェクトのトランスフォームを読み込む
        Vector2 pos = myTransform.position;                 //読み込んだトランスフォームのポジションをVector2 posに入れる

        //script.px(プレイヤーのx座標)よりpos.x(敵のx座標)が小さい場合、尚且つ敵のy座標とプレイヤーのy座標が同じ場合敵を右に進める
        if ((float)script.px > pos.x && pos.y <= script.py+0.5f&&pos.y>=script.py-0.5f && mae == 0 && migi == 0 && ushiro == 0 && hidari == 0)
        {
            step_time += Time.deltaTime;
            if (step_time >= 1.0f)
            {
                migi = 1;
  
            }
        }
        else if (script.px < pos.x && pos.y <= script.py + 0.5f && pos.y >= script.py - 0.5f && migi == 0 && ushiro == 0 && mae == 0 && hidari == 0)
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
            anim.SetBool("migiflg", true);
            anim.SetBool("ueflg", false);
            anim.SetBool("sitaflg", false);
            anim.SetBool("hidariflg", false);
            step_time = 0;
            pos.x += 1f / moveTime * Time.deltaTime;
            myTransform.position = pos;
        }
        else if (hidari == 1)
        {
            anim.SetBool("hidariflg", true);
            anim.SetBool("ueflg", false);
            anim.SetBool("sitaflg", false);
            anim.SetBool("migiflg", false);
            step_time = 0;
            pos.x -= 1f / moveTime * Time.deltaTime;
            myTransform.position = pos;
        }
        else if (mae == 1)
        {
            anim.SetBool("sitaflg", false);
            anim.SetBool("ueflg", true);
            anim.SetBool("migiflg", false);
            anim.SetBool("hidariflg", false);
            step_time = 0;
            pos.y += 1f / moveTime * Time.deltaTime;
            myTransform.position = pos;
        }
        else if (ushiro == 1)
        {
            anim.SetBool("ueflg", false);
            anim.SetBool("sitaflg", true);
            anim.SetBool("migiflg", false);
            anim.SetBool("hidariflg", false);
            step_time = 0;
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
        else
        {
            anim.enabled=false;
        }
        Debug.Log((float)script.py);
        Debug.Log(this.transform.position.y-0.5f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
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
                //this.transform.position = new Vector2(pos.x, pos.y);
                migi = 0;
                hidari = 0;
                mae = 0;
                ushiro = 0;
            }
            if (hidari == 1)
            {
                this.transform.position = new Vector2(Mathf.Ceil(pos.x), pos.y);
                //this.transform.position = new Vector2(pos.x , pos.y) ;
                migi = 0;
                hidari = 0;
                mae = 0;
                ushiro = 0;
            }
            if (mae == 1)
            {
                //this.transform.position = new Vector2(pos.x, Mathf.Floor(pos.y));
                this.transform.position = new Vector2(pos.x, pos.y- (1- 0.82222222f));
                migi = 0;
                hidari = 0;
                mae = 0;
                ushiro = 0;
            }
            if (ushiro == 1)
            {
                //this.transform.position = new Vector2(pos.x, Mathf.Ceil(pos.y));
                this.transform.position = new Vector2(pos.x, pos.y+(1-0.82222222f));
                migi = 0;
                hidari = 0;
                mae = 0;
                ushiro = 0;
            }
        }
    }
}
