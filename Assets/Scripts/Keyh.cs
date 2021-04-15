using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyh : MonoBehaviour
{
    public AudioClip sound01;

    public bool keyflg;
    
    //１回入るよう
    private bool abc = true;

    public Sprite chest;
    SpriteRenderer MainSpriteRenderer;
    void Start()
    {
        keyflg = false;
        MainSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (abc)
            {
                //ゴール音を１度だけ鳴らす
                abc = false;
                AudioSource.PlayClipAtPoint(sound01, transform.position);
            }
            keyflg = true;
            MainSpriteRenderer.sprite = chest;
        }
    }
}
