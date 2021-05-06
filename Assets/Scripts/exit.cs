using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exit : MonoBehaviour
{
    
    public void OnStartButtonClicked()
    {
        //UnityEditor.EditorApplication.isPlaying = false;
        UnityEngine.Application.Quit();
    }
}
