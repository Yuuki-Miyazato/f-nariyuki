using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private float moveTime = 0.1f;
    public PlayerController script;
    public GameObject Player;
    public int x;
    public int y;
    void Start()
    {
        Player = GameObject.Find("Player");
        script = Player.GetComponent<PlayerController>();
    }
    private void FixedUpdate()
    {
    }
    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            
            Transform myTransform = this.transform;
            Vector2 pos = myTransform.position;
            x = script.px;
            y = script.py;
            if (x >= pos.x)
            {
                pos.x += moveTime;
                myTransform.position = pos;
            }
            else if (x <= pos.x)
            {
                pos.x -= moveTime;
                myTransform.position = pos;
            }
            if (y >= pos.y)
            {
                pos.y += moveTime;
                myTransform.position = pos;
            }
            else if (y <= pos.y)
            {
                pos.y -= moveTime;
                myTransform.position = pos;
            }
        }
    }
}
