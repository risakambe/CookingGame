using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using Hashtable = ExitGames.Client.Photon.Hashtable;
using System.Collections.Generic;
using TMPro;
 
namespace Com.MyCompany.MyGameMonoBehaviourPunCallbacks
{
    public class LobbyManager :MonoBehaviourPunCallbacks 
    {
        public  GameObject RoomParent;//content object of ScrolView
        private GameObject RoomElementPrefab;
        public TextMeshProUGUI InfoText;

        void Awake()
        {
            //clients in the scene will load the same scene as the master.
            PhotonNetwork.AutomaticallySyncScene = true;
        }
 
        void Start()
        {

        }

        public override void OnConnectedToMaster(){
            PhotonNetwork.JoinLobby();
        }

        public override void OnJoinedLobby()
        {
            base.OnJoinedLobby();
            Debug.Log("Joind lobby");
        }


         public static void DestroyChildObject(Transform parent_trans)
        {
            for (int i = 0; i < parent_trans.childCount; ++i)
            {
                GameObject.Destroy(parent_trans.GetChild(i).gameObject);
            }
        }

        //GetRoomList is updated regularly
        public override void OnRoomListUpdate(List<RoomInfo> roomInfo)
        {

            Debug.Log("roomList is being Updated...");
            base.OnRoomListUpdate(roomInfo);
            DestroyChildObject(RoomParent.transform);  
            if (roomInfo == null || roomInfo.Count == 0) return;
 
            for (int i = 0; i < roomInfo.Count; i++)
            {
                // Debug.Log("room info count"+roomInfo.Count.ToString());
                if (roomInfo[i].PlayerCount != 0){
                    Debug.Log(roomInfo[i].Name + " : " + roomInfo[i].Name + "–" + roomInfo[i].PlayerCount + " / " + roomInfo[i].MaxPlayers /*+ roomInfo[i].CustomProperties["roomCreator"].ToString()*/);
                    RoomElementPrefab = Resources.Load("RoomElement",  typeof(GameObject)) as GameObject;
                    GameObject RoomElement = GameObject.Instantiate(RoomElementPrefab);
                    RoomElement.transform.SetParent(RoomParent.transform);
                    Debug.Log("GetRoomInfo in updater:" + roomInfo[i].Name);
                    RoomElement.GetComponent<RoomElement>().SetRoomInfo(roomInfo[i].Name, roomInfo[i].PlayerCount, roomInfo[i].MaxPlayers, roomInfo[i].CustomProperties["RoomCreator"].ToString());
                }  
            }
        }
        
        public override void OnCreateRoomFailed(short returnCode, string message)
        {
            base.OnCreateRoomFailed(returnCode, message);
            InfoText.text = "failed to create a new room";
        }

        public override void OnCreatedRoom()
        {
            base.OnCreatedRoom();
            PhotonNetwork.LoadLevel("WaitScene");
        }

        public override void OnJoinRoomFailed(short returnCode, string message)
        {
            base.OnJoinRoomFailed(returnCode, message);
            InfoText.text = "failed to join a room";
        }
 
        public override void OnJoinedRoom()
        {
            base.OnJoinedRoom();
        }
    }
}