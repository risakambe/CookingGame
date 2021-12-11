using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;
using System.Linq;

public class ranking : MonoBehaviourPunCallbacks
{
    public Sprite imageRanking1;
    public Sprite imageRanking2;
    public Sprite imageRanking3;
    public Image placeFirst;
    public Image placeSecond;
    public Image placeThird;
    // private static int playerNumber;
    private PhotonView myPV;
    private int roomPlayerNumber;
    private GameObject playerPrefab;
    private static bool flag = false;
    private Dictionary<string, int> playerList;


    void Awake() {
        PhotonNetwork.AutomaticallySyncScene = false;
    }



    // Start is called before the first frame update
    void Start()
    {
        roomPlayerNumber = PhotonNetwork.CurrentRoom.PlayerCount;
        GameObject canvas_obj = GameObject.Find("Canvas");

        playerPrefab = Resources.Load("player", typeof(GameObject)) as GameObject;
        GameObject player = PhotonNetwork.Instantiate(playerPrefab.name, canvas_obj.transform.position, Quaternion.identity, 0);
        player.transform.SetParent(canvas_obj.transform);
        myPV = player.gameObject.GetComponent<PhotonView>();
        Debug.Log("entered!:"+PhotonNetwork.LocalPlayer.NickName);
        PhotonNetwork.LocalPlayer.AddRoomMemberNum();
        // if (myPV.IsMine) {
        //     playerNumber++;
        //     Debug.Log("player number+1");
        // }
        playerList = new Dictionary<string, int>();

    }

    // Update is called once per frame
    void Update()
    {
        
        var currentMemberNum = PhotonNetwork.LocalPlayer.GetRoomMemberNum();
        Debug.Log(currentMemberNum + "/ " + roomPlayerNumber);
        if (currentMemberNum == roomPlayerNumber)
        {
            rank();
        }
    }
    public void rank()
    {
        Debug.Log("we are in rank");
        //iterate through all player to update score
        //if no entry exists create one
        //var playerList = PhotonNetwork.CurrentRoom.playerList;
        // foreach (var targetPlayer in PhotonNetwork.CurrentRoom.Players.Values)
        // {
        //     playerList.Add(targetPlayer.NickName, targetPlayer.GetScore());
            
        // }
        // var SortedplayerList =  playerList.OrderByDescending((x) => x.Value);

        // foreach (var value in SortedplayerList)
        // {
        //    Debug.Log(value);
        // }



/*        if (roomPlayerNumber == 3) {
            if (sortedPlayerList[1].GetScore() == sortedPlayerList[0].GetScore()) {
                placeSecond.sprite = imageRanking1;
                if (sortedPlayerList[2].GetScore() == sortedPlayerList[1].GetScore()) {
                    placeThird.sprite = imageRanking1;
                }
                else {
                    placeThird.sprite = imageRanking2;
                }
            }
            else {
                placeSecond.sprite = imageRanking2;
                if (sortedPlayerList[2].GetScore() == sortedPlayerList[1].GetScore()) {
                    placeThird.sprite = imageRanking2;
                }
                else {
                    placeThird.sprite = imageRanking3;
                }
            }
        }
        else if (roomPlayerNumber == 2) {
            placeThird.gameObject.SetActive(false);
            if (sortedPlayerList[1].GetScore() == sortedPlayerList[0].GetScore()) {
                placeSecond.sprite = imageRanking1; }
            else {
                placeSecond.sprite = imageRanking2;
            }
        }
        else {
            placeThird.gameObject.SetActive(false);
            placeSecond.gameObject.SetActive(false);
        }*/
        /*       {
                    var targetEntry = m_entries.Find(x => x.Player == targetPlayer);

                    if (targetEntry == null)
                    {
                        targetEntry = CreateNewEntry(targetPlayer);
                    }

                    targetEntry.UpdateScore();
                }

                SortEntries();*/

    }
}
