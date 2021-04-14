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

    private float waitTime = 0;

    public AudioClip sound01;   //SE用変数

    //１回入るよう
    private bool abc = true;

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
                if (abc)
                {
                    //ゴール音を１度だけ鳴らす
                    abc = false;
                    AudioSource.PlayClipAtPoint(sound01, transform.position);
                }
                if (waitTime >= 10f)
                {
                    SceneManager.LoadScene("Enemymap");
                }
            }
        }
    }
}
