using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rankingThird : MonoBehaviour
{
    public Sprite imageRanking1;
    public Sprite imageRanking2;
    public Sprite imageRanking3;
    public Image placeThird;

    // Start is called before the first frame update 
    void Start()
    {
        //     var sortedPlayerList = (from p in playerList orderby p.GetMyScore() descending select p).ToList(); 
        //     if (sortedPlayerList[1].GetScore()==sortedPlayerList[0].GetScore()){ 
        //         if (sortedPlayerList[2].GetScore()==sortedPlayerList[1].GetScore()){ 
        //             placeThird.sprite = imageRanking1} 
        //         else{ 
        //             placeThird.sprite = imageRanking2} 
        //     } 
        //     else { 
        //         if (sortedPlayerList[2].GetScore()==sortedPlayerList[1].GetScore()){ 
        //             placeThird.sprite = imageRanking2} 
        //         else { 
        //             placeThird.sprite = imageRanking3} 
        //     } 

        placeThird.sprite = imageRanking1;

    }
}