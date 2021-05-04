using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeChange : MonoBehaviour
{
    private PlayerController script;
    private GameObject Player;
    public int Mode = 1;

    private int Search = 0;
    private int Firewall = 0;

    void Start()
    {
        Player = GameObject.Find("Player");                     //Playerという名前のオブジェクトを探しPlayerに入れる
        script = Player.GetComponent<PlayerController>();       //PlayerControllerというスクリプトの情報をscriptにいれる
    }

    void SpeedMode()
    {
        script.moveTime = 0.1f;
        Search = 0;
        Firewall = 0;
    }
    void SearchMode()
    {
        script.moveTime = 0.3f;
        Search = 1;
        Firewall = 0;
    }
    void FirewallMode()
    {
        script.moveTime = 0.3f;
        Firewall = 1;
        Search = 0;
    }
    void Update()
    {
        Debug.Log(Mode);
        if (Mode == 1)
        {
            SpeedMode();
        }
        else if (Mode == 2)
        {
            SearchMode();
        }
        else if (Mode == 3)
        {
            FirewallMode();
        }
        if (Input.GetKeyDown("joystick button 5"))
        {
            if (Mode == 3)
            {
                Mode = 1;
            }
            else
            {
                Mode += 1;

            }
        }
        if (Input.GetKeyDown("joystick button 4"))
        {
            if (Mode == 1)
            {
                Mode = 3;
            }
            else
            {
                Mode -= 1;
            }
        }
    }
}
