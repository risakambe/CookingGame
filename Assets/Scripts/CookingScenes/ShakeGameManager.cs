using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class ShakeGameManager : MonoBehaviour
{
    public GameObject StartMenu;
    public GameObject SuccessMenu;
    public bool GameisPaused = true;
    public GameObject bottle;
    public GameObject fail;
    public GameObject detector;
    public PhotonManager Pmanager;
    public FoodManager fmanager;
    [SerializeField]
    List<int> scenes;
    // Start is called before the first frame update
    void Start()
    {
        pause();
    }
    public void pause()
    {
        StartMenu.SetActive(true);
        Time.timeScale = 0f;
        GameisPaused = true;

    }

    public void start()
    {
        bottle.transform.rotation = Quaternion.Euler(0, 0, 0);
        StartMenu.SetActive(false);
        Time.timeScale = 1f;
        GameisPaused = false;
        int room_dish_idx = (int)PhotonNetwork.CurrentRoom.CustomProperties["Dish"];
        scenes = fmanager.GetSceneList(room_dish_idx);

    }
    public void success()
    {
        Pmanager.Endthegame();
        SuccessMenu.SetActive(true);
        detector.SetActive(false);
    }

    public void endgame()
    {
       SceneManager .LoadScene (SceneManager .GetActiveScene().buildIndex +1);
    }
    public void failgame()
    {
        fail.SetActive(true);
    }
    public void Loadcurrentscene()
    {
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        int next_scene_idx = PhotonNetwork.LocalPlayer.GetNextSceneIdx();
        PhotonNetwork.LocalPlayer.AddNextSceneIdx();
        int next_scene = scenes[next_scene_idx];
        Debug.Log("next scene:" + next_scene.ToString());
        SceneManager.LoadScene(next_scene);
    }

}
