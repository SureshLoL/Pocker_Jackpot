using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    public NetworkManager Instance;

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            gameObject.SetActive(false);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        print("Connecter to master server");
    }

    public void CreateNetwork(string RoomName)
    {
        PhotonNetwork.CreateRoom(RoomName);
    }

    public void JoinRoom(string RoomName)
    {
        PhotonNetwork.JoinRoom(RoomName);
    }

    public void Loadgame(string sceneName)
    {
        PhotonNetwork.LoadLevel(sceneName);
    }
}
