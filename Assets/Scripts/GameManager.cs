using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static int GC = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Enemymap")
        {
            GC = 1;
        }
        else if (SceneManager.GetActiveScene().name == "stage")
        {
            GC = 2;
        }
    }
}
