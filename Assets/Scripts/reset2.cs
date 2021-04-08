using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class reset2 : MonoBehaviour
{
    [SerializeField] GameObject Key;
    [SerializeField] Keyh k;
    string sceneName;

    void Start()
    {
        Key = GameObject.Find("Key");
        k = Key.GetComponent<Keyh>();
        sceneName = SceneManager.GetActiveScene().name;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (k.keyflg == true)
            {
                SceneManager.LoadScene("Enemymap");
            }
        }
    }
}
