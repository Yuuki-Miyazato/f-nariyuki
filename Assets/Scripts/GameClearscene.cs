using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameClearscene : MonoBehaviour
{
    void Return()
    {
        if (SceneManager.GetActiveScene().name == "GameClear")
        {
            SceneManager.LoadScene("Title");
        }
    }
}
