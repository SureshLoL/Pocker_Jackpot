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
    [SerializeField] GameObject RoomName;
    [SerializeField] GameObject DontDestroy;
    public string Playername, Roomname;


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

    public void Create()
    {
        DontDestroy.GetComponent<DontDestroy>().Create = true;
        LoadLobby();
    }

    public void join()
    {
        DontDestroy.GetComponent<DontDestroy>().Join = true;
        LoadLobby();
    }

    private void LoadLobby()
    {
        Playername = PlayerNameHolder.GetComponent<Text>().text;
        Roomname = RoomName.GetComponent<Text>().text;
        DontDestroy.GetComponent<DontDestroy>().Name = Playername;
        DontDestroy.GetComponent<DontDestroy>().RoomName = Roomname;
        SceneManager.LoadScene(1);
    }
}
