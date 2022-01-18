using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class RoastChickenManager : MonoBehaviour
{
    public GameObject StartMenu;
    public GameObject SuccessMenu;
    public bool GameisPaused = true;
    public ChickenMovement chi;
    public GameObject FailMenu;
    public PhotonManager pmanager;
    public FoodManager fmanager;
    [SerializeField]
    List<int> scenes;
    // Start is called before the first frame update
    void Start()
    {
        pause();
        Invoke("start", 3f);
    }
    public void pause()
    {
        StartMenu.SetActive(true);
        GameisPaused = true;
        chi.paused = true;
    }
    

    public void start()
    {
        StartMenu.SetActive(false);
        GameisPaused = false;
        chi.paused = false;
        //int room_dish_idx = (int)PhotonNetwork.CurrentRoom.CustomProperties["Dish"];
        //scenes = fmanager.GetSceneList(room_dish_idx);
        pmanager.Startthegame();
        FindObjectOfType<AudioManager>().PlaySoundeffect(4);
    }

    public void finish()
    {
        
        SuccessMenu.SetActive(true);
        pmanager.Endthegame();
        Invoke("loadnextscene", 3f);
        FindObjectOfType<AudioManager>().StopPlaySoundeffect();
    }
    
    public void fail()
    {
        pmanager.ResetTheCounter();
        FailMenu.SetActive(true);
        FindObjectOfType<AudioManager>().StopPlaySoundeffect();
    }

    
    void loadnextscene()
    {
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //int next_scene_idx = PhotonNetwork.LocalPlayer.GetNextSceneIdx();
        //PhotonNetwork.LocalPlayer.AddNextSceneIdx();
        //int next_scene = scenes[next_scene_idx];
        //Debug.Log("next scene:" + next_scene.ToString());
        //SceneManager.LoadScene(next_scene);
    }
   public  void Loadcurrentscene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex );
    }

   
}
