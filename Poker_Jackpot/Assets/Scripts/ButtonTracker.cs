using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonTracker : MonoBehaviour
{
    [SerializeField] GameObject Buttons;
    [SerializeField] GameObject PlayerName;
    [SerializeField] GameObject PlayerNameHolder;
    [SerializeField] GameObject DontDestroy;


    public void Play()
    {
        PlayerName.SetActive(true);
        Buttons.SetActive(false);
    }
    public void instructions()
    {

    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Enter()
    {
        DontDestroy.GetComponent<DontDestroy>().Name = PlayerNameHolder.GetComponent<Text>().text;
        SceneManager.LoadScene(1);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return) && DontDestroy.GetComponent<DontDestroy>().Name !=null)
        {
            Enter();
        }
    }
}
