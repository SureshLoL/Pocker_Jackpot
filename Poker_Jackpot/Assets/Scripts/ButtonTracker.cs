using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonTracker : MonoBehaviour
{

    public void Play()
    {
        SceneManager.LoadScene(1);
    }
    public void instructions()
    {

    }

    public void Quit()
    {
        Application.Quit();
    }

}
