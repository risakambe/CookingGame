using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class testScore : MonoBehaviour
{
    void Awake(){
        PhotonNetwork.AutomaticallySyncScene = false;
    }
    public void onButtonAdd()
    {
        PhotonNetwork.LocalPlayer.AddScore(10);
        Debug.Log(PhotonNetwork.LocalPlayer.GetScore().ToString());
    }

    public void onButtonSub()
    {
        PhotonNetwork.LocalPlayer.AddScore(-10);
        Debug.Log(PhotonNetwork.LocalPlayer.GetScore().ToString());
    }

    public void onButtonShow()
    {
        Debug.Log(PhotonNetwork.LocalPlayer.GetScore().ToString());
    }

    public void ranking()
    {
        PhotonNetwork.LoadLevel("rankingScene");
    }

}