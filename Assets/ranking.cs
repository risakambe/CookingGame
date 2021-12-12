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
    private static bool flag = true;
    private Dictionary<string, int> playerList;
    public Text name1;
    public Text name2;
    public Text name3;



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
        playerList = new Dictionary<string, int>();
        PhotonNetwork.LocalPlayer.SetInLastScene();
    }

    // Update is called once per frame
    void Update()
    {
        if (flag){
            bool counterFlag = true;
            int currentMemberNum = 0;
            foreach (var targetPlayer in PhotonNetwork.CurrentRoom.Players.Values)
            {
                counterFlag = counterFlag && targetPlayer.GetInLastScene();
                if (counterFlag == false){
                    break;
                }
                currentMemberNum++;
            }
            if (currentMemberNum == roomPlayerNumber)
            {
                flag = false;
                rank();
            }
        }
    }

    public void rank()
    {
        List<int> scoreList = new List<int>();
        List<string> nameList = new List<string>();
        Debug.Log("we are in rank");
        //iterate through all player to update score
        //if no entry exists create one
        // playerList = PhotonNetwork.CurrentRoom.playerList;
        foreach (var targetPlayer in PhotonNetwork.CurrentRoom.Players.Values)
        {
            playerList.Add(targetPlayer.NickName, targetPlayer.GetScore());
            
        }
        var sortedPlayerDict =  playerList.OrderByDescending((x) => x.Value);

        foreach (var value in sortedPlayerDict)
        {
           Debug.Log(value);
           scoreList.Add(value.Value);
           nameList.Add(value.Key);
        }        

        if (roomPlayerNumber == 3) {
            name1.text = nameList[0];
            name2.text = nameList[1];
            name3.text = nameList[2];
            if (scoreList[1] == scoreList[0]) {
                placeSecond.sprite = imageRanking1;
                if (scoreList[2] == scoreList[1]) {
                    placeThird.sprite = imageRanking1;
                }
                else {
                    placeThird.sprite = imageRanking2;
                }
            }
            else {
                placeSecond.sprite = imageRanking2;
                if (scoreList[2]== scoreList[1]) {
                    placeThird.sprite = imageRanking2;
                }
                else {
                    placeThird.sprite = imageRanking3;
                }
            }
        }
        else if (roomPlayerNumber == 2) {
            name1.text = nameList[0];
            name2.text = nameList[1];
            name3.enabled = false;
            placeThird.gameObject.SetActive(false);
            if (scoreList[1] == scoreList[0]) {
                placeSecond.sprite = imageRanking1; }
            else {
                placeSecond.sprite = imageRanking2;
            }
        }
        else {
            name1.text = nameList[0];
            name2.enabled = false;
            name3.enabled = false;
            placeThird.gameObject.SetActive(false);
            placeSecond.gameObject.SetActive(false);
        }
        
    }
}
