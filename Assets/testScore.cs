using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class testScore : MonoBehaviour
{
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
}