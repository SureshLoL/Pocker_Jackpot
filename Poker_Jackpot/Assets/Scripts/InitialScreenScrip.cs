using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialScreenScrip : MonoBehaviour
{
    [SerializeField] GameObject ButtonCanvas;
    void Start() 
    {
        Invoke("ButtonScreenLoading", 2f);
    }

    void ButtonScreenLoading()
    {
        ButtonCanvas.SetActive(true);
    }

}
