using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoastChickenManager : MonoBehaviour
{
    public GameObject StartMenu;
    public GameObject SuccessMenu;
    public bool GameisPaused = true;
    public ChickenMovement chi;
    public GameObject FailMenu;
    public PhotonManager pmanager;
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
        pmanager.Startthegame();
    }

    public void finish()
    {
        
        SuccessMenu.SetActive(true);
        pmanager.Endthegame();
        Invoke("loadnextscene", 3f);
    }
    
    public void fail()
    {
        pmanager.ResetTheCounter();
        FailMenu.SetActive(true);
    }

    
    void loadnextscene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
   public  void Loadcurrentscene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex );
    }

   
}
