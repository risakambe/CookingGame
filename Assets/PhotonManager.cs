using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class PhotonManager : MonoBehaviour
{
    public float counter = 0;
    public bool gameisruning = false;
    [SerializeField ]
    int scores = 0;
    void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = false;
    }
    private void Update()
    {
        if (gameisruning ==true) {
            counter += Time.deltaTime;
        }
        
    }
    public void Startthegame()
    {
        gameisruning = true;
    }
    public void Endthegame()
    {
        FindObjectOfType<AudioManager>().StopPlayingBackground(1);
        gameisruning = false;
        scores = 100-(int)counter / 3;
        PhotonNetwork.LocalPlayer.AddScore(scores);
    }
    public void ResetTheCounter()
    {
        counter = 0;
    }


}
