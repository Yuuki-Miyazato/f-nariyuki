using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemlost : MonoBehaviour
{
    private PlayerController script;
    private GameObject Player;

    void Start()
    {
        Player = GameObject.Find("Player");                     //Playerという名前のオブジェクトを探しPlayerに入れる
        script = Player.GetComponent<PlayerController>();       //PlayerControllerというスクリプトの情報をscriptにいれる
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            script.moveTime = 0.1f;
            Destroy(this.gameObject);
        }
    }
    void normalS()
    {
    }
    void Update()
    {
    }
}
