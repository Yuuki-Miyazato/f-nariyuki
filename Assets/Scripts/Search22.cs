using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Search22 : MonoBehaviour
{
    public  GameObject Key;

    // Start is called before the first frame update
    void Start()
    {
        Key = GameObject.Find("Key");                     //Playerという名前のオブジェクトを探しPlayerに入れる
    }

    // Update is called once per frame
    void Update()
    {
        var pos = Camera.main.WorldToScreenPoint(transform.localPosition);
        var rotation = Quaternion.LookRotation(Vector3.forward, Key.transform.position - transform.position);
        transform.localRotation = rotation;
    }
}
