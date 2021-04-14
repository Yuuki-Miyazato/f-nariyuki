using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager2 : MonoBehaviour
{
    public static int GC = 1;

    int ver;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void FixedUpdate()
    {
        ver= (int)Input.GetAxisRaw("Vertical");
        if (ver == 1)
        {
            GC = 1;
        }else if (ver == -1)
        {
            GC = -1;
        }
        Debug.Log(GC);
    }
}
