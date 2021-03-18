using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    public float moveTime = 0.1f;
    public PlayerController script;
    public GameObject Player;
    public Rigidbody rb;
    private int startX;
    private int startY;

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
        Debug.Log(pos.x);

        
        //script.px(プレイヤーのx座標)よりpos.x(敵のx座標)が小さい場合、尚且つ敵のy座標とプレイヤーのy座標が同じ場合敵を右に進める
        if (script.px > pos.x && pos.y == script.py)
        {
            pos.x += moveTime * Time.deltaTime;
            myTransform.position = pos;
            Debug.Log("x+移動");
        }
        if (script.px < pos.x && pos.y == script.py)
        {

            pos.x -= moveTime * Time.deltaTime;
            myTransform.position = pos;
            Debug.Log("x-移動");
        }
        if (script.py > pos.y && pos.x == script.px)
        {
            pos.y += moveTime * Time.deltaTime;
            myTransform.position = pos;
            Debug.Log("y+移動");
        }
        if (script.py < pos.y && pos.x == script.px)
        {
            pos.y -= moveTime * Time.deltaTime;
            myTransform.position = pos;
            Debug.Log("y-移動");
            // プレイヤーの方向に向かって移動していく
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            this.transform.position = new Vector2(startX,startY);             //このスクリプトをアタッチしているオブジェクトのトランスフォームを読み込む
        }
    }
}
