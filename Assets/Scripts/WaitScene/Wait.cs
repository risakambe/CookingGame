using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;
using System.Linq;
using UnityEngine.SceneManagement;
using System;

public class Wait : MonoBehaviourPunCallbacks
{
    private int roomPlayerNumber;    
    private bool flag = true;

    void Awake() {
        PhotonNetwork.AutomaticallySyncScene = true;
    }



    // Start is called before the first frame update
    void Start()
    {
       
    }

    void Update()
    {
        int MaxPlayer = (int)PhotonNetwork.CurrentRoom.CustomProperties["MaxPlayer"];
        if (MaxPlayer == PhotonNetwork.CurrentRoom.PlayerCount)
        { startMainGame(); }
    }
    public void startMainGame(){
        SceneManager.LoadScene("Selection");
    }

}
