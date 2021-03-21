using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tuibi : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    public float moveTime = 0.1f;
    public PlayerController script;
    public GameObject Player;
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

        if (script.px + 0.1 >= pos.x || script.px - 0.1 > pos.x)
        {
            pos.x += moveTime * Time.deltaTime;
            myTransform.position = pos;
        }
        if (script.px + 0.1 <= pos.x || script.px - 0.1 < pos.x)
        {
            pos.x -= moveTime * Time.deltaTime;
            myTransform.position = pos;
        }
        if (script.py + 0.1 >= pos.y || script.py - 0.1 > pos.y)
        {
            pos.y += moveTime * Time.deltaTime;
            myTransform.position = pos;
        }
        if (script.py + 0.1 <= pos.y || script.py - 0.1 < pos.y)
        {
            pos.y -= moveTime * Time.deltaTime;
            myTransform.position = pos;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            this.transform.position = new Vector2(startX, startY);             //このスクリプトをアタッチしているオブジェクトのトランスフォームを読み込む
        }
    }
}
