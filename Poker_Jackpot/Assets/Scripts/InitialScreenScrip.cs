using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialScreenScrip : MonoBehaviour
{
    [SerializeField] GameObject ButtonCanvas;
    [SerializeField] GameObject Buttons;
    [SerializeField] GameObject PlayerName;
    bool Working = true;
    private void Update()
    {
        Invoke("PressKey", 0.5f);
    }

    private void PressKey()
    {
        if (Input.anyKey && Working)
        {
            print("Working");
            ButtonScreenLoading();
        }
    }

    void ButtonScreenLoading()
    {
        ButtonCanvas.SetActive(true);
        PlayerName.SetActive(false);
        Working = false;
    }

}
