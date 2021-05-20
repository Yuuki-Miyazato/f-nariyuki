using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Help : MonoBehaviour
{
    [SerializeField]
    private GameObject helpUI;

    public void OnStartButtonClicked()
    {
        helpUI.SetActive(!helpUI.activeSelf);
    }
}
