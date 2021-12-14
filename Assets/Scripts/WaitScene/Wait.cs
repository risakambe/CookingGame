using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;
using System.Linq;
using UnityEngine.SceneManagement;

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
    public void startMainGame(){
        SceneManager.LoadScene("Selection");
    }

}
