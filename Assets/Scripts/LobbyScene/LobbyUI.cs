using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
 
public class LobbyUI : MonoBehaviour {

    private Button OpenRoomPanelButton;
    private GameObject CreateRoomPanel; 
    private TextMeshProUGUI RoomNameText;           
    private Slider PlayerNumberSlider;  
    private TextMeshProUGUI PlayerNumberText;       
    private Button CreateRoomButton;
    private GameObject ScrollView;
    private GameObject LobbyTitle;
    private Button BackToArrayButton;
    private int dish_param = 0;


    void Start(){
        OpenRoomPanelButton = this.transform.Find("OpenRoomPanelButton").gameObject.GetComponent<Button>();
        OpenRoomPanelButton.onClick.AddListener(OnClick_OpenRoomPanelButton);
        CreateRoomPanel     = this.transform.Find("CreateRoomPanel").gameObject;
        CreateRoomButton    = CreateRoomPanel.transform.Find("EnterButton").gameObject.GetComponent<Button>();
        CreateRoomButton.onClick.AddListener(OnClick_CreateRoomButton);
        RoomNameText        = CreateRoomPanel.transform.Find("RoomNamePanel/RoomNameInputField/Text Area/Text").gameObject.GetComponent<TextMeshProUGUI>();
        PlayerNumberSlider  = CreateRoomPanel.transform.Find("PlayerNumberPanel/PlayerNumberSlider").gameObject.GetComponent<Slider>();
        PlayerNumberText    = CreateRoomPanel.transform.Find("PlayerNumberPanel/PlayerNumberText").gameObject.GetComponent<TextMeshProUGUI>();
        ScrollView          = this.transform.Find("RoomScrollView").gameObject;
        LobbyTitle          = this.transform.Find("LobbyText").gameObject;
        BackToArrayButton   = CreateRoomPanel.transform.Find("BackToArrayButton").gameObject.GetComponent<Button>();
        BackToArrayButton.onClick.AddListener(OnClick_OpenRoomPanelButton);

        CreateRoomPanel.SetActive(false);
    }
	// Update is called once per frame
	void Update () {
        PlayerNumberText.text = PlayerNumberSlider.value.ToString();
	}
 
    public void OnClick_OpenRoomPanelButton()
    {
        if (CreateRoomPanel.activeSelf)
        {
            CreateRoomPanel.SetActive(false);
            ScrollView.SetActive(true);
            LobbyTitle.SetActive(true);
        }
        else
        {
            CreateRoomPanel.SetActive(true);
            ScrollView.SetActive(false);
            LobbyTitle.SetActive(false);
        }
    }
 
    public void OnClick_CreateRoomButton()
    {
        print("created room name :"+RoomNameText.text);
        int temnumber = UnityEngine.Random.Range(0, 100);
        if (temnumber <= 50)
        {
            dish_param = 0;
        }
        else
        {
            dish_param = 1;
        }
        print("dish param:"+dish_param.ToString());
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.IsVisible = true;   //visible from lobby
        roomOptions.IsOpen = true;      //accept other players
        roomOptions.MaxPlayers = (byte)PlayerNumberSlider.value;    //set maximum number of players
        roomOptions.CustomRoomProperties = new ExitGames.Client.Photon.Hashtable()
        {
            { "RoomCreator", PhotonNetwork.NickName },
            { "MaxPlayer", (int)PlayerNumberSlider.value },
            { "Dish", dish_param }
        };
        roomOptions.CustomRoomPropertiesForLobby = new string[] {
            "RoomCreator","PlayerState"
        };
        PhotonNetwork.CreateRoom(RoomNameText.text,roomOptions,null);
    }
}