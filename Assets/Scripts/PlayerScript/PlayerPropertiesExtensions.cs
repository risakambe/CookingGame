using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public static class PlayerPropertiesExtensions
{
    private const string ScoreKey = "Score";
    private const string InLastScene = "InLastScene";
    private const string NextSceneIdx = "NextSceneIdx";

    private static readonly ExitGames.Client.Photon.Hashtable propsToSet = new ExitGames.Client.Photon.Hashtable();

    public static int GetScore(this Player player) {
        return (player.CustomProperties[ScoreKey] is int score) ? score : 0;
    }

    public static void SetScore(this Player player, int score) {
        propsToSet[ScoreKey] = score;
        player.SetCustomProperties(propsToSet);
        propsToSet.Clear();
    }

    public static void AddScore(this Player player, int value) {
        propsToSet[ScoreKey] = player.GetScore() + value;
        player.SetCustomProperties(propsToSet);
        propsToSet.Clear();
    }

    public static bool GetInLastScene(this Player player) {
        return (player.CustomProperties[InLastScene] is bool isIn) ? isIn : false;
    }


    public static void SetInLastScene(this Player player) {
        propsToSet[InLastScene] = true;
        player.SetCustomProperties(propsToSet);
        propsToSet.Clear();
    }

    public static void ResetInLastScene(this Player player) {
        propsToSet[InLastScene] = false;
        player.SetCustomProperties(propsToSet);
        propsToSet.Clear();
    }

    public static int GetNextSceneIdx(this Player player) {
        return (player.CustomProperties[NextSceneIdx] is int idx) ? idx : 0;
    }

    public static void AddNextSceneIdx(this Player player){
        propsToSet[NextSceneIdx] = player.GetNextSceneIdx() + 1;
        player.SetCustomProperties(propsToSet);
        propsToSet.Clear();
    }

    public static void ResetNextSceneIdx(this Player player) {
        propsToSet[NextSceneIdx] = 0;
        player.SetCustomProperties(propsToSet);
        propsToSet.Clear();
    }

}

/*
if you want to use the properties:
int score = PhotonNetwork.LocalPlayer.GetScore();
PhotonNetwork.LocalPlayer.SetMessage("hello");

 */