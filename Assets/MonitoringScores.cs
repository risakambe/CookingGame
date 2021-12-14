using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class MonitoringScores : MonoBehaviour
{
    [SerializeField ]
    int scores;
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    void Update()
    {
        scores = PhotonNetwork.LocalPlayer.GetScore();
        Debug.Log(scores);
       
    }
}
