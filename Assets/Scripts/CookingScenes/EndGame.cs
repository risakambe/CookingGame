using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class EndGame : MonoBehaviour
{
    public FoodManager fmanager;
    [SerializeField]
    List<int> scenes;
    public GameObject successMenu;
    public PhotonManager pmanager;
    // Start is called before the first frame update
    void Start()
    {
        successMenu.SetActive(true);
        int room_dish_idx = (int)PhotonNetwork.CurrentRoom.CustomProperties["Dish"];
        scenes = fmanager.GetSceneList(room_dish_idx);
        pmanager.Endthegame();
        Invoke("LoadNextscene", 3f);
    }

    // Update is called once per frame
    void LoadNextscene()
    {
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        int next_scene_idx = PhotonNetwork.LocalPlayer.GetNextSceneIdx();
        PhotonNetwork.LocalPlayer.AddNextSceneIdx();
        int next_scene = scenes[next_scene_idx];
        Debug.Log("next scene:" + next_scene.ToString());
        SceneManager.LoadScene(next_scene);
    }
}
