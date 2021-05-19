using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Search2 : MonoBehaviour
{
    public  GameObject Key;

    public ModeChange script;
    public GameObject Player;

    public GameObject migi;
    private void Start()
    {
        Key = GameObject.Find("Key");                     //Playerという名前のオブジェクトを探しPlayerに入れる
        Player = GameObject.Find("Player");               //Playerという名前のオブジェクトを探しPlayerに入れる
        script = Player.GetComponent<ModeChange>();       //PlayerControllerというスクリプトの情報をscriptにいれる
        migi = GameObject.Find("g");
    }
    void Update()
    {
        if (script.Mode == 2)
        {
            migi.SetActive(true);
        }
        else
        {
            migi.SetActive(false);
        }
    }
}