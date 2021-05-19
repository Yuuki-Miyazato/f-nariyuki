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
    SpriteRenderer MainSpriteRenderer;

    public Animator anim;

    [SerializeField] public GameObject effect;
    [SerializeField] private GameObject Goal;

    void Start()
    {
        anim = GetComponent<Animator>();
        keyflg = false;
        MainSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        GameObject effectobj = Instantiate(effect, this.transform.position, Quaternion.identity);
        effectobj.transform.parent = transform;
        effectobj.name = "T";
        Goal = GameObject.FindWithTag("goal");
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
                GameObject goaleffectDelet = GameObject.Find("goaleffect(Clone)");
                Destroy(goaleffectDelet);
                Goal.layer = 0;
                anim.enabled = false;
                MainSpriteRenderer.sprite = null;
               // Destroy(gameObject);
            }
            keyflg = true;
           // MainSpriteRenderer.sprite = chest;
        }
    }
}
