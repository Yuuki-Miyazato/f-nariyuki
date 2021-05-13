using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    int count = GameManager.GC;

    public void OnStartButtonClicked()
    {
        int count = GameManager.GC;

        if (count == 1)
        {
            SceneManager.LoadScene("Enemymap");
        }
        else if (count == 2)
        {
            SceneManager.LoadScene("Enemymap2");
        }
        else if (count == 3)
        {
            SceneManager.LoadScene("Enemymap3");
        }
        else if (count == 4)
        {
            SceneManager.LoadScene("Enemymap4");
        }
        else if (count == 5)
        {
            SceneManager.LoadScene("Enemymap5");
        }
        else if (count == 6)
        {
            SceneManager.LoadScene("Enemymap6");
        }
    }
}
