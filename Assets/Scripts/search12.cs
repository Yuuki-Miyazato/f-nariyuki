using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class search12 : MonoBehaviour
{
    public GameObject Goal;
    // Start is called before the first frame update
    void Start()
    {
        Goal = GameObject.Find("Goal");                     //Playerという名前のオブジェクトを探しPlayerに入れる
       
    }

    // Update is called once per frame
    void Update()
    {
        var pos = Camera.main.WorldToScreenPoint(transform.localPosition);
        var rotation = Quaternion.LookRotation(Vector3.forward, Goal.transform.position - transform.position);
        transform.localRotation = rotation;
    }
}
