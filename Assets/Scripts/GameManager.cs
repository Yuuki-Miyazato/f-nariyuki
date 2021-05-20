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
        else if (SceneManager.GetActiveScene().name == "Enemymap2")
        {
            GC = 2;
        }
        else if (SceneManager.GetActiveScene().name == "Enemymap3")
        {
            GC = 3;
        }
        else if (SceneManager.GetActiveScene().name == "Enemymap4")
        {
            GC = 4;
        }
        else if (SceneManager.GetActiveScene().name == "Enemymap5")
        {
            GC = 5;
        }
        else if (SceneManager.GetActiveScene().name == "Enemymap6")
        {
            GC = 6;
        }
        else if (SceneManager.GetActiveScene().name == "Enemymap7")
        {
            GC = 7;
        }
        else if (SceneManager.GetActiveScene().name == "Enemymap8")
        {
            GC = 8;
        }
    }
}
