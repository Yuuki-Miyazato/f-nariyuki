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
        if (collision.gameObject.tag == "Player")
        {
            private void Update()
            {
                if (abc == false)
                {
                    waitTime += 0.1f;
                    if (waitTime >= 10)
                    {
                        SceneManager.LoadScene("Title");
                    }
                }
                Debug.Log(waitTime);
            }


            void OnTriggerEnter2D(Collider2D collision)
            {


                if (collision.gameObject.tag == "Player")
                {
                    if (k.keyflg == true)
                    {
                        Instantiate(clear);
                        clear.SetActive(true);

                        if (abc)
                        {
                            //ゴール音を１度だけ鳴らす
                            abc = false;
                            AudioSource.PlayClipAtPoint(sound01, transform.position);
                        }
                        Invoke("Return", 3);
                    }
                }
            }
            void Return()
            {
                SceneManager.LoadScene("Enemymap2");
            }
        }
