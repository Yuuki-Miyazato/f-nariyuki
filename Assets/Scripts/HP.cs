using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HP : MonoBehaviour
{

    public Text hp;

    [SerializeField] private GameObject player;
    [SerializeField] private PlayerController pl;

    [SerializeField] private GameObject Keyobj;
    [SerializeField] private Keyh keys;
    [SerializeField] public Image keyUI;

    private void Start()
    {
        keyUI.enabled = false;
        Keyobj = GameObject.Find("Key");
        keys = Keyobj.GetComponent<Keyh>();

        player = GameObject.Find("Player");
        pl = player.GetComponent<PlayerController>();

    }

    private void Update()
    {
        //Keyobj = GameObject.Find("Key");
        //keys = Keyobj.GetComponent<Keyh>();

        //player = GameObject.Find("Player");
        //pl = player.GetComponent<PlayerController>();

        hp.text=string.Format("×{0}", pl.HP);

        if (keys.keyflg == true)
        {
            keyUI.enabled = true;
        }
        //Debug.Log(keys.keyflg); 
    }
}