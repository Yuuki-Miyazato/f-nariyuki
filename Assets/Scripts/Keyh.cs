using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyh : MonoBehaviour
{
    public AudioClip sound01;

    public bool keyflg;
    
    //１回入るよう
    private bool abc = true;

    //public Sprite chest;
    //SpriteRenderer MainSpriteRenderer;

    [SerializeField] public GameObject effect;

    void Start()
    {
        keyflg = false;
        //MainSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        GameObject effectobj = Instantiate(effect, this.transform.position, Quaternion.identity);
        effectobj.transform.parent = transform;
        effectobj.name = "T";

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (abc)
            {
                GameObject deletobj = GameObject.Find("T");
                Destroy(deletobj);
                //ゴール音を１度だけ鳴らす
                abc = false;
                AudioSource.PlayClipAtPoint(sound01, transform.position);
            }
            keyflg = true;
           // MainSpriteRenderer.sprite = chest;
        }
    }
}
