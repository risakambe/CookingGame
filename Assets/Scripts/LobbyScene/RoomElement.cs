using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
 
public class RoomElement : MonoBehaviour {
    public TextMeshProUGUI RoomName;
    public TextMeshProUGUI PlayerNumber; 
    public TextMeshProUGUI RoomCreator; 
    public Button EnterButton;

    private string roomname;

    void start(){
        // RoomName = this.gameObject.transform.Find("RoomName").gameObject.GetComponent<TextMeshProUGUI>();
        // PlayerNumber = this.gameObject.transform.Find("PlayerNumber").gameObject.GetComponent<TextMeshProUGUI>();
        // RoomCreator = this.gameObject.transform.Find("RoomCreator").gameObject.GetComponent<TextMeshProUGUI>();
        // EnterButton = this.gameObject.transform.Find("EnterButton").gameObject.GetComponent<Button>();
        // EnterButton.onClick.AddListener(OnJoinRoomButton);
        // RoomName.text ="Room name：Hogehoge";
    }

    public void SetRoomInfo(string _RoomName,int _PlayerNumber,int _MaxPlayer,string _RoomCreator)
    {
        roomname = _RoomName;
        RoomName.text ="Room name:"+_RoomName;
        PlayerNumber.text ="# players:" +_PlayerNumber+"/"+_MaxPlayer;
        RoomCreator.text = "creator:"+_RoomCreator;
    }
 
    public void OnJoinRoomButton()
    {
        PhotonNetwork.JoinRoom(roomname);
    }
}
