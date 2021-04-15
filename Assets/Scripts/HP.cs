using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HP : MonoBehaviour
{

    public Text hp;

    [SerializeField] private GameObject player;
    [SerializeField] private PlayerController pl;

    private void Update()
    {
        player = GameObject.Find("Player");
        pl = player.GetComponent<PlayerController>();

        hp.text=string.Format("×{0}", pl.HP);
    }
}
