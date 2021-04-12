using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class reset : MonoBehaviour
{

    string sceneName;
    
    void Start()
    {
        sceneName = SceneManager.GetActiveScene().name;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        int count = GameManager.GC;

        if (collision.gameObject.tag == "Player" && count == 1)
        {
            SceneManager.LoadScene("Title");
        }
        else if (collision.gameObject.tag == "Player" && count == 2)
        {
            SceneManager.LoadScene("stage");
        }
    }
}
