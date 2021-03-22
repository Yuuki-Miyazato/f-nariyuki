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
            migi = 1;
        }
        else if (script.px < pos.x && pos.y == script.py && migi == 0 && ushiro == 0 && mae == 0 && hidari == 0)
        {
            hidari = 1;
        }
        else if (script.py > pos.y && pos.x == script.px && migi == 0 && ushiro == 0 && hidari == 0 && mae == 0)
        {
            mae = 1;
        }
        else if (script.py < pos.y && pos.x == script.px && migi == 0 && hidari == 0 && mae == 0 && ushiro == 0)
        {
            ushiro = 1;
        }
        if (migi == 1)
        {
            pos.x += 1f/moveTime * Time.deltaTime;
            myTransform.position = pos;
        }
        else if (hidari == 1)
        {
            pos.x -= 1f/moveTime * Time.deltaTime;
            myTransform.position = pos;
        }
        else if (mae == 1)
        {
            pos.y += 1f/moveTime * Time.deltaTime;
            myTransform.position = pos;
        }
        else if (ushiro == 1)
        {
            pos.y -= 1f/moveTime * Time.deltaTime;
            myTransform.position = pos;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            migi = 0;
            hidari = 0;
            mae = 0;
            ushiro = 0;

            this.transform.position = new Vector2(startX, startY);            //プレイヤーに当たればvoid startで読み込んだ最初の位置に戻る
        }
        if (collision.gameObject.tag == "Wall")
        {
            Transform myTransform = this.transform;             //このスクリプトをアタッチしているオブジェクトのトランスフォームを読み込む
            Vector2 pos = myTransform.position;                 //読み込んだトランスフォームのポジションをVector2 posに入れる

            if (migi == 1)
            {
                this.transform.position = new Vector2(Mathf.Floor(pos.x),pos.y);
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
