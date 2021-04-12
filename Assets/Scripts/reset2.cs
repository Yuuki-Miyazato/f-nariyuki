using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class reset2 : MonoBehaviour
{
    [SerializeField] GameObject Key;
    [SerializeField] Keyh k;

    [SerializeField] 
    private GameObject clear;

    string sceneName;

    private float waitTime = 0;

    void Start()
    {
        Key = GameObject.Find("Key");
        k = Key.GetComponent<Keyh>();
        sceneName = SceneManager.GetActiveScene().name;
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        waitTime += Time.deltaTime;

        if (collision.gameObject.tag == "Player")
        {
            Instantiate(clear);
            clear.SetActive(true);
            if (k.keyflg == true)
            {
                if (waitTime >= 10f)
                {
                    SceneManager.LoadScene("Title");
                }
            }
        }
    }
}
