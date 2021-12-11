using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// find
public class ButtonTest : MonoBehaviour
{
    // ボタンが押された場合、今回呼び出される関数
    public void OnClick()
    {
        Debug.Log("押された!");  // ログを出力
    }

    // エディタのインスペクタで、この変数にヒエラルキーにある Canvas を割り当ててください。
    public Canvas canvasConfirmationEndGame = null;

    // Use this for initialization ここまでok
    void Start()
    {
        // ダイアログを表示するときまで、 Canvas を無効にしておく。
        if (canvasConfirmationEndGame != null)
        {
            canvasConfirmationEndGame.enabled = false;
        }
    }

    // クリックされた
    public void OnMouseUpAsButton()
    {
        Debug.Log("押された１１!");  // ログを出力
        ConfirmationEndGame();
    }

    // ダイアログを表示
    public void ConfirmationEndGame()
    {
        // Canvas を有効にする
        if (canvasConfirmationEndGame != null)
        {
            canvasConfirmationEndGame.enabled = true;
        }
    }

    // Yes ボタンと関連づけたイベントハンドラ関数
    public void onButtonYes()
    {
        canvasConfirmationEndGame.enabled = false;
        //  SceneManager.LoadScene ("sselection"); //back to main room　
        // Canvas を無効にする。(ダイアログを閉じる)
    }

    // No ボタンと関連づけたイベントハンドラ関数
    public void onButtonNo()
    {
        // Canvas を無効にする。(ダイアログを閉じる)
        Debug.Log("Yes押された!");  // ログを出力
        SceneManager.LoadScene("startScene"); //一番初めの画面へ戻る
    }
}