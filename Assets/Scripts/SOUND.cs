using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SOUND : MonoBehaviour
{
    private int Scount = 1;
    public void OnStartButtonClicked()
    {
        if (Scount == 1) 
        {
            AudioListener.volume = 0;
            Scount = 0;
        }
        else if (Scount == 0)
        {
            AudioListener.volume = 1;
            Scount = 1;
        }
    }
}
