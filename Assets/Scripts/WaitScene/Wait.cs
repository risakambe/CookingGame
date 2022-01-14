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
using TMPro;


public class Wait : MonoBehaviourPunCallbacks
{
    private int roomPlayerNumber;    
    private bool flag;
    public TextMeshProUGUI currentNumText;

    void Awake() {
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.LocalPlayer.SetScore(0);
        PhotonNetwork.LocalPlayer.ResetInLastScene();
        PhotonNetwork.LocalPlayer.ResetNextSceneIdx();
        flag = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (flag){
            int MaxPlayer = (int)PhotonNetwork.CurrentRoom.CustomProperties["MaxPlayer"];
            int currentPlayer = PhotonNetwork.CurrentRoom.PlayerCount;
            currentNumText.text = currentPlayer.ToString() + "/" + MaxPlayer.ToString();
            if (MaxPlayer == currentPlayer){
                startMainGame(); 
            }
        }
        
    }
    public void startMainGame(){
        SceneManager.LoadScene("Selection");
    }

    public void BackToLobby(){
        flag = false;
        PhotonNetwork.LeaveRoom();
        
    }

    public override void OnLeftRoom(){
        SceneManager.LoadScene("Lobby"); //一番初めの画面へ戻る
    }

}
