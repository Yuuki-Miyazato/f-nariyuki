using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create : MonoBehaviour
{
    private ModeChange script;
    private GameObject player;
    
    void Start()
    {
        player = GameObject.Find("Player");                     //Playerという名前のオブジェクトを探しPlayerに入れる
        script = player.GetComponent<ModeChange>();       //PlayerControllerというスクリプトの情報をscriptにいれる
    }

    void Update()
    {
        player = GameObject.Find("Player");                     //Playerという名前のオブジェクトを探しPlayerに入れる
        script = player.GetComponent<ModeChange>();       //PlayerControllerというスクリプトの情報をscriptにいれる

        //消す
        if (script.Mode == 2)
        {
            this.gameObject.SetActive(false);
        }
        //出す
        else if (script.Mode == 1 || script.Mode == 3)
        {
            this.gameObject.SetActive(true);
        }
    }
}
