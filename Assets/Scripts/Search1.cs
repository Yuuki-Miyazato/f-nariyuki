using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Search1 : MonoBehaviour
{
    public GameObject Goal;
    public ModeChange script;
    public GameObject Player;

    public GameObject hidari;

    private void Start()
    {
        Goal = GameObject.Find("Goal");                     //Playerという名前のオブジェクトを探しPlayerに入れる
        Player = GameObject.Find("Player");                     //Playerという名前のオブジェクトを探しPlayerに入れる
        script = Player.GetComponent<ModeChange>();       //PlayerControllerというスクリプトの情報をscriptにいれる
        hidari = GameObject.Find("k");
    }
    void Update()
    {
        if (script.Mode == 2)
        {
            hidari.SetActive(true);
        }
        else
        {
            hidari.SetActive(false);
        }

    }
}