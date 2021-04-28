using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dfire : MonoBehaviour
{
    private ModeChange script;
    private GameObject Player;

    void Start()
    {
        Player = GameObject.Find("Player");                     //Playerという名前のオブジェクトを探しPlayerに入れる
        script = Player.GetComponent<ModeChange>();       //PlayerControllerというスクリプトの情報をscriptにいれる
    }

    void Update()
    {
        if (script.Mode == 1)
        {
            Destroy(this.gameObject);
        }
        else if (script.Mode == 2)
        {
            Destroy(this.gameObject);
        }
    }
}
