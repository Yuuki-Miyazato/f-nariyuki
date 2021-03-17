using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    public float moveTime = 0.1f;
    public PlayerController script;
    public GameObject Player;
    void Start()
    {
        Player = GameObject.Find("Player");                     //Playerという名前のオブジェクトを探しPlayerに入れる
        script = Player.GetComponent<PlayerController>();       //PlayerControllerというスクリプトの情報をscriptにいれる
    }
    void Update()
    {
        Transform myTransform = this.transform;             //このスクリプトをアタッチしているオブジェクトのトランスフォームを読み込む
        Vector2 pos = myTransform.position;                 //読み込んだトランスフォームのポジションをVector2 posに入れる

        //script.px(プレイヤーのx座標)よりpos.x(敵のx座標)が小さい場合、尚且つ敵のy座標とプレイヤーのy座標が同じ場合敵を右に進める
        if (script.px > pos.x && pos.y == script.py)
        {
            pos.x += 1f / moveTime * Time.deltaTime;
            myTransform.position = pos;
            Debug.Log("x+移動");
        }
        else if (script.px < pos.x && pos.y == script.py)
        {
            pos.x -= 1f / moveTime * Time.deltaTime;
            myTransform.position = pos;
            Debug.Log("x-移動");
        }
        else if (script.py > pos.y && pos.x == script.px)
        {
            pos.y += 1f / moveTime * Time.deltaTime;
            myTransform.position = pos;
            Debug.Log("y+移動");
        }
        else if (script.py < pos.y && pos.x == script.px)
        {
            pos.y -= 1f / moveTime * Time.deltaTime;
            myTransform.position = pos;
            Debug.Log("y-移動");
            // プレイヤーの方向に向かって移動していく
        }
    }
}
