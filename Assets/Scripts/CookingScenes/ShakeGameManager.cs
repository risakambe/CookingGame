using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShakeGameManager : MonoBehaviour
{
    public GameObject StartMenu;
    public GameObject SuccessMenu;
    public bool GameisPaused = true;
    public GameObject bottle;
    public GameObject fail;
    public GameObject detector;
    public PhotonManager Pmanager;
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
