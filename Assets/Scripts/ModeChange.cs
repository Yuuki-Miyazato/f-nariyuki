using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeChange : MonoBehaviour
{
    private PlayerController script;
    private GameObject Player;
    public int Mode = 1;

    //エフェクト
    public GameObject Fireeffect;
    public GameObject Fireeffect1;
    public GameObject windoweffect;
    public GameObject searcheffect;
    [SerializeField] private Vector2 pos;
    [SerializeField] float deletTime = 0.0f;
    public AudioClip Fire;
    public AudioClip Wind;

    private float count;

    bool kirakira;
    public GameObject kirakiraobj;

    void Start()
    {
        Player = GameObject.Find("Player");                     //Playerという名前のオブジェクトを探しPlayerに入れる
        script = Player.GetComponent<PlayerController>();       //PlayerControllerというスクリプトの情報をscriptにいれる
    }

    void SpeedMode()
    {
        script.moveTime = 0.2f;

    }
    void SearchMode()
    {
        script.moveTime = 0.4f;
    }
    void FirewallMode()
    {
        script.moveTime = 0.4f;
    }
    void Update()
    {
        count += Time.deltaTime;
        turn();
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
        if (count > 3f)
        {
            if (Input.GetKeyDown("joystick button 5") || Input.GetKeyDown(KeyCode.X))
            {
                count = 0f;

                kirakira = false;

                if (Mode == 3)
                {
                    Mode = 1;
                }
                else
                {
                    Mode += 1;

                }
                effect();
            }
            if (Input.GetKeyDown("joystick button 4") || Input.GetKeyDown(KeyCode.Z))
            {
                count = 0f;

                kirakira = false;
                if (Mode == 1)
                {
                    Mode = 3;
                }
                else
                {
                    Mode -= 1;
                }
                effect();
            }
        }
    }
    private void FixedUpdate()
    {
        if (GameObject.Find("effect"))
        {
            deletTime += 0.1f;
            if (deletTime >= 4.0f)
            {
                GameObject DestroyE = GameObject.Find("effect");
                Destroy(DestroyE);
                deletTime = 0.0f;
                //Debug.Log("Destroy");

            }
            // Debug.Log("eeeeee");
        }
    }

    void effect()
    {
        float Startx = this.transform.position.x;
        float Starty = this.transform.position.y;
        pos.y = Starty - 0.7f;
        pos.x = Startx - 0.5f;
        if (Mode == 1)
        {
            GameObject windoweffectobj = Instantiate(windoweffect, this.transform.position, Quaternion.identity);
            windoweffectobj.name = "effect";
            AudioSource.PlayClipAtPoint(Wind, transform.position);
        }
        if (Mode == 2)
        {
            GameObject searcheffectobj = Instantiate(searcheffect, this.transform.position, Quaternion.identity);
            searcheffectobj.name = "effect";
        }
        if (Mode == 3)
        {
            GameObject fireeffectobj = Instantiate(Fireeffect, this.transform.position, Quaternion.identity);
            fireeffectobj.name = "effect";
            GameObject fireeffectobj1 = Instantiate(Fireeffect1, pos, Quaternion.identity);
            fireeffectobj1.name = "effect";
            AudioSource.PlayClipAtPoint(Fire, transform.position);
        }
    }

    void turn()
    {

        if (count > 3 && kirakira == false)
        {
            GameObject obj = Instantiate(kirakiraobj, this.transform.position, Quaternion.identity);
            obj.name = "effect";
            //Debug.Log("true");
            kirakira = true;
        }
        //return kirakira;
    }
}
