using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;



public class gameManager : MonoBehaviour
{
    public GameObject StartMenu;
    public GameObject SuccessMenu;
    public int FinishedNumber = 5;
    public bool GameisPaused = true;
    public GameObject plate;
    public GameObject[] peeledpotatoes;
    public GameObject[] toDestroy;
    public PhotonManager pmanager;
    [SerializeField]
    int scores;
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
        scores = PhotonNetwork.LocalPlayer.GetScore();
        StartMenu.SetActive(false);
        Time.timeScale = 1f;
        GameisPaused = false;
    }

    public void finish(int counter)
    {
        if (counter >= FinishedNumber)
        {
            pmanager.Endthegame();
            peeledpotatoes = GameObject.FindGameObjectsWithTag("PeeledPotatoes");
            foreach (GameObject obj in toDestroy)
            {
                Destroy(obj);
            }
            Invoke("throwpotatoes", 0.5f);
            Invoke("loadnextscene", 3f);
           
        }
    }
    public void endgame()
    {
        Application.Quit();
    }

    void throwpotatoes()
    {
        SuccessMenu.SetActive(true);
        plate.SetActive(true);
        foreach (GameObject potato in peeledpotatoes)
        {
            potato.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            potato.GetComponent<Rigidbody2D>().gravityScale = 4;
        }
    }
    void loadnextscene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

}
