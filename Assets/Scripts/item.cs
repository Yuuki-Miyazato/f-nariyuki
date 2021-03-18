using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class item : MonoBehaviour
{
    public Text targetText; 
    public GameObject Player;
    public PlayerController script;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Player = GameObject.Find("Player");
        script = Player.GetComponent<PlayerController>();

        int AP = script.AP;
        this.targetText = this.GetComponent<Text>(); 
        this.targetText.text = string.Format("アイテム{000}",AP);
    }
}
