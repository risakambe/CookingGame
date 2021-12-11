using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rankingSecond : MonoBehaviour
{
    public Sprite imageRanking1;
    public Sprite imageRanking2;
    public Sprite imageRanking3;
    public Image placeSecond;

    // Start is called before the first frame update
    void Start()
    {
        //     var sortedPlayerList = (from p in playerList orderby p.GetMyScore() descending select p).ToList();
        //     if (sortedPlayerList[1].GetScore()==sortedPlayerList[0].GetScore()){
        //         placeSecond.sprite = imageRanking1;}
        //     else{
        //         placeSecond.sprite = imageRanking2}

        placeSecond.sprite = imageRanking1;

    }
}
