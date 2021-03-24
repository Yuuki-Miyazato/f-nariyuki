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
            SceneManager.LoadScene("MainScene");
        }
        else if (count == 2)
        {
            SceneManager.LoadScene("Stage");
        }
    }
}
