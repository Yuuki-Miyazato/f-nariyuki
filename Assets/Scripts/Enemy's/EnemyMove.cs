using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    public float moveTime = 0.1f;
    public PlayerController script;
    public GameObject Player;
    public int t;
    void Start()
    {
        Player = GameObject.Find("Player");
        script = Player.GetComponent<PlayerController>();
    }
    void Update()
    {
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        Transform myTransform = this.transform;
        Vector2 pos = myTransform.position;
        t = 0;
        if (script.px >= pos.x && pos.y == script.py && t == 0)
        {
            pos.x += moveTime * Time.deltaTime;
        }
        else if (script.px <= pos.x && pos.y == script.py && t == 0)
        {
            pos.x -= moveTime * Time.deltaTime;
        }
        if (script.py >= pos.y && pos.x == script.px && t == 0)
        {
            pos.y += moveTime * Time.deltaTime;
        }
        else if (script.py <= pos.y && pos.x == script.px && t == 0)
        {
            pos.y -= moveTime * Time.deltaTime;
        }
        myTransform.position = pos;
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        
    }
}
