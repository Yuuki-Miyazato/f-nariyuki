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
    public bool abc = true;

    [SerializeField] public GameObject fead;
    [SerializeField] private Animator anim;

    void Start()
    {
        fead = GameObject.FindWithTag("fead");
        anim = fead.GetComponent<Animator>();
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
                Instantiate(clear);
                clear.SetActive(true);
                anim.SetBool("goal", true);
                
                if (abc)
                {
                    //ゴール音を１度だけ鳴らす
                    abc = false;
                    AudioSource.PlayClipAtPoint(sound01, transform.position);
                }
                Invoke("Return",3);
            }
        }
    }
    void Return()
    {
        if (SceneManager.GetActiveScene().name == "Enemymap")
        {
            SceneManager.LoadScene("Enemymap2");
        }
        if (SceneManager.GetActiveScene().name == "Enemymap2")
        {
            SceneManager.LoadScene("Enemymap3");
        }
        if (SceneManager.GetActiveScene().name == "Enemymap3")
        {
            SceneManager.LoadScene("Enemymap4");
        }
        if (SceneManager.GetActiveScene().name == "Enemymap4")
        {
            SceneManager.LoadScene("Enemymap5");
        }
        if (SceneManager.GetActiveScene().name == "Enemymap5")
        {
            SceneManager.LoadScene("Enemymap6");
        }
        if (SceneManager.GetActiveScene().name == "Enemymap6")
        {
            SceneManager.LoadScene("Title");
        }
    }
}
