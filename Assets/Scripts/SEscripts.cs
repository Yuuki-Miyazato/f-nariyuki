using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEscripts : MonoBehaviour
{
    public AudioClip sound1;

    AudioSource audioSource;




    // Start is called before the first frame update
    void Start()
    {
        //Component取得
        audioSource = GetComponent<AudioSource>();
        
    }

        // Update is called once per frame
        void Update()
    {
      // 左
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            audioSource.Play();
            
        }
        // 右
        if (Input.GetKey(KeyCode.RightArrow))
        {
            audioSource.Play();
            
        }
        // 上
        if (Input.GetKey(KeyCode.UpArrow))
        {
            audioSource.Play();
           
        }
        // 下
        if (Input.GetKey(KeyCode.DownArrow))
        {
            audioSource.Play();
        }
    }
}
