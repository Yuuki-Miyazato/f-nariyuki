using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damegeAnimation : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Animator anim;
    [SerializeField] private PlayerController plc;
    public bool damege;

    private void Start()
    {
        player = GameObject.Find("Player");
        anim = GetComponent<Animator>();
        plc = player.GetComponent<PlayerController>();
        damege = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            damege = true;
            //Time.timeScale = 0f;
            switch (plc.houkou)
            {
                case 0:
                    anim.SetTrigger("damege_m");
                    //anim.SetBool("damege_m1", true);
                   // Debug.Log(plc.houkou);
                    break;
                case 1:
                    anim.SetTrigger("damege_mg");
                   // Debug.Log(plc.houkou);
                    break;
                case 2:
                    anim.SetTrigger("damege_u");
                    //Debug.Log(plc.houkou);
                    break;
                case 3:
                    anim.SetTrigger("damege_h");
                    //Debug.Log(plc.houkou);
                    break;
            }
        }
        
    }

    public void damegeFinsh()
    {
        damege = false;
        //Time.timeScale = 1f;
       // Debug.Log("通ってる");
    }
}
