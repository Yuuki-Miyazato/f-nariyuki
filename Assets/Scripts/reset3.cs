using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class reset3 : MonoBehaviour
{
    [SerializeField] GameObject Key;
    [SerializeField] Keyh k;

    [SerializeField]
    private GameObject clear;

    string sceneName;

    public AudioClip sound01;   //SE用変数

    //１回入るよう
    private bool abc = true;

    void Start()
    {
        Key = GameObject.Find("Key");
        k = Key.GetComponent<Keyh>();
        sceneName = SceneManager.GetActiveScene().name;
    }

<<<<<<< HEAD
    void OnTriggerStay2D(Collider2D collision)
=======
    private void Update()
    {
        if (abc ==false)
        {
            waitTime += 0.1f;
            if (waitTime >= 10f)
            {
                SceneManager.LoadScene("Enemymap");
            }
        }
        Debug.Log(waitTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
>>>>>>> 487e0f02ad4849d8002e35002a37e300633fafe2
    {
        if (collision.gameObject.tag == "Player")
        {
<<<<<<< HEAD
=======

>>>>>>> 487e0f02ad4849d8002e35002a37e300633fafe2
            if (k.keyflg == true)
            {
                Instantiate(clear);
                clear.SetActive(true);
<<<<<<< HEAD

=======
>>>>>>> 487e0f02ad4849d8002e35002a37e300633fafe2
                if (abc)
                {
                    //ゴール音を１度だけ鳴らす
                    abc = false;
                    AudioSource.PlayClipAtPoint(sound01, transform.position);
                }
<<<<<<< HEAD
                Invoke("Return",3);
=======

>>>>>>> 487e0f02ad4849d8002e35002a37e300633fafe2
            }
        }
    }
    void Return()
    {
        SceneManager.LoadScene("Title");
    }
}
